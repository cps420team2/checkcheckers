'use strict';

var db = require('../config/db');

var Booksubject = require('./booksubject')

var mysql = require('mysql');

// partially from http://stackoverflow.com/questions/4434076/best-way-to-alphanumeric-check-in-javascript
function isValid(str) {
  var code, i, len;

  for (i = 0, len = str.length; i < len; i++) {
    code = str.charCodeAt(i);
    if (!(code > 47 && code < 58) && // numeric (0-9)
        !(code > 64 && code < 91) && // upper alpha (A-Z)
        !(code > 96 && code < 123) && // lower alpha (a-z)
        !(code == 32) && // space
        !(code == 39)) { // apostrophes
      return false;
    }
  }
  return true;
};

function Item(id, callNo, author, title, pubInfo, descript, series, addAuthor, updateCount) {
    this.id = id;
    this.callNo = callNo;
    this.author = author;
    this.title = title;
    this.pubInfo = pubInfo;
    this.descript = descript;
    this.series = series;
    this.addAuthor = addAuthor;
    this.updateCount = updateCount;
}

Item.search = function (callback) {
    db.pool.getConnection(function (err, connection) {
        connection.query('select * from items order by title limit 10', function (err, data) {
            //console.log(data);
            connection.release();              
            if (err) return callback(err);

            if (data) {
                var results = [];
                for (var i = 0; i < data.length; ++i) {
                    var item = data[i];
                    results.push(new Item(item.ID, item.CALLNO, item.AUTHOR, item.TITLE, item.PUB_INFO,
                        item.DESCRIPT, item.SERIES, item.ADD_AUTHOR, item.UPDATE_COUNT));
                }
                callback(null, results);
            } else {
                callback(null, null);
            }
        });
    });
}

Item.dosearch = function(req, res, callback) {
    var obj = {};
    obj.session = req.session
    obj.title = req.query.txtTitle;
    obj.titleURL = encodeURIComponent(obj.title);
    obj.start = parseInt(req.query.start || '0');
    if (obj.start < 0) {
        obj.start = 0;
    }
    obj.prev_start = obj.start - 10;
    obj.next_start = obj.start + 10;
    if(obj.prev_start >= 0 ){
        obj.prev_show = true;
    }
    
    if (!obj.title) {
        obj.mobilesearch = true;
        callback(obj.error, obj);
        return;
    }
    if (!isValid(obj.title)) {
        obj.error = 'Please enter only standard alphanumeric symbols (letters, digits, spaces) and/or apostrophes.';
        callback(obj.error, obj);
        return;
    }
    db.pool.getConnection(function(err, connection) { 
        if (err) {
            obj.error = err;
            callback(obj.error, obj);
            return;
        }
        var title = '%' + obj.title + '%';
        var sql =  "SELECT * FROM items WHERE TITLE LIKE ? ORDER BY AUTHOR LIMIT 10 OFFSET ?";
        var inserts = [title, obj.start];
        sql = mysql.format(sql, inserts);
        connection.query(sql, function(err, result, fields) {
            if (err) {
                obj.error = err;
                connection.release();
                callback(obj.error, obj);
                return;
            }
            var data = [];
            for (var i = 0; i < result.length; ++i) {
                var item = result[i];
                data.push(new Item(item.ID, item.CALLNO, item.AUTHOR, item.TITLE, item.PUB_INFO,
                    item.DESCRIPT, item.SERIES, item.ADD_AUTHOR, item.UPDATE_COUNT));
            }
            obj.result = data;
            if (result.length == 0) {
                obj.error = 'No Books found';
                connection.release();
                callback(obj.error, obj);
                return;
            }
            var sql_count = "SELECT COUNT(*) AS count FROM items WHERE TITLE LIKE ?";
            var inserts_count = [title];
            sql_count = mysql.format(sql_count, inserts_count);
            connection.query(sql_count, function(err, count, field) {
                if (err) {
                    obj.result = null;
                    obj.error = err;
                    connection.release();
                    callback(obj.error, obj);
                    return;
                }
                obj.matches = parseInt(count[0].count);
                obj.curr_page = Math.floor((obj.start / 10) + 1);
                obj.max_page = Math.floor((obj.matches / 10) + 1);
                if (obj.next_start < obj.matches) {
                    obj.next_show = true;
                }
                connection.release();
                callback(obj.error, obj);
            });
        });
    });
}

Item.details = function(req, res, callback) {
    var obj = {};
    obj.session = req.session;
    obj.id = req.query.book_id;
    if (!obj.id) {
        obj.error = "Please send an id";
        callback(obj.error, obj);
        return;
    }
    db.pool.getConnection(function(err, connection) { 
        if (err) {
            obj.error = err;
            callback(obj.error, obj);
            return;
        }
        var sql = 'SELECT * FROM items WHERE ID = ?';
        var insert = [obj.id];
        sql = mysql.format(sql, insert);
        connection.query(sql, function(err, result, field) {
            connection.release();
            if (err) {
                obj.error = err;
                callback(obj.error, obj);
                return;
            }
            if (result.length == 0) {
                obj.error = 'No Books found';
                callback(obj.error, obj);
                return;
            }

            var item = result[0];
            obj.book = new Item(item.ID, item.CALLNO, item.AUTHOR, item.TITLE, item.PUB_INFO,
                        item.DESCRIPT, item.SERIES, item.ADD_AUTHOR, item.UPDATE_COUNT);
            
            Booksubject.getSubjects(obj.id, function(err, data) {
                if (err) {
                    obj.error = err;
                    obj.book = null;
                } else {
                    obj.subjects = data;
                }
                callback(null, obj);
            });
        });
    });
}

Item.updateRecord = function(req, res, callback) {
    var obj = {};
    obj.session = req.session;
    var item = new Item(req.body.id || '', req.body.txtCallNo || '', req.body.txtAuthor || '', 
     req.body.txtTitle || '', req.body.TxtPubInfo || '', req.body.txtDesc || '', req.body.txtSereies || '',
     req.body.txtAddAuthor || '', req.body.updateCount || '');
    
    obj.book = item;
    if (!item.id) {
        obj.error = "No item ID supplied.";
        callback(obj.error, obj)
        return;
    }

    if (!item.title || !item.author || !item.callNo) {
        obj.error = 'Please enter a Title, Author, and Call Number';
        callback(obj.error, obj)
        return;
    }
    
    var sql = "UPDATE items SET CALLNO = ?, AUTHOR = ?, TITLE = ?, PUB_INFO = ?, DESCRIPT = ?, SERIES = ?, ADD_AUTHOR = ?, UPDATE_COUNT = ? WHERE ID = ? AND UPDATE_COUNT = ?";
    var insert = [item.callNo, item.author, item.title, item.pubInfo, item.descript, item.series, item.addAuthor, parseInt(item.updateCount) + 1, item.id, item.updateCount];
    sql = mysql.format(sql, insert);
    db.pool.getConnection(function(err, connection) { 
        if (err) {
            obj.error = err;
            callback(obj.error, obj);
            return;
        }

        connection.query(sql,function(err, result, field) {
            connection.release(); 
            if (err) {
                obj.error = err;
                callback(obj.error, obj);
                return;
            }
            if (result.affectedRows == 0) {
                obj.error = 'Someone updated the book while you were editing it. Please refresh the page and load the current content and update the book again';
                callback(obj.error, obj);
                return;
            }
            obj.successful = true;
            callback(null, obj);
        });
    });
}

module.exports = Item;
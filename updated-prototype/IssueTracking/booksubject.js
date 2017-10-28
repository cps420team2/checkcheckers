'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Booksubject(BookID, Subject) {
    this.BookID = BookID;
    this.Subject = Subject;
}

Booksubject.getSubjects = function(id, callback) {
    db.pool.getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }
        var sql_subs = "SELECT * FROM booksubjects WHERE BookID = ?"
        sql_subs = mysql.format(sql_subs, [id]);
        connection.query(sql_subs, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }

            var results = [];
            for (var i = 0; i < data.length; ++i) {
                var item = data[i];
                results.push(new Booksubject(item.BookID, item.Subject));
            }

            callback(null, results);
        });
    });
}

module.exports = Booksubject;
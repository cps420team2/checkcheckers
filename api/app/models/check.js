'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Check(checkstuff) {
    this.checkstuff
}

Check.add = function() {

}

Check.getChecks = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Get_Checks WHERE Check_Paid = ?';
        sql = mysql.format(sql, 0);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No checks found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Check.getSingleCheck = function(dbname, Check_ID, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Get_Checks WHERE Check_Paid = ? AND Check_id = ?';
        sql = mysql.format(sql, [0, Check_ID]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('Check not found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Check.createCheck = function(dbname, check_num, check_date, check_amount, clerk_id, acc_id, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'INSERT INTO CheckInfo(Check_Number, Check_Date, Check_Amount, Clerk_Id, Acc_Id) VALUES (?, ?, ?, ?, ?)';
        sql = mysql.format(sql, [check_num, check_date, check_amount, clerk_id, acc_id]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('No check added.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Check.editCheck = function(dbname, check_id, check_num, check_date, check_amount, clerk_id, acc_id, callback) {
    var nonNulls = [];
    var field_names = [];
    if (check_num != null) {
        nonNulls.push(check_num);
        field_names.push("Check_Number = ?");
    }
    if (check_date != null) {
        nonNulls.push(check_date);
        field_names.push("Check_Date = ?");
    }
    if (check_amount != null) {
        nonNulls.push(check_amount);
        field_names.push("Check_Amount = ?");
    }
    if (clerk_id != null) {
        nonNulls.push(clerk_id);
        field_names.push("Clerk_Id = ?");
    }
    if (acc_id != null) {
        nonNulls.push(acc_id);
        field_names.push("Acc_Id = ?");
    }

    if (nonNulls.length == 0) {
        callback("No changes requested", null);
        return;
    }

    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }
        
        nonNulls.push(check_id)
        var sql = 'UPDATE CheckInfo SET ' + field_names.join(", ") + " WHERE Check_ID = ?"
        sql = mysql.format(sql, nonNulls);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('The check was not updated.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = Check;
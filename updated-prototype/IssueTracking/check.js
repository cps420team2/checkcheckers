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

module.exports = Check;
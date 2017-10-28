'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function User(username, password) {
    this.username = username;
    this.password = password;
}

User.checkCred = function(username, password, callback) {
    var user = new User(username, password);
    db.userdb.getConnection(function(err, connection) { 
        if (err) {
            callback(err, false);
            return;
        }

        var sql = 'SELECT User_Id, Username, F_Name, L_Name, User_Stat, Company_Name FROM Users WHERE Username = ? AND Passwd_Hash = ?';
        sql = mysql.format(sql, [user.username, user.password]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, false);
                return;
            }
            if (data.length === 1) {
                callback(null, true);
                return;
            }
            callback('Invalid username or password.', false);
        });
    });
}

User.getdb = function(username, callback) {
    User.getinfo(username, function(err, user) {
        if (err) {
            callback(err, null);
        } else {
            callback(err, user.Company_Name);
        }
    });
}

User.getinfo = function(username, callback) {
    db.userdb.getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT User_Id, Username, F_Name, L_Name, User_Stat, Company_Name FROM Users WHERE Username = ?';
        sql = mysql.format(sql, username);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 1) {
                callback(null, data[0]);
                return;
            }
            callback('User not found.', null);
        });
    });
}
User.getCompUsers = function(company, callback) {
    db.userdb.getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT User_Id, Username, F_Name, L_Name, User_Stat, Company_Name FROM Users WHERE Company_Name = ?';
        sql = mysql.format(sql, company);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No users found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = User;
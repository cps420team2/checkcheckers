'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Clerk(clerkstuff) {
    this.clerkstuff
}

Clerk.getClerks = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Clerk';
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No clerks found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Clerk.getClerkswithStoreInfo = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM team2db.Clerk LEFT JOIN team2db.Store ON Clerk.Store_Id = Store.Store_Id';
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No clerks found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Clerk.getSingleClerk = function(dbname, Clerk_ID, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Clerk WHERE Clerk_Id = ?';
        sql = mysql.format(sql, [Clerk_ID]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('Clerk not found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Clerk.createClerk = function(dbname, F_Name, L_Name, Store_Id, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'INSERT INTO Clerk(F_Name, L_Name, Store_Id) VALUES (?, ?, ?)';
        sql = mysql.format(sql, [F_Name, L_Name, Store_Id]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('No Clerk added.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Clerk.editClerk = function(dbname, Clerk_Id, F_Name, L_Name, Store_Id, callback) {
    var nonNulls = [];
    var field_names = [];
    if (F_Name != null) {
        nonNulls.push(F_Name);
        field_names.push("F_Name = ?");
    }
    if (L_Name != null) {
        nonNulls.push(L_Name);
        field_names.push("L_Name = ?");
    }
    if (Store_Id != null) {
        nonNulls.push(Store_Id);
        field_names.push("Store_Id = ?");
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
        
        nonNulls.push(Clerk_Id)
        var sql = 'UPDATE Clerk SET ' + field_names.join(", ") + " WHERE Clerk_Id = ?"
        sql = mysql.format(sql, nonNulls);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('The clerk was not updated.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = Clerk;
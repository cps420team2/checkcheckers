'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Account(accountstuff) {
    this.accountstuff
}

Account.getAccounts = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Account';
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No accounts found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Account.getSingleAccount = function(dbname, Acc_ID, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Account WHERE Acc_Id = ?';
        sql = mysql.format(sql, [Acc_ID]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('Account not found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Account.createAccount = function(dbname, Acc_Number, F_Name, L_Name, Acc_Address, Acc_City, Acc_State, Acc_Zip, Bank_Id, Routing_Number, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'INSERT INTO Account(Acc_Number, F_Name, L_Name, Acc_Address, Acc_City, Acc_State, Acc_Zip, Bank_Id, Routing_Number) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)';
        sql = mysql.format(sql, [Acc_Number, F_Name, L_Name, Acc_Address, Acc_City, Acc_State, Acc_Zip, Bank_Id, Routing_Number]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('No account added.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Account.editAccount = function(dbname, Acc_Id, Acc_Number, F_Name, L_Name, Acc_Address, Acc_City, Acc_State, Acc_Zip, Bank_Id, Routing_Number, callback) {
    var nonNulls = [];
    var field_names = [];
    if (Acc_Number != null) {
        nonNulls.push(Acc_Number);
        field_names.push("Acc_Number = ?");
    }
    if (F_Name != null) {
        nonNulls.push(F_Name);
        field_names.push("F_Name = ?");
    }
    if (L_Name != null) {
        nonNulls.push(L_Name);
        field_names.push("L_Name = ?");
    }
    if (Acc_Address != null) {
        nonNulls.push(Acc_Address);
        field_names.push("Acc_Address = ?");
    }
    if (Acc_City != null) {
        nonNulls.push(Acc_City);
        field_names.push("Acc_City = ?");
    }
    if (Acc_State != null) {
        nonNulls.push(Acc_State);
        field_names.push("Acc_State = ?");
    }
    if (Acc_Zip != null) {
        nonNulls.push(Acc_Zip);
        field_names.push("Acc_Zip = ?");
    }
    if (Bank_Id != null) {
        nonNulls.push(Bank_Id);
        field_names.push("Bank_Id = ?");
    }
    if (Routing_Number != null) {
        nonNulls.push(Routing_Number);
        field_names.push("Routing_Number = ?");
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
        
        nonNulls.push(Acc_Id)
        var sql = 'UPDATE Account SET ' + field_names.join(", ") + " WHERE Acc_Id = ?"
        sql = mysql.format(sql, nonNulls);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('The account was not updated.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = Account;
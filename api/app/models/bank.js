'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Bank(bankstuff) {
    this.bankstuff
}

Bank.getBanks = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Bank';
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No banks found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Bank.getSingleBank = function(dbname, Bank_ID, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Bank WHERE Bank_Id = ?';
        sql = mysql.format(sql, [Bank_ID]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('Bank not found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Bank.createBank = function(dbname, Bank_Name, Country, Address, City, State, Zip, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'INSERT INTO Bank(Bank_Name, Country, Address, City, State, Zip) VALUES (?, ?, ?, ?, ?, ?)';
        sql = mysql.format(sql, [Bank_Name, Country, Address, City, State, Zip]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('No Bank added.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Bank.editBank = function(dbname, Bank_Id, Bank_Name, Country, Address, City, State, Zip, callback) {
    var nonNulls = [];
    var field_names = [];
    if (Bank_Name != null) {
        nonNulls.push(Bank_Name);
        field_names.push("Bank_Name = ?");
    }
    if (Country != null) {
        nonNulls.push(Country);
        field_names.push("Country = ?");
    }
    if (Address != null) {
        nonNulls.push(Address);
        field_names.push("Address = ?");
    }
    if (City != null) {
        nonNulls.push(City);
        field_names.push("City = ?");
    }
    if (State != null) {
        nonNulls.push(State);
        field_names.push("State = ?");
    }
    if (Zip != null) {
        nonNulls.push(Zip);
        field_names.push("Zip = ?");
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
        
        nonNulls.push(Bank_Id)
        var sql = 'UPDATE Bank SET ' + field_names.join(", ") + " WHERE Bank_Id = ?"
        sql = mysql.format(sql, nonNulls);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('The bank was not updated.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = Bank;
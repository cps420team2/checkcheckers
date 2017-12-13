'use strict';

var db = require('../config/db');

var mysql = require('mysql');

function Store(storestuff) {
    this.storestuff
}

Store.getStores = function(dbname, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Store';
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('No stores found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Store.getSingleStore = function(dbname, Store_ID, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'SELECT * FROM Store WHERE Store_Id = ?';
        sql = mysql.format(sql, [Store_ID]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.length === 0) {
                callback('Store not found.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Store.createStore = function(dbname, Store_Name, Country, Address, City, State, Zip, callback) {
    db.companydb(dbname).getConnection(function(err, connection) { 
        if (err) {
            callback(err, null);
            return;
        }

        var sql = 'INSERT INTO Store(Store_Name, Country, Address, City, State, Zip) VALUES (?, ?, ?, ?, ?, ?)';
        sql = mysql.format(sql, [Store_Name, Country, Address, City, State, Zip]);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('No store added.', null);
                return;
            }
            callback(null, data);
        });
    });
}

Store.editStore = function(dbname, Store_Id, Store_Name, Country, Address, City, State, Zip, callback) {
    var nonNulls = [];
    var field_names = [];
    if (Store_Name != null) {
        nonNulls.push(Store_Name);
        field_names.push("Store_Name = ?");
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
        
        nonNulls.push(Store_Id)
        var sql = 'UPDATE Store SET ' + field_names.join(", ") + " WHERE Store_Id = ?"
        sql = mysql.format(sql, nonNulls);
        connection.query(sql, function(error, data) {
            connection.release();
            if (error) {
                callback(error, null);
                return;
            }
            if (data.AffectedRows === 0) {
                callback('The store was not updated.', null);
                return;
            }
            callback(null, data);
        });
    });
}

module.exports = Store;
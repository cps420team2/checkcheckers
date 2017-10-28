
var mysql = require('mysql');

exports.pool = mysql.createPool({
    host: 'team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com',
    user: 'team2',
    password: 'Testpassword1',
    database: 'user'
});

exports.userdb = mysql.createPool({
    host: 'team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com',
    user: 'team2',
    password: 'Testpassword1',
    database: 'user'
});

exports.companydb = function (dbname) {
    return mysql.createPool({
        host: 'team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com',
        user: 'team2',
        password: 'Testpassword1',
        database: dbname
    });
}

/*
exports.pool = mysql.createPool({
    host: 'us-cdbr-iron-east-03.cleardb.net',
    user: 'b3f649a4be1d1f',
    password: '99ec06f4',
    database: 'heroku_75ce5480da9bd22'
});
*/
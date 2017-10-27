var express = require('express');
var router = express.Router();
var db = require('../config/db.js');
var mysql = require('mysql');

var Item = require('../models/item');
var User = require('../models/user');
var Check = require('../models/check');

/* GET home page. */
router.get('/', function (req, res, next) {  
    res.send({message:"This is the Team 2 db API!"});
});

router.post('/', function (req, res, next) {  
    res.send({message:"This is the Team 2 db API!"});
});

/*
router.get('/search', function (req, res, next) {
    Item.dosearch(req, res, function(err, obj){
        res.render('search', obj);
    });
});

router.get('/mobile_search', function (req, res, next) {
    var obj = {};
    obj.session = req.session;
    res.render('mobile_search', obj);
});

router.get('/mobile_searchresult', function (req, res, next) {
     Item.dosearch(req, res, function(err, obj){
        if (obj.mobilesearch) {
            res.redirect('/mobile_search', obj);
            return;
        }
        res.render('mobile_searchresult', obj);
    });
});

router.get('/details', function (req, res, next) {
    Item.details(req, res, function(err, obj) {
        res.render('details', obj);
    });
});

router.get('/logout', function (req, res, next) {
    req.session.login = false;
    res.redirect('search');
});

router.get('/maintain', function (req, res, next) {
    if (!req.session.login) {
        var error = {};
        error.message = 'You do not have permission to edit this book. Please Login.';
        res.render('error', error);
        return;
    }
    Item.details(req, res, function(err, obj) {
        res.render('maintain', obj);
    });
});

router.post('/maintain', function (req, res, next) {
    if (!req.session.login) {
        var error = {};
        error.message = 'You do not have permission to edit this book. Please Login.';
        res.render('error', error);
        return;
    }
    if (req.body.btnCancel) {
        res.redirect('search');
        return;
    }
    if (req.body.btnSave) {
        Item.updateRecord(req, res, function(err, data) {
            if (err) {
                res.render('maintain', data);
                return;
            }
            res.redirect('details?book_id=' + data.book.id);
        });
    }
}); 
*/

router.post('/login', function (req, res, next) {
    User.checkCred(req.body.Username, req.body.Password, function(err, success) {
        var obj = {};
        req.session.login = success;
        obj.session = req.session;
        if (err) {
            obj.error = err;
            res.send({
                success:false, 
                error:err
            });
        } else {
            res.send({
                success:true,
                error:null
            })
        }
    } );
});

router.post('/getdb', function (req, res, next) {
    User.getdb(req.body.Username, function(err, dbname){
        res.send({error:err, name:dbname});
    });
});

router.post('/getusers', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            User.getCompUsers(dbname, function(error, user_list) {
                if (user_list) {
                    res.send({error:null, users:user_list});
                } else {
                    res.send({error:error, users:null});
                }
            });
        } else {
            res.send({error:err, users:null});
        }
    });
});

router.post('/getchecks', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Check.getChecks(dbname, function(error, user_list) {
                if (user_list) {
                    res.send({error:null, checks:user_list});
                } else {
                    res.send({error:error, checks:null});
                }
            });
        } else {
            res.send({error:err, checks:null});        }
    });
});

router.post('/createcheck', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Check.createCheck(dbname, req.body.check_num, req.body.check_date, req.body.check_amount, 
                1, 1, function(error, user_list) {
                    
                if (user_list) {
                    res.send({error:null, checks:user_list});
                } else {
                    res.send({error:error, checks:null});
                }
            });
        } else {
            res.send({error:err, checks:null});        }
    });
});

module.exports = router;

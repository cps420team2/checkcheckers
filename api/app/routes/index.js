var express = require('express');
var router = express.Router();
var db = require('../config/db.js');
var mysql = require('mysql');

var Item = require('../models/item');
var User = require('../models/user');
var Check = require('../models/check');
var Store = require('../models/store');
var Clerk = require('../models/clerk');
var Bank = require('../models/bank');
var Account = require('../models/account');

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

// Check functions
router.post('/getchecks', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Check.getChecks(dbname, function(error, check_list) {
                if (check_list) {
                    res.send({error:null, checks:check_list});
                } else {
                    res.send({error:error, checks:null});
                }
            });
        } else {
            res.send({error:err, checks:null});        }
    });
});

router.post('/getsinglecheck', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Check.getSingleCheck(dbname, req.body.Check_ID, function(error, check) {
                if (check) {
                    res.send({error:null, check:check});
                } else {
                    res.send({error:error, check:null});
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
                1, 1, function(error, check) {
                    
                if (check) {
                    res.send({error:null, check:check});
                } else {
                    res.send({error:error, check:null});
                }
            });
        } else {
            res.send({error:err, check:null});
        }
    });
});

router.post('/editcheck', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Check.editCheck(dbname, req.body.check_id, req.body.check_num, req.body.check_date, req.body.check_amount, 
                req.body.clerk_id, req.body.acc_id, function(error, check) {
                    
                if (check) {
                    res.send({error:null, check:check});
                } else {
                    res.send({error:error, check:null});
                }
            });
        } else {
            res.send({error:err, check:null});
        }
    });
});

// Store functions
router.post('/getstores', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Store.getStores(dbname, function(error, store_list) {
                if (store_list) {
                    res.send({error:null, stores:store_list});
                } else {
                    res.send({error:error, stores:null});
                }
            });
        } else {
            res.send({error:err, stores:null});        }
    });
});

router.post('/getsinglestore', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Store.getSingleStore(dbname, req.body.Store_ID, function(error, store) {
                if (store) {
                    res.send({error:null, store:store});
                } else {
                    res.send({error:error, store:null});
                }
            });
        } else {
            res.send({error:err, store:null});        }
    });
});

router.post('/createstore', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Store.createStore(dbname, req.body.Store_Name, req.body.Country, req.body.Address, 
                req.body.City, req.body.State, req.body.Zip, function(error, store) {
                    
                if (store) {
                    res.send({error:null, store:store});
                } else {
                    res.send({error:error, store:null});
                }
            });
        } else {
            res.send({error:err, store:null});        }
    });
});

router.post('/editstore', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Store.editStore(dbname, req.body.Store_ID, req.body.Store_Name, req.body.Country, req.body.Address, 
                req.body.City, req.body.State, req.body.Zip, function(error, store) {
                    
                if (store) {
                    res.send({error:null, store:store});
                } else {
                    res.send({error:error, store:null});
                }
            });
        } else {
            res.send({error:err, store:null});        }
    });
});

// Clerk functions
router.post('/getclerks', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Clerk.getClerks(dbname, function(error, clerk_list) {
                if (clerk_list) {
                    res.send({error:null, clerks:clerk_list});
                } else {
                    res.send({error:error, clerks:null});
                }
            });
        } else {
            res.send({error:err, clerks:null});        }
    });
});

router.post('/getclerkswithstoreinfo', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Clerk.getClerkswithStoreInfo(dbname, function(error, clerk_list) {
                if (clerk_list) {
                    res.send({error:null, clerks:clerk_list});
                } else {
                    res.send({error:error, clerks:null});
                }
            });
        } else {
            res.send({error:err, clerks:null});        }
    });
});

router.post('/getsingleclerk', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Clerk.getSingleClerk(dbname, req.body.Clerk_ID, function(error, clerk) {
                if (clerk) {
                    res.send({error:null, clerk:clerk});
                } else {
                    res.send({error:error, clerk:null});
                }
            });
        } else {
            res.send({error:err, clerk:null});        }
    });
});

router.post('/createclerk', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Clerk.createClerk(dbname, req.body.F_Name, req.body.L_Name, req.body.Store_ID, 
                function(error, clerk) {
                    
                if (clerk) {
                    res.send({error:null, clerk:clerk});
                } else {
                    res.send({error:error, clerk:null});
                }
            });
        } else {
            res.send({error:err, clerk:null});        }
    });
});

router.post('/editclerk', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Clerk.editClerk(dbname, req.body.Clerk_ID, req.body.F_Name, req.body.L_Name, req.body.Store_ID, 
                function(error, clerk) {
                    
                if (clerk) {
                    res.send({error:null, clerk:clerk});
                } else {
                    res.send({error:error, clerk:null});
                }
            });
        } else {
            res.send({error:err, clerk:null});        }
    });
});

// Bank functions
router.post('/getbanks', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Bank.getBanks(dbname, function(error, bank_list) {
                if (bank_list) {
                    res.send({error:null, banks:bank_list});
                } else {
                    res.send({error:error, banks:null});
                }
            });
        } else {
            res.send({error:err, banks:null});        }
    });
});

router.post('/getsinglebank', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Bank.getSingleBank(dbname, req.body.Bank_ID, function(error, bank) {
                if (bank) {
                    res.send({error:null, bank:bank});
                } else {
                    res.send({error:error, bank:null});
                }
            });
        } else {
            res.send({error:err, bank:null});        }
    });
});

router.post('/createbank', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Bank.createBank(dbname, req.body.Bank_Name, req.body.Country, req.body.Address, 
                req.body.City, req.body.State, req.body.Zip, function(error, bank) {
                    
                if (bank) {
                    res.send({error:null, bank:bank});
                } else {
                    res.send({error:error, bank:null});
                }
            });
        } else {
            res.send({error:err, bank:null});        }
    });
});

router.post('/editbank', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Bank.editBank(dbname, req.body.Bank_ID, req.body.Bank_Name, req.body.Country, req.body.Address, 
                req.body.City, req.body.State, req.body.Zip, function(error, bank) {
                    
                if (bank) {
                    res.send({error:null, bank:bank});
                } else {
                    res.send({error:error, bank:null});
                }
            });
        } else {
            res.send({error:err, bank:null});        }
    });
});

// Account functions
router.post('/getaccounts', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Account.getAccounts(dbname, function(error, account_list) {
                if (account_list) {
                    res.send({error:null, accounts:account_list});
                } else {
                    res.send({error:error, accounts:null});
                }
            });
        } else {
            res.send({error:err, accounts:null});        }
    });
});

router.post('/getsingleaccount', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Account.getSingleAccount(dbname, req.body.Acc_ID, function(error, account) {
                if (account) {
                    res.send({error:null, account:account});
                } else {
                    res.send({error:error, account:null});
                }
            });
        } else {
            res.send({error:err, account:null});        }
    });
});

router.post('/createaccount', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Account.createAccount(dbname, req.body.Acc_Number, req.body.F_Name, req.body.L_Name, req.body.Acc_Address, req.body.Acc_City, 
                req.body.Acc_State, req.body.Acc_Zip, req.body.Bank_Id, req.body.Routing_Number, function(error, account) {
                    
                if (account) {
                    res.send({error:null, account:account});
                } else {
                    res.send({error:error, account:null});
                }
            });
        } else {
            res.send({error:err, account:null});        }
    });
});

router.post('/editaccount', function (req, res, next){
    User.getdb(req.body.Username, function(err, dbname){
        if (dbname) {
            Account.editAccount(dbname, req.body.Acc_ID, req.body.Acc_Number, req.body.F_Name, req.body.L_Name, req.body.Acc_Address, 
                req.body.Acc_City, req.body.Acc_State, req.body.Acc_Zip, req.body.Bank_Id, req.body.Routing_Number, 
                function(error, account) {
                    
                if (account) {
                    res.send({error:null, account:account});
                } else {
                    res.send({error:error, account:null});
                }
            });
        } else {
            res.send({error:err, account:null});        }
    });
});

module.exports = router;
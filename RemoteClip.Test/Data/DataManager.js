'use strict';

var database = require("mongodb").MongoClient;

// Connection URL
var url = 'mongodb://localhost:27017';
// Database Name
var dbName = 'myproject';
// Use connect method to connect to the 
database.connect(url, function (err, client) {
    console.log("Connected successfully to server");
    var db = client.db(dbName);
    client.close();
})
'use strict';
var debug = require('debug');
var express = require('express');
var app = express();
var HTTPserver = require('http').createServer(app);
var path = require('path');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var io = require("socket.io")(HTTPserver);
var clients = require('./routes/clients');
var logic = require('./clients/logic');
var database = require('mongodb').MongoClient;

// Connection URL
const url = 'mongodb://localhost:27017';

// Database Name
const dbName = 'myproject';

// Use connect method to connect to the 

database.connect(url, function (err, client) {

    console.log("Connected successfully to server");

    const db = client.db(dbName);

    client.close();
});


app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/api/v1', clients);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use(function (err, req, res, next) {
        res.status(err.status || 500).send({
            message: err.message,
            error: err
        });
    });
}


// production error handler
// no stacktraces leaked to user
app.use(function (err, req, res, next) {
    res.status(err.status || 500).send({
        message: err.message,
        error: {}
    });
});

// Setup server variables

app.set('port', process.env.PORT || 3000);
app.set('x-powered-by', false);

/*
var server = app.listen(app.get('port'), function () {
    console.log('Express server listening on port ' + server.address().port);
});
*/
//var listener = io.listen(server);
//listener.sockets

io.on('connection', function (socket) {

    console.log('new socket: ', socket.id);

    console.log('origins: ', io.origins());

    console.log('server path: ', io.path());

    console.log('adapter: ', io.adapter());
    
    socket.on('online', logic.ClientIsOnline, data, ack);

    /*function (sk)
    {
        console.log('received HI');
        //socket.disconnect(true);
        io.sockets.connected.volatile.binary(false).emit('hi', 'testing');
    });
    */

    socket.on('disconnect', function (reason)
    {
        console.log('socket disconnected', reason);
    });
    
    socket.on('error', (error) => {
        console.log('socket disconnected', error);
    });
}); 

HTTPserver.listen(app.get('port'), function () {
    console.log('Express server listening on port ' + HTTPserver.address().port);
});

process.on('uncaughtException', function (err) {
    console.log('Caught exception: ', err);
    console.log('Stack:', err.stack);
    
    process.exit(1);

}); 

/*
const options = {
    method: 'POST',
    uri: 'http://localhost:8910/api/v1/connect/1',    
    body: {
        foo: 'bar'
    },
    json: true
    // JSON stringifies the body automatically
}

request(options, function (err, res, body) {
    // Request was successful, use the response object at will
    console.log('body:', body);
    }).on('error', function (err) {
        // Something bad happened, handle the error
        console.log('error:', err);
    });;
*/

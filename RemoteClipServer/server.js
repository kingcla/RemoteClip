'use strict';
var http = require('http');
var port = process.env.PORT || 1337;

const server = http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    if (req.url == '/') {
        res.write('Hello Claudio\n');
        res.end();
    }    

    else if (req.url == '/apiv1/test') {
        res.write('Hello Claudio\n');
        res.end();
    }
});

server.on('connection', (socket) => {
    console.log('Socket: ', socket);
});

server.listen(port);
 
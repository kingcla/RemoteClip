'use strict';
var express = require('express');
var router = express.Router();

/* POST users listing. */
router.post('/connect/:id', function (req, res) {
    res.send(req.params.id + ' is now connected');
});

module.exports = router;
const http = require('http');
const url = require('url');

module.exports = http.createServer((req, res) => {

    if(req.method === 'GET'){
        handleGet(req, res);
    }
    else if(req.method == 'POST'){
        handlePost(req, res);
    }
    else if(req.method === 'DELETE'){
        handleDelete(req, res);
    }
    else if(req.method === 'PUT'){
        handlePut(req, res);
    }
    else{
        handleUnknown(req, res);
    }
});

var handleGet = function(req, res){

    var reservations = require('./reservations.js')

    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    if(reqUrlParts[0] === 'reservations'){
        res.statusCode = 200;
        res.setHeader('Content-Type', 'application/json');
        res.end(JSON.stringify(reservations.getAll()));
    }
    else if(reqUrlParts[0] === 'reservation'){
        var reservation = reservations.getReservation(reqUrlParts[1]);
        if(reservation){
            res.statusCode = 200;
            res.setHeader('Content-Type', 'application/json');
            res.end(JSON.stringify(reservation));
        }
        else{
            res.statusCode = 404;
            res.setHeader('Content-Type', 'text/plain');
            res.end("Not found!");
        }
    }
    else{
        handleUnknown(req, res);
    }
};

var handlePost = function(req, res){
    var reservations = require('./reservations.js')
    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    body = '';

    req.on('data', function (chunk) {
        body += chunk;
    });

    req.on('end', function () {

        postBody = JSON.parse(body);

        if(reqUrlParts[0] === 'reservations'){  
            var reservation = reservations.create(postBody);

            res.statusCode = 201;
            res.setHeader('Content-Type', 'application/json');
            res.end(JSON.stringify(reservation));
        }else{
            handleUnknown();
        }
    });
};

var handlePut = function(req, res){
    var reservations = require('./reservations.js')
    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    body = '';

    req.on('data', function (chunk) {
        body += chunk;
    });

    req.on('end', function () {

        putBody = JSON.parse(body);

        if(reqUrlParts[0] === 'reservation'){  
            var reservation = reservations.getReservation(reqUrlParts[1]);
            if(reservation){
                reservations.update(putBody, reservation.id);
                res.statusCode = 204;
                res.setHeader('Content-Type', 'text/plain');
                res.end('No content!');
            }
            else{
                var reservation = reservations.create(putBody);
                res.statusCode = 201;
                res.setHeader('Content-Type', 'text/plain');
                res.end('Created!');
            }

        }else{
            handleUnknown(req, res);
        }
    });
}

var handleDelete = function(req, res){
    var reservations = require('./reservations.js')

    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    if(reqUrlParts[0] === 'reservations'){
        res.statusCode = 204;
        res.setHeader('Content-Type', 'text/plain');
        reservations.deleteAll();
        res.end('No content!');
    }
    else if(reqUrlParts[0] === 'reservation'){
        console.log(reqUrlParts[1]);
        var status = reservations.delete(reqUrlParts[1]);
        if(status){
            res.statusCode = 204;
            res.setHeader('Content-Type', 'text/plain');
            res.end('No content!');
        }
        else{
            res.statusCode = 404;
            res.setHeader('Content-Type', 'text/plain');
            res.end("Not found!");
        }
    }
    else{
        handleUnknown(req, res);
    }
};

var handleUnknown = function(req, res){
    res.statusCode = 404;
    res.setHeader('Content-Type', 'text/plain');
    res.end('Invalid Request');
};
const http = require('http');
const url = require('url');

module.exports = http.createServer((req, res) => {

    if(req.method === 'GET'){
        handleGet(req, res);
    }
    else if(req.method == 'POST'){
        handlePost(req, res);
    }
    else if(req.method === 'PUT'){
        handlePut(req, res);
    }
    else if(req.method === 'DELETE'){
        handleDelete(req, res);
    }
    else{
        InvalidRequest(req, res);
    }
});

var handleGet = function(req, res){

    var reservations = require('./reservations.js')

    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    if(reqUrlParts[0] === 'reservations'){
        OK(req, res, reservations.getAll());
    }
    else if(reqUrlParts[0] === 'reservation'){
        var reservation = reservations.getReservation(reqUrlParts[1]);
        if(reservation){
            OK(req, res, reservation);
        }
        else{
            notFound(req, res);
        }
    }
    else{
        InvalidRequest(req, res);
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
            created(req, res, reservation);
        }else{
            InvalidRequest();
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
                noContent(req, res);
            }
            else{
                var reservation = reservations.create(putBody, reqUrlParts[1]);
                created(req, res, reservation);
            }

        }else{
            InvalidRequest(req, res);
        }
    });
}

var handleDelete = function(req, res){
    var reservations = require('./reservations.js')

    const reqUrl = url.parse(req.url, true);
    var reqUrlParts = reqUrl.pathname.split('/');
    reqUrlParts.splice(0, 1);

    if(reqUrlParts[0] === 'reservations'){
        reservations.deleteAll();
        noContent(req, res);
    }
    else if(reqUrlParts[0] === 'reservation'){
        console.log(reqUrlParts[1]);
        var status = reservations.delete(reqUrlParts[1]);
        if(status){
            noContent(req, res);
        }
        else{
            notFound(req, res);
        }
    }
    else{
        InvalidRequest(req, res);
    }
};

var OK = function(req, res, data){
    res.statusCode = 200;
    res.setHeader('Content-Type', 'application/json');
    res.end(JSON.stringify(data));
};

var notFound = function(req, res){
    res.statusCode = 404;
    res.setHeader('Content-Type', 'text/plain');
    res.end("Not found!");
};

var created = function(req, res, data){
    res.statusCode = 201;
    res.setHeader('Content-Type', 'text/plain');
    res.end(JSON.stringify(data));
};

var noContent = function(req, res){
    res.statusCode = 204;
    res.setHeader('Content-Type', 'text/plain');
    res.end('No content!');
};

var InvalidRequest = function(req, res){
    res.statusCode = 404;
    res.setHeader('Content-Type', 'text/plain');
    res.end('Invalid Request');
};
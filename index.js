const functions = require('firebase-functions');

// // Create and Deploy Your First Cloud Functions
// // https://firebase.google.com/docs/functions/write-firebase-functions
//
// exports.helloWorld = functions.https.onRequest((request, response) => {
//  response.send("Hello from Firebase!");
// });

var firebase = require("@firebase/app").default;
//require("firebase-auth");
require("@firebase/database");

var config = {
    apiKey: "AIzaSyBnJOaNXiwjaq7wbJ9mEBhrp1U_7LHT7qI",
    authDomain: "uisvr2019.firebaseapp.com",
    databaseURL: "https://uisvr2019.firebaseio.com",
    projectId: "uisvr2019",
    storageBucket: "uisvr2019.appspot.com",
    messagingSenderId: "1012079234864"
};
firebase.initializeApp(config);

function writeUserScore( game, username, score) {
    firebase.database().ref(game+'/scoreboard/' + username).set(parseInt(score));
}

function cur_delete(username) {
    firebase.database().ref('curPlayer/' + username).set(null);
}

function edit_username( game, username, newUsername, score) {
    firebase.database().ref(game +'scoreboard/' + newUsername).set(score);
    firebase.database().ref(game +'scoreboard/' + username).set(null);
}

function cur_writeUserScore(username, score) {
    firebase.database().ref('curPlayer/' + username).set(parseInt(score));
}

// Create and Deploy Your First Cloud Functions
// https://firebase.google.com/docs/functions/write-firebase-functions


exports.userentry = functions.https.onRequest((req, res) => {
    if (req.body.game !== null & req.body.username !== null & req.body.score !== null) {
        writeUserScore(req.body.game, req.body.username, req.body.score);
        cur_delete(req.body.username);
        res.send("The score was succesfullly recived");
    } else {
        res.send(":(");
    }
});

exports.cur_userentry = functions.https.onRequest((req, res) => {
    if (req.body.game !== null, req.body.username !== null & req.body.score !== null) {
        cur_writeUserScore(req.body.game, req.body.username, req.body.score);
        res.send("The score was succesfullly recived");
    } else {
        res.send(":(");
    }
});

exports.edit_userentry = functions.https.onRequest((req, res) => {
    if (req.body.game !== null & req.body.username !== null && req.body.newUsername !== null && req.body.score !== null) {
        edit_username(req.body.game, req.body.username, req.body.newUsername, req.body.score);
        res.send("The entry was succesfully edited!");
    } else {
        res.send(":(")
    }
});
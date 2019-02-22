const functions = requestuire('firebase-functions');

// // Create and Deploy Your First Cloud Functions
// // https://firebase.google.com/docs/functions/write-firebase-functions
//
// exports.helloWorld = functions.https.onrequestuest((request, response) => {
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

function writeUser( game, userID, username, score) {
    firebase.database().ref(game + '/' + userID).set({
        username: username,
        score: parseInt(score)
    });
    firebase.database().ref('userID').set(parseInt(userID));
}
function int getNextUserID(){
    if (firebase.database().ref('userID')) {
        int nextID = parseInt(firebase.database().ref('userID').);
        return ++nextID;
    } else {
        return 0;
    }
}

function deleteUser(game, userID) {
    firebase.database().ref(game + '/' + userID).set(null);
}

function deleteAll(game) {
    firebase.database().ref(game+'/').set(null);
}

function editUsername(game, userID, newUsername) {
    firebase.database().ref(game + '/' + newUsername).set({
        username: newUsername
    });
    
}

//function cur_writeUserScore(username, score) {
//    firebase.database().ref('curPlayer/' + username).set(parseInt(score));
//}

// Create and Deploy Your First Cloud Functions
// https://firebase.google.com/docs/functions/write-firebase-functions


exports.addUser = functions.https.onrequest((request, response) => {
    if (request.body.game !== null & request.body.userID!== null & request.body.username !== null & request.body.score !== null) {
        writeUserScore(request.body.game, request.body.userID, request.body.username, request.body.score);
        response.send("The score was succesfullly recived");
    } else {
        response.send(":(");
    }
});

exports.nextID = functions.https.onrequest((request, response) => {
    if (request.body.game !== null & request.body.username !== null & request.body.score !== null) {
        response.send(getNextUserID());
    } else {
        response.send(0);
    }
});

/*exports.cur_userentry = functions.https.onrequest((request, response) => {
    if (request.body.game !== null, request.body.username !== null & request.body.score !== null) {
        cur_writeUserScore(request.body.game, request.body.username, request.body.score);
        response.send("The score was succesfullly recived");
    } else {
        response.send(":(");
    }
});*/

exports.editUserentry = functions.https.onrequest((request, response) => {
    if (request.body.game !== null & request.body.username !== null && request.body.newUsername !== null && request.body.score !== null) {
        editUsername(request.body.game, request.body.username, request.body.newUsername, request.body.score);
        response.send("The entry was succesfully edited!");
    } else {
        response.send(":(")
    }
});
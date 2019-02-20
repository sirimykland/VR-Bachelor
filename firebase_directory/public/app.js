import { user } from 'firebase-functions/lib/providers/auth';

const functions = require('firebase-functions');
var firebase = require("@firebase/app").default;
require("firebase-auth");
require("@firebase/database");

// Leave out Storage
//require("firebase/storage");
// Initialize Firebase
var config = {
    apiKey: "AIzaSyBnJOaNXiwjaq7wbJ9mEBhrp1U_7LHT7qI",
    authDomain: "uisvr2019.firebaseapp.com",
    databaseURL: "https://uisvr2019.firebaseio.com",
    projectId: "uisvr2019",
    storageBucket: "uisvr2019.appspot.com",
    messagingSenderId: "1012079234864"
};
firebase.initializeApp(config);

const btnLogin = document.getElementById('btnLogin');
const btnLogout = document.getElementById('btnLogout');
const txtEmail = document.getElementById('txtEmail');
const txtPass = document.getElementById('txtPass');

// TODO: set timer in unity

btnLogin.addEventListener('click', e => {
  const email = txtEmail.value;
  const pass = txtPass.value;
  const auth = firebase.auth();
  const promise = auth.signInWithEmailAndPassword(email,pass);
  promise.catch(e => console.log(e.message));
});


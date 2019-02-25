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

const btnLogin = document.getElementById("login");
const txtUsername = document.getElementById("username");
const txtPassword = document.getElementById("password");

btnLogin.addEventListener('click', e => {
    const username = txtUsername.value;
    const password = txtPassword.value;
    const auth = firebase.auth();
    const promise = auth.signInWithEmailAndPassword(username,password);
    promise.catch(e => console.log(e.message));
});

firebase.auth().onAuthStateChanged(user => {
    if (user) {
        location.href = "./admin.html";
    } else {
        console.log("logged out!")
    }
});
// Initialize Firebase
var fb_apiKey = getParameterByName("apiKey");
var fb_authDomain = getParameterByName("authDomain");
var fb_dbURL = getParameterByName("dbURL");
var fb_storage = getParameterByName("storage");

var config = {
    apiKey: fb_apiKey,
    authDomain: fb_authDomain,
    databaseURL: fb_dbURL,
    storageBucket: fb_storage,
};
firebase.initializeApp(config);

function initApp(vwg_FormId) {
    if (!vwg_FormId) return;
    firebase.auth().onAuthStateChanged(function (user) {
        var jsonUser;
        if (user) {
            // user is signed in
            jsonUser = JSON.stringify(user);
        } else {
            // user is signed out
            jsonUser = "";
        }
        // callback to VWG server
        if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
        var eventType = "initApp";
        var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
        VWG.Events.SetEventAttribute(objEvent, 'Value', jsonUser);
        VWG.Events.RaiseEvents();
    })
}

function isSignedIn(vwg_FormId) {
    firebase.auth().onAuthStateChanged(function (user) {
        var jsonUser;
        if (user) {
            // user is signed in
            jsonUser = JSON.stringify(user);
        } else {
            // user is signed out
            jsonUser = "";
        }
        // callback to VWG server
        if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
        var eventType = "isSignedIn";
        var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
        VWG.Events.SetEventAttribute(objEvent, 'Value', jsonUser);
        VWG.Events.RaiseEvents();
    })
}

function signOut(vwg_FormId) {
    firebase.auth().signOut();
    if (!vwg_FormId) return;
    // callback to VWG server
    if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
    var eventType = "signOut";
    var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
    VWG.Events.SetEventAttribute(objEvent, 'Value', '');
    VWG.Events.RaiseEvents();
}

function signInWithEmail(vwg_FormId, vwg_Email, vwg_Password) {
    firebase.auth().signInWithEmailAndPassword(vwg_Email, vwg_Password).then(function (result) {
        var jsonAuth = JSON.stringify(result);
        // callback to VWG server
        if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
        var eventType = "signInWithEmail";
        var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
        VWG.Events.SetEventAttribute(objEvent, 'Value', jsonAuth);
        VWG.Events.RaiseEvents();
    }).catch(function (error) {
        signInFailed(vwg_FormId);
    })
}

function signInWithGoogle(vwg_FormId) {
    var provider = new firebase.auth.GoogleAuthProvider();
    provider.addScope('https://www.googleapis.com/auth/plus.login');
    firebase.auth().signInWithPopup(provider).then(function (result) {
        var jsonAuth = JSON.stringify(result);
        if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
        var eventType = "signInWithGoogle";
        var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
        VWG.Events.SetEventAttribute(objEvent, 'Value', jsonAuth);
        VWG.Events.RaiseEvents();
        //alert("Sign in 成功");
    }).catch(function (error) {
        // singin failed
        alert("Sign in failed");
    })
}

function signInWithFacebook(vwg_FormId) {
    var provider = new firebase.auth.FacebookAuthProvider();
    provider.addScope('user_birthday');
    firebase.auth().signInWithPopup(provider).then(function (result) {
        var jsonAuth = JSON.stringify(result);
        if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
        var eventType = "signInWithFacebook";
        var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
        VWG.Events.SetEventAttribute(objEvent, 'Value', jsonAuth);
        VWG.Events.RaiseEvents();
    }).catch(function (error) {
        // singin failed
        alert("Sign in failed");
    })
}

function signInFailed(vwg_FormId) {
    if (typeof (VWG) == 'undefined' || VWG == null || VWG.Events == null) return;
    var eventType = "signInFailed";
    var objEvent = VWG.Events.CreateEvent(vwg_FormId, eventType);
    VWG.Events.SetEventAttribute(objEvent, 'Value', jsonAuth);
    VWG.Events.RaiseEvents();
}

window.onload = function () {
    //initApp();
    signOut();
};

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


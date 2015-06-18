"use strict";

// Create user profile service
app.factory('UserProfileService', ['$http', function ($http) {

    var getUser = function () {
        return $http.get('/api/User/GetUser', { cache: false });
    }

    var addUser = function (userName, password) {
        var user = {
            userName: userName,
            password: password
        }

        return $http.post('/api/User/AddUser', user);
    }

    var signIn = function (userName, password) {

        var user = {
            userName: userName,
            password: password
        }

        return $http.post('/api/User/SignIn', user);
    }

    var signOut = function () {
        return $http.post('/api/User/SignOut');
    }

    var getConnectionStatus = function () {
        return $http.get('/api/User/GetStatus');
    }

    return {
        GetUser: getUser,
        AddUser: addUser,
        SignIn: signIn,
        SignOut: signOut,
        GetConnectionStatus: getConnectionStatus
    }
}]);
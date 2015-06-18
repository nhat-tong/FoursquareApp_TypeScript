"use strict";

// Create user connection service for sign in and sign out
app.service('UserConnectionService', ['$rootScope', function ($rootScope) {

    this.SignIn = function (userName) {
        $rootScope.$broadcast('SignIn', { "userName": userName });
    }
}]);
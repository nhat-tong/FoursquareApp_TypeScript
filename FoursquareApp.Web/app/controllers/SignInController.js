"use strict";

// Create new controller
app.controller('SignInController', ['$scope', 'toaster', 'UserProfileService', '$location', '$route', 'UserConnectionService', function ($scope, toaster, UserProfileService, $location, $route, UserConnectionService) {

    $scope.userName = '';
    $scope.password = '';
    $scope.formError = '';

    $scope.signIn = function () {
        UserProfileService.SignIn($scope.userName, $scope.password)
            .success(function (data, status) {
                toaster.pop('success', '', 'User Signed in successfully');
                $scope.signUpForm.userName.$valid = true;
                $scope.signUpForm.password.$valid = true;

                UserConnectionService.SignIn($scope.userName);

                $location.path('/places');
            })
            .error(function (data, status) {
                $scope.signUpForm.userName.$invalid = true;
                $scope.signUpForm.password.$invalid = true;
                $scope.formError = 'Your user name or password is invalid';
            });
    }
}]);
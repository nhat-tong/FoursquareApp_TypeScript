"use strict";

// Create login directive
// Attention: AngularDirective Name is CamelCase
app.directive('loginDirective', function () {

    var loginController = ['$scope', 'UserProfileService', function ($scope, UserProfileService) {

        UserProfileService.GetConnectionStatus()
                          .success(function (data, status) {
                              if (data != '') {
                                  $scope.IsConnected = true;
                                  $scope.userName = data;
                              }
                              else {
                                  $scope.IsConnected = false;
                              }
                          })
                            .error(function (err, status) { });

        $scope.$on('SignIn', function (event, args) {
            $scope.IsConnected = true;
            $scope.userName = args.userName;
        });

        $scope.signOut = function () {
            UserProfileService.SignOut()
            .success(function () {
                $scope.IsConnected = false;
            })
            .error(function (err, status) { });
        }
    }]

    return {
        restrict: 'EA',
        scope: {},
        templateUrl: 'app/views/login.html',
        controller: loginController,
        link: function (scope, element, attrs) {
        }
    }
});
"use strict";

// Create a user profile controller
app.controller('UserProfileController', ['$scope', '$modalInstance', 'UserProfileService', 'PlaceDataService', 'item', function ($scope, $modalInstance, UserProfileService, PlaceDataService, item) {

    $scope.userName = '';
    $scope.password = '';

    $scope.close = function () {
        $modalInstance.close('close');
    }

    $scope.save = function () {
        // Add a new user
        UserProfileService.AddUser($scope.userName, $scope.password)
        .success(function (data, status) {
            // Insert place with UserName to db
            PlaceDataService.InsertPlace(item, $scope.userName);
            $modalInstance.close('close');
        })
        .error(function (data, status) {
        });
    }
}]);
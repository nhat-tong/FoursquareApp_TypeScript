// Create VenueModalPhotoController
'use strict';

app.controller('ModalPhotoController', ['$scope', '$modalInstance', 'photo', function ($scope, $modalInstance, photo) {
    $scope.venueName = photo.venueName;
    $scope.items = photo.items;

    $scope.buildVenuePhoto = function (item) {
        return item.prefix + '256' + item.suffix;
    }

    $scope.close = function () {
        $modalInstance.dismiss('dismiss');
    }
}]);
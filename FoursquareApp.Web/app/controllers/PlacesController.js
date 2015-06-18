// Create PlacesController
'use strict';

app.controller('PlacesController', ['$scope', 'PlaceDataService', 'toaster', function ($scope, PlaceDataService, toaster) {
    //TODO
    $scope.myPlaces = [];
    $scope.totalPlaceCount = 0;
    $scope.userName = '';
    $scope.pageSize = 5;
    $scope.maxSize = 5;
    $scope.currentPage = 1;

    init();

    function init() {
        PlaceDataService.GetPlaces()
        .success(function (data) {
            pushData(data);
        })
        .error(function (err, status) {
        });
    }

    function pushData(data) {
        var arr = [];

        // calculate pagignation list
        $scope.totalPlaceCount = data.length; //total-items

        if (data.length > 0) {
            $scope.userName = data[0].userName;

            for (var i = 0; i < data.length; ++i) {
                if (i < $scope.pageSize) {
                    arr.push(data[i]);
                }
            }
        }

        $scope.myPlaces = arr;
    }

    $scope.pageChanged = function () {
        var offset = $scope.pageSize * ($scope.currentPage - 1);

        PlaceDataService.GetPlacesPagination(offset, $scope.pageSize)
        .success(function (data) {
            $scope.myPlaces = data;
        })
        .error(function (err, status) {
        });
    }

    $scope.delete = function (id, userName) {
        PlaceDataService.DeletePlace(id, userName)
        .success(function (data, status) {

            // recalculate the pagignation list with new data array
            pushData(data);

            // recalculate the number of element of current page
            $scope.pageChanged();

            toaster.pop('success', '', 'This place have been removed sucessfully from your bookmark');
        })
        .error(function (data, status) {
            toaster.pop('error', '', 'Please try again');
        });
    }

}]);
"use strict";
// Create ExploreController
app.controller('ExploreController', ['$scope', 'PlaceExploreService', 'PlacePhotoService', 'PlaceDataService', 'UserProfileService', '$filter', 'cfpLoadingBar', '$modal', 'toaster', function ($scope, PlaceExploreService, PlacePhotoService, PlaceDataService, UserProfileService, $filter, cfpLoadingBar, $modal, toaster) {
    $scope.exploreNearBy = 'New York';
    $scope.exploreCategory = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.places = [];
    $scope.filteredPlaces = [];
    $scope.filteredPlaceCount = 0;
    $scope.totalResultCount = 0;
    $scope.placeFilter = '';
    $scope.maxSize = 5;

    init();

    function init() {
        getPlaces();
        doFilter('');
    }

    // Get places function
    function getPlaces() {
        var offset = ($scope.pageSize) * ($scope.currentPage - 1);

        PlaceExploreService.get({ near: $scope.exploreNearBy, query: $scope.exploreCategory, limit: $scope.pageSize, offset: offset }, function (placesResult) {
            if (placesResult.response.groups) {
                $scope.places = placesResult.response.groups[0].items;
                $scope.totalResultCount = placesResult.response.totalResults;
                doFilter('');
            }
            else {
                $scope.places = [];
                $scope.totalResultCount = 0;
                $scope.filteredPlaceCount = 0;
            }
        });
    }

    // Filter Place function
    function doFilter(filterInput) {
        $scope.filteredPlaces = $filter('PlaceCategoryFilter')($scope.places, filterInput);
        $scope.filteredPlaceCount = $scope.filteredPlaces.length;
    }

    // Create watch on place filter
    $scope.$watch('placeFilter', function (filterInput) {
        doFilter(filterInput);
    });

    $scope.doSearch = function () {
        getPlaces();
    }

    $scope.buildCategoryIcon = function (icon) {
        return icon.prefix + '44' + icon.suffix;
    }

    $scope.buildVenueThumbnail = function (firstGroup) {
        return firstGroup.items[0].prefix + '128' + firstGroup.items[0].suffix;
    }

    $scope.showVenuePhotos = function (id, name) {

        PlacePhotoService.get({ venueId: id }, function (photosResult) {
            var modalInstance = $modal.open({
                templateUrl: 'app/views/modalPhoto.html',
                controller: 'ModalPhotoController',
                resolve: {
                    photo: function () {
                        return {
                            venueName: name,
                            items: photosResult.response.photos.items
                        }
                    }
                }
            });
        });
    }

    $scope.bookmarkPlace = function (item) {

        UserProfileService.GetUser()
                .success(function (data, status) {
                    // Open UserProfile Modal
                    var modalInstance = $modal.open({
                        templateUrl: 'app/views/modalUserProfile.html',
                        controller: 'UserProfileController',
                        resolve: {
                            item: function () {
                                return item
                            }
                        }
                    });
                })
                .error(function (data, status, headers) {// error
                    if (status == 304) {
                        // Get data from headers
                        var header = headers();
                        // User existed, not open UserProfile Modal
                        PlaceDataService.InsertPlace(item, header.username);
                    }
                });;
    }

    $scope.pageChanged = function () {
        getPlaces();
    }

    $scope.SignIn = function () {
        // Open UserProfile Modal
        var modalInstance = $modal.open({
            templateUrl: 'app/views/modalSignIn.html',
            controller: 'UserProfileController',
            resolve: {
                item: function () {
                    return item
                }
            }
        });
    }
}]);
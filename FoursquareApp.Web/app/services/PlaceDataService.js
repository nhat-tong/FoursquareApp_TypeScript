/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../Scripts/typings/angularjs-toaster/angularjs-toaster.d.ts" />
"use strict";
var PlaceDataService = (function () {
    // constructeur par defaut
    function PlaceDataService($http, toaster) {
        this.$http = $http;
        this.toaster = toaster;
    }
    // create instance of PlaceDataService
    PlaceDataService.Factory = function ($http, toaster) {
        return new PlaceDataService($http, toaster);
    };
    PlaceDataService.prototype.GetPlaces = function () {
        return this.$http.get('/api/Place');
    };
    PlaceDataService.prototype.GetPlacesPagination = function (offset, pageSize) {
        return this.$http.get('/api/Place', { params: { "index": offset, "count": pageSize } });
    };
    PlaceDataService.prototype.InsertPlace = function (item, userName) {
        var _this = this;
        var obj = {
            id: item.id,
            userName: userName,
            name: item.name,
            address: item.location.address,
            category: item.categories[0].shortName,
            rating: item.rating
        };
        //lamda expression for callback function IPromise
        this.$http.post('/api/Place', obj)
            .then(function (response) {
            _this.toaster.pop('success', "", "This place have been added successfully to bookmark");
        }, function (err) {
            if (err.status == 304) {
                _this.toaster.pop('info', "", "This place have already bookmarked");
            }
            else {
                _this.toaster.pop('error', "", err.data);
            }
        });
    };
    PlaceDataService.prototype.DeletePlace = function (id, userName) {
        return this.$http.delete('/api/Place', { params: { "id": id, "userName": userName } });
    };
    // DI
    PlaceDataService.$inject = ['$http', 'toaster'];
    return PlaceDataService;
})();
// add an instance of PlaceDataService to FoursquareApp angular module
angular.module('FoursquareApp').factory('PlaceDataService', PlaceDataService.Factory);
//# sourceMappingURL=PlaceDataService.js.map
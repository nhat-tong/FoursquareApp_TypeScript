/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../Scripts/typings/angularjs-toaster/angularjs-toaster.d.ts" />

"use strict";

class PlaceDataService {

    // DI
    public static $inject = ['$http', 'toaster'];

    // constructeur par defaut
    constructor(private $http: ng.IHttpService, private toaster: ngtoaster.IToasterService) {
    }

    // create instance of PlaceDataService
    static Factory($http: ng.IHttpService, toaster: ngtoaster.IToasterService) {
        return new PlaceDataService($http, toaster);
    }

    public GetPlaces() : ng.IPromise<any> {
        return this.$http.get('/api/Place');
    }

    public GetPlacesPagination(offset, pageSize) : ng.IPromise<any> {
        return this.$http.get('/api/Place', { params: { "index": offset, "count": pageSize } });
    }

    public InsertPlace(item, userName) {
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
            .then(response => {
            this.toaster.pop('success', "", "This place have been added successfully to bookmark")
        },
                  err => {
                           if (err.status == 304) {
                            this.toaster.pop('info', "", "This place have already bookmarked");
                             }
                            else {
                            this.toaster.pop('error', "", err.data);
                            }
                  });
    }

    public DeletePlace(id, userName) {
        return this.$http.delete('/api/Place', { params: { "id": id, "userName": userName } });
    }
}

// add an instance of PlaceDataService to FoursquareApp angular module
angular.module('FoursquareApp').factory('PlaceDataService', PlaceDataService.Factory);
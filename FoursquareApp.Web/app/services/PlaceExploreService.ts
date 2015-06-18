/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />

"use strict";

class PlaceExploreService {
    // Request credentials of Foursquare API
    public requestParams = {
        clientId: "DO5JJHGXBODWHZUZ2W45T0S35PKJH3MCLC1SKF5U4X3VF4YA",
        clientSecret: "GF0PDCNGEKSU2GI4ANGBGBKTEUU0G3E3QYPO5YWFXRV33GY5",
        version: "20131230"
    }

    public requestUri: string = 'https://api.foursquare.com/v2/venues/:action';

    static $inject = ['$resource'];

    constructor(private $resource: ng.resource.IResourceService) {
    }

    public getAction: ng.resource.IActionDescriptor = {
        url: this.requestUri,
        params: {        action: 'explore',
        client_id: this.requestParams.clientId,
        client_secret: this.requestParams.clientSecret,
        v: this.requestParams.version,
        venuePhotos: '1',
        callback: 'JSON_CALLBACK'},
        method: 'JSONP'
    }

    static Factory($resource: ng.resource.IResourceService) {
        return $resource(this.prototype.requestUri,
            {
                action: 'explore',
                client_id: this.prototype.requestParams.clientId,
                client_secret: this.prototype.requestParams.clientSecret,
                v: this.prototype.requestParams.version,
                venuePhotos: '1',
                callback: 'JSON_CALLBACK'
            },
            {
                get: { method: 'JSONP' }
            });
    }
} 

angular.module('FoursquareApp').factory('PlaceExploreService', PlaceExploreService.Factory);
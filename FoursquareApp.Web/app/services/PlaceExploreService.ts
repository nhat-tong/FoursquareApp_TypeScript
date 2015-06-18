/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />

"use strict";

class PlaceExploreService {

    // Attention with static variables
    // Call these variables using class name: PlaceExploreService
    // It doesn't work with this keyworks
    static requestParams: any = {
        clientId: "DO5JJHGXBODWHZUZ2W45T0S35PKJH3MCLC1SKF5U4X3VF4YA",
        clientSecret: "GF0PDCNGEKSU2GI4ANGBGBKTEUU0G3E3QYPO5YWFXRV33GY5",
        version: "20131230"
    }
    static requestUri: string = 'https://api.foursquare.com/v2/venues/:action';

    static $inject = ['$resource'];

    constructor(private $resource: ng.resource.IResourceService) {
    }

    // don't create instance of PlaceExploreService
    // return data of Foursquare API using $resource
    public static Factory($resource: ng.resource.IResourceService) {
        return $resource(PlaceExploreService.requestUri,
            {
                action: 'explore',
                client_id: PlaceExploreService.requestParams.clientId,
                client_secret: PlaceExploreService.requestParams.clientSecret,
                v: PlaceExploreService.requestParams.version,
                venuePhotos: '1',
                callback: 'JSON_CALLBACK'
            },
            {
                get: { method: 'JSONP' }
            });
    }
} 

angular.module('FoursquareApp').factory('PlaceExploreService', PlaceExploreService.Factory);
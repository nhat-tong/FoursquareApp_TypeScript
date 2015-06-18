/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />

"use strict"; 

class PlacePhotoService {

    private static requestParams: any = {
        clientId: "DO5JJHGXBODWHZUZ2W45T0S35PKJH3MCLC1SKF5U4X3VF4YA",
        clientSecret: "GF0PDCNGEKSU2GI4ANGBGBKTEUU0G3E3QYPO5YWFXRV33GY5",
        version: "20131230"
    };

    private static requestUri: string = 'https://api.foursquare.com/v2/venues/:venueId/:action';

    static $inject = ['$resource'];

    constructor(private $resource: ng.resource.IResourceService) {
    }

    public static Factory($resource: ng.resource.IResourceService) {
        return $resource(PlacePhotoService.requestUri,
            {
                action: 'photos',
                client_id: PlacePhotoService.requestParams.clientId,
                client_secret: PlacePhotoService.requestParams.clientSecret,
                v: PlacePhotoService.requestParams.version,
                limit: '9',
                callback: 'JSON_CALLBACK'
            },
            {
                get: { method: 'JSONP' }
            });
    }
}

angular.module('FoursquareApp').factory('PlacePhotoService', PlacePhotoService.Factory);
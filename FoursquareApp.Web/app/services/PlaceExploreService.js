/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
"use strict";
var PlaceExploreService = (function () {
    function PlaceExploreService($resource) {
        this.$resource = $resource;
    }
    // don't create instance of PlaceExploreService
    // return data of Foursquare API using $resource
    PlaceExploreService.Factory = function ($resource) {
        return $resource(PlaceExploreService.requestUri, {
            action: 'explore',
            client_id: PlaceExploreService.requestParams.clientId,
            client_secret: PlaceExploreService.requestParams.clientSecret,
            v: PlaceExploreService.requestParams.version,
            venuePhotos: '1',
            callback: 'JSON_CALLBACK'
        }, {
            get: { method: 'JSONP' }
        });
    };
    // Attention with static variables
    // Call these variables using class name: PlaceExploreService
    // It doesn't work with this keyworks
    PlaceExploreService.requestParams = {
        clientId: "DO5JJHGXBODWHZUZ2W45T0S35PKJH3MCLC1SKF5U4X3VF4YA",
        clientSecret: "GF0PDCNGEKSU2GI4ANGBGBKTEUU0G3E3QYPO5YWFXRV33GY5",
        version: "20131230"
    };
    PlaceExploreService.requestUri = 'https://api.foursquare.com/v2/venues/:action';
    PlaceExploreService.$inject = ['$resource'];
    return PlaceExploreService;
})();
angular.module('FoursquareApp').factory('PlaceExploreService', PlaceExploreService.Factory);
//# sourceMappingURL=PlaceExploreService.js.map
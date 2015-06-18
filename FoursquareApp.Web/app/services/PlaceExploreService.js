/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
"use strict";
var PlaceExploreService = (function () {
    function PlaceExploreService($resource) {
        this.$resource = $resource;
        // Request credentials of Foursquare API
        this.requestParams = {
            clientId: "DO5JJHGXBODWHZUZ2W45T0S35PKJH3MCLC1SKF5U4X3VF4YA",
            clientSecret: "GF0PDCNGEKSU2GI4ANGBGBKTEUU0G3E3QYPO5YWFXRV33GY5",
            version: "20131230"
        };
        this.requestUri = 'https://api.foursquare.com/v2/venues/:action';
        this.getAction = {
            url: this.requestUri,
            params: { action: 'explore',
                client_id: this.requestParams.clientId,
                client_secret: this.requestParams.clientSecret,
                v: this.requestParams.version,
                venuePhotos: '1',
                callback: 'JSON_CALLBACK' },
            method: 'JSONP'
        };
    }
    PlaceExploreService.Factory = function ($resource) {
        return $resource(this.prototype.requestUri, {
            action: 'explore',
            client_id: this.prototype.requestParams.clientId,
            client_secret: this.prototype.requestParams.clientSecret,
            v: this.prototype.requestParams.version,
            venuePhotos: '1',
            callback: 'JSON_CALLBACK'
        }, {
            get: { method: 'JSONP' }
        });
    };
    PlaceExploreService.$inject = ['$resource'];
    return PlaceExploreService;
})();
angular.module('FoursquareApp').factory('PlaceExploreService', PlaceExploreService.Factory);
//# sourceMappingURL=PlaceExploreService.js.map
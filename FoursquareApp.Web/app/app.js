'use strict';

// Create main module of application
var app = angular.module('FoursquareApp', ['ngResource', 'ngRoute', 'ui.bootstrap', 'angular-loading-bar', 'toaster']);

// Foursquare Routing
app.config(['$locationProvider', '$routeProvider', 'cfpLoadingBarProvider', function ($locationProvider, $routeProvider, cfpLoadingBarProvider) {
    $routeProvider
        .when('/explore', {
            controller: "ExploreController",
            templateUrl: "app/views/explore.html"
        })
        .when('/places', {
            controller: "PlacesController",
            templateUrl: "app/views/myplaces.html"
        })
        .when('/about', {
            controller: "AboutController",
            templateUrl: "app/views/about.html"
        })
        .when('/signin', {
            controller: "SignInController",
            templateUrl: "app/views/signIn.html"
        })
        .otherwise({ redirectTo: "/explore" });

    cfpLoadingBarProvider.includeSpinner = true;
    cfpLoadingBarProvider.includeBar = true;
    cfpLoadingBarProvider.latencyThreshold = 100;
    // use the HTML5 History API
    $locationProvider.html5Mode(true);
}]);
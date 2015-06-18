// Create a filter for Place Name or Category
'use strict';

app.filter('PlaceCategoryFilter', [function () {
    return function (places, placeFilter) {

        // If don't have filter, return places
        if (!placeFilter) return places;

        var matches = [];
        placeFilter = placeFilter.toLowerCase();

        for (i = 0; i < places.length; ++i)
        {
            var place = places[i];

            // If PlaceName or CategoryName contains filter
            if (place.venue.name.toLowerCase().indexOf(placeFilter) > -1 ||
                place.venue.categories[0].shortName.toLowerCase().indexOf(placeFilter) > -1) {

                matches.push(place);
            }
        }

        return matches;
    };
}]);
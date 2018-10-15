﻿    
var map, client, datasource, popup;

function GetMap() {
    //Add your Azure Maps subscription key to the map SDK. Get an Azure Maps key at https://azure.com/maps
    atlas.setSubscriptionKey('dzeFyndWBQ-iqPo_8KRkeU-0ENIezkqh3HXDzmSrn_Y');
    //Initialize a map instance.
    map = new atlas.Map('myMap');

    //Wait until the map resources have fully loaded.
    map.events.add('load', function (e) {
        //Create an instance of the services client.
        client = new atlas.service.Client(atlas.getSubscriptionKey());

        //Create a data source and add it to the map.
        datasource = new atlas.source.DataSource();
        map.sources.add(datasource);

        //Add a layer for rendering the results as symbols.
        var resultsLayer = new atlas.layer.SymbolLayer(datasource);
        map.layers.add(resultsLayer);

        //Create a popup but leave it closed so we can update it and display it later.
        popup = new atlas.Popup({
            position: [0, 0],
            pixelOffset: [0, -18]
        });

        //Add a click event to the results symbol layer.
        map.events.add('click', resultsLayer, symbolClicked);
    });
}

function closePopup() {
    popup.close();
}

function search(userLatitude, userLongitude) {
    var query = document.getElementById('input').value;

    //Remove any previous results from the map.
   // datasource.clear();

    client.search.getSearchFuzzy(query, {
        lat: userLatitude,
        lon: userLongitude,
        radius: 100000,
    }).then(response => {
        //Parse the response into GeoJSON that the map can understand.
        var geojsonResponse = new atlas.service.geojson.GeoJsonSearchResponse(response);
        var geojsonResults = geojsonResponse.getGeoJsonResults();

        //Add the results to the data source.
        datasource.add(geojsonResults);

        //Set the camera to the bounds of the results.
        map.setCamera({
            bounds: geojsonResults.bbox,
            padding: 40
        });
    });
}

function searchWithUserLocation() {
    //Using the HTML5 geolocation API, request the users location from the browser, this will display a prompt to the user to share their location.
    navigator.geolocation.getCurrentPosition(function (position) {
        //Pass in the user location into the search.
        search(position.coords.latitude, position.coords.longitude);
    }, function (error) {
        //If unable to get the users location, fall back to a search without their location information.
        search();
    });
}

function symbolClicked(e) {
    //Make sure the event occured on a point feature.
    if (e.shapes && e.shapes.length > 0 && e.shapes[0].getType() === 'Point') {
        var properties = e.shapes[0].getProperties();

        //Using the properties, create HTML to fill the popup with useful information.
        var html = ['<div style="padding:10px;"><span style="font-size:14px;font-weight:bold;">'];
        var addressInTitle = false;

        if (properties.type === 'POI' && properties.poi && properties.poi.name) {
            html.push(properties.poi.name);
        } else if (properties.address && properties.address.freeformAddress) {
            html.push(properties.address.freeformAddress);
            addressInTitle = true;
        }

        html.push('</span><br/>');

        if (!addressInTitle && properties.address && properties.address.freeformAddress) {
            html.push(properties.address.freeformAddress, '<br/>');
        }

        html.push('<b>Type: </b>', properties.type, '<br/>');

        if (properties.entityType) {
            html.push('<b>Entity Type: </b>', properties.entityType, '<br/>');
        }

        if (properties.type === 'POI' && properties.poi) {
            if (properties.poi.phone) {
                html.push('<b>Phone: </b>', properties.poi.phone, '<br/>');
            }

            if (properties.poi.url) {
                html.push('<b>URL: </b>', properties.poi.url, '<br/>');
            }

            if (properties.poi.classifications) {
                html.push('<b>Classifications:</b><br/>');
                for (var i = 0; i < properties.poi.classifications.length; i++) {
                    for (var j = 0; j < properties.poi.classifications[i].names.length; j++) {
                        html.push(' - ', properties.poi.classifications[i].names[j].name, '<br/>');
                    }
                }
            }

        }

        html.push('</div>');

        //Set the popup options.
        popup.setPopupOptions({
            //Update the content of the popup.
            content: html.join(''),

            //Update the position of the popup with the pins coordinate.
            position: e.shapes[0].getCoordinates()
        });

        //Open the popup.
        popup.open(map);
    }
}
GetMap();
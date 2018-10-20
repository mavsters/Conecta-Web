$().ready(function () {
    //Variables Main
    var key_map = 'dzeFyndWBQ-iqPo_8KRkeU-0ENIezkqh3HXDzmSrn_Y';
    var map, controls = [];
    //Position Matta Sur  
    var lon = -33.459696810494876;
    var lat = -70.63834840000004;
    //Positions
    var startPosition;
    var endPosition = [lat, lon];
    //Start
    setVariables();
    startMaps();
    

    function setVariables() {
        //Add your Azure Maps subscription key to the map SDK. Get an Azure Maps key at https://azure.com/maps
        atlas.setSubscriptionKey(key_map);
        //Initialize a map instance.
        map = new atlas.Map('myMap');
        
    }

    function startMaps() {

        //Wait until the map resources have fully loaded.map.events.add('load', function (e) {//Start Process//Create a HTML marker and add it to the map.marker = new atlas.HtmlMarker({htmlContent: '<div class="pulse"></div>',position: endPosition});map.markers.add(marker);//setPositionInitEndMiddle();//setText();});
        map.events.add('load', function (e) {
            //Request the user's location
            navigator.geolocation.getCurrentPosition(function (position) {
                //Add the users position to the data source.
                var userPosition = [position.coords.longitude, position.coords.latitude];
                //Add a layer for rendering the users position as a symbol.
                var startPoint = new atlas.data.Feature(new atlas.data.Point(userPosition), {
                    title: 'Start'
                });
                var endPoint = new atlas.data.Feature(new atlas.data.Point(endPosition), {
                    title: 'End'
                });

                //Calculate a geodesic path between the two points (line that follows curvature of the earth).
                var path = atlas.math.getGeodesicPath([userPosition, endPosition]);
                var poly = new atlas.data.LineString(path);
                //Calculate the midpoint of the line.
                var midPoint = atlas.math.interpolate(userPosition, endPosition);
                var pin = new atlas.data.Feature(new atlas.data.Point(midPoint), {
                    title: 'Midpoint'
                });

                //Create a data source and add it to the map.
                var datasource = new atlas.source.DataSource();
                map.sources.add(datasource);
                //Add the data to the data source.
                datasource.add([poly, startPoint, endPoint, pin]);
                
                map.layers.add([
                    //Add a layer for rendering line data.
                    new atlas.layer.LineLayer(datasource, null, {
                        strokeColor: 'red',
                        strokeWidth: 4,
                        filter: ['==', '$type', 'LineString']
                    }),
                    //Add a layer for rendering point data.
                    new atlas.layer.SymbolLayer(datasource, null, {
                        iconOptions: {
                            allowOverlap: true,
                            ignorePlacement: true
                        },
                        textOptions: {
                            textField: ['get', 'title'],
                            offset: [0, 1]
                        },
                        filter: ['==', '$type', 'Point']
                    })
                ]);

                //Calculate the distance from the northWest coordinate to the southEast coordinate. //kilometres //miles
                var distance = atlas.math.getDistanceTo(userPosition, endPosition, 'kilometres');
                //Calculate the heading from the northWest coordinate to the southEast coordinate.
                var heading = atlas.math.getHeading(userPosition, endPosition);
                document.getElementById('outputPanel').innerHTML = 'Tu Ubicación:<br/>Lat: ' + userPosition[0] + '<br/>Lon: ' + userPosition[1] + '<hr/>' +
                    'Ubicación del Ex-Asilo: <br />Lat: ' + endPosition[0] + ' <br /> Lon: ' + endPosition[1] + ' <hr />' + 'Distancia: ' + distance + ' kilometres<br/>Heading: ' + heading + ' degrees';


            }, function (error) {
                //If an error occurs when trying to access the users position information, display an error message.
                switch (error.code) {
                    case error.PERMISSION_DENIED:
                        alert('User denied the request for Geolocation.');
                        break;
                    case error.POSITION_UNAVAILABLE:
                        alert('Position information is unavailable.');
                        break;
                    case error.TIMEOUT:
                        alert('The request to get user position timed out.');
                        break;
                    case error.UNKNOWN_ERROR:
                        alert('An unknown error occurred.');
                        break;
                }
                });

            });
    }

});
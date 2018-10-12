materialKitDemo = {

    initContactUsMap: function () {
        var lat = -33.459696810494876;
        var long = -70.63834840000004;
        var myLatlng = new google.maps.LatLng(lat, long);
        var mapOptions = {
            zoom: 14,
            center: myLatlng,
            styles:
                [{ "featureType": "water", "stylers": [{ "saturation": 43 }, { "lightness": -11 }, { "hue": "#0088ff" }] }, { "featureType": "road", "elementType": "geometry.fill", "stylers": [{ "hue": "#ff0000" }, { "saturation": -100 }, { "lightness": 99 }] }, { "featureType": "road", "elementType": "geometry.stroke", "stylers": [{ "color": "#808080" }, { "lightness": 54 }] }, { "featureType": "landscape.man_made", "elementType": "geometry.fill", "stylers": [{ "color": "#ece2d9" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "color": "#ccdca1" }] }, { "featureType": "road", "elementType": "labels.text.fill", "stylers": [{ "color": "#767676" }] }, { "featureType": "road", "elementType": "labels.text.stroke", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "poi", "stylers": [{ "visibility": "off" }] }, { "featureType": "landscape.natural", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#b8cb93" }] }, { "featureType": "poi.park", "stylers": [{ "visibility": "on" }] }, { "featureType": "poi.sports_complex", "stylers": [{ "visibility": "on" }] }, { "featureType": "poi.medical", "stylers": [{ "visibility": "on" }] }, { "featureType": "poi.business", "stylers": [{ "visibility": "simplified" }] }],
            scrollwheel: false, //we disable de scroll over the map, it is a really annoing when you scroll through page
        };
        var map = new google.maps.Map(document.getElementById("contactUsMap"), mapOptions);

        var marker = new google.maps.Marker({
            position: myLatlng,
            title: "Hello World!"
        });
        marker.setMap(map);
    },

    initContactUs2Map: function () {
        $(function () {
            var lat = -33.459696810494876;
            var long = -70.63834840000004;
            var mapOptions = {
                zoom: 18,
                center: { lat: lat - 0.0002, lng: long - 0.001 },
                styles: [
                    {
                        "featureType": "poi", "stylers": [{ "visibility": "off" }]
                    }
                ],
                height: 100,
                scrollwheel: false, //we disable de scroll over the map, it is a really annoing when you scroll through page
                disableDefaultUI: true,
            };
            var map = new google.maps.Map(document.getElementById("contactUs2Map"), mapOptions);


            var marker = new google.maps.Marker({
                map: map,
                draggable: true,
                animation: google.maps.Animation.DROP,
                position: { lat: lat, lng: long },
            });
            marker.setAnimation(google.maps.Animation.BOUNCE);


        });
    },
    markArea: function () {
        $(function () {
            var rectangle = new google.maps.Rectangle({
                strokeColor: '#F000',
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: '#FF0000',
                fillOpacity: 0.35,
                map: map,
                bounds: {
                    north: lat + 0.0022,
                    south: lat - 0.001,
                    east: long + 0.001,
                    west: long - 0.001,
                }
            });
        });
    },
     presentationAnimations: function(){
         $(function() {

           var $window           = $(window),
               isTouch           = Modernizr.touch;

           if (isTouch) { $('.add-animation').addClass('animated'); }

           $window.on('scroll', revealAnimation);

           function revealAnimation() {
             // Showed...
             $(".add-animation:not(.animated)").each(function () {
               var $this     = $(this),
                   offsetTop = $this.offset().top,
                   scrolled = $window.scrollTop(),
                   win_height_padded = $window.height();
               if (scrolled + win_height_padded > offsetTop) {
                   $this.addClass('animated');
               }
             });
             // Hidden...
            $(".add-animation.animated").each(function (index) {
               var $this     = $(this),
                   offsetTop = $this.offset().top;
                   scrolled = $window.scrollTop(),
                   windowHeight = $window.height();

                   win_height_padded = windowHeight * 0.8;
               if (scrolled + win_height_padded < offsetTop) {
                 $(this).removeClass('animated')
               }
             });
           }

           revealAnimation();
         });

     }
};
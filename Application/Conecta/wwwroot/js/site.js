WebFontConfig = { google: { families: ['Roboto|Roboto+Slab|Material+Icons'] } };
(function () {
    var wf = document.createElement('script');
    wf.src = '//ajax.googleapis.com/ajax/libs/webfont/1.5.18/webfont.js';
    wf.type = 'text/javascript';
    wf.async = 'true';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(wf, s);
    //Icons
    var host = window.location.host;
    $('head').append('<link rel="stylesheet" href="//' + host +'/css/font.css" type="text/css" />');
})();
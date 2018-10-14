WebFontConfig = { google: { families: ['Roboto|Roboto+Slab|Material+Icons'] } };
$(function () {
    var wf = document.createElement('script');
    wf.src = '//ajax.googleapis.com/ajax/libs/webfont/1.5.18/webfont.js';
    wf.type = 'text/javascript';
    wf.async = 'true';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(wf, s);
    //Icons
    var host = window.location.host;
    $('head').append('<link rel="stylesheet" href="//' + host + '/css/font.css" type="text/css" />');
    //YouTube
    $("div[id^=video]").click(function () {
        var idcaja = $(this).attr("id");
        console.log(idcaja);
        var idvideo = $("#" + idcaja + " img").attr("src").split("/")[4];
        var ytvideo = "<iframe src='https://www.youtube.com/embed/" + idvideo + "?rel=0&autoplay=1' frameborder='0' allowfullscreen></iframe>";
        $("#" + idcaja).addClass("vacio");
        document.getElementById($(this).attr("id")).innerHTML = ytvideo;
    });
});
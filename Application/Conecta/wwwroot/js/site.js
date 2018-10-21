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
function showfile(content, url) {
    var urlMain = "/" + url;
    //<object data="~/docs/memoria-grafica/julio/mattasur-conecta.pdf" type='application/pdf' frameborder='0' style='overflow: hidden;position: relative;overflow-x: hidden;overflow-y: hidden;height: -webkit-fill-available;width: 100%;' height='100%' width='100%'></object>
    var contentTemp = "<object data='" + urlMain +"' type='application/pdf' frameborder='0' style='overflow: hidden;position: relative;overflow-x: hidden;overflow-y: hidden;height: -webkit-fill-available;width: 100%;' height='100%' width='100%'></object>";
    document.getElementById("content-" + content).innerHTML = contentTemp;
}

function addReplaceLangCode(url, langCode) {
    var a = document.createElement('a');
    a.href = url; // or document.location.href;

    var paths = a.pathname.split('/');
    paths.shift();

    if (paths[0].length == 2) {
        paths[0] = langCode;
    } else {
        paths.unshift(langCode);
    }
    var newURL =  a.protocol + '//' +
        a.host + '/' + paths.join('/') +
        (a.search != '' ? a.search : '') +
        (a.hash != '' ? a.hash : '');
    window.location.href = newURL;
}


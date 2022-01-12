var winWidth = 0;
var winHeight = 0;
var topcss = 0;
var leftcss = 0;

$(document).ready(function () {

    winWidth = $(window).width();
    winHeight = $(window).height();

    winWidth = (parseInt(winWidth) * 50) / 100;
    winHeight = (parseInt(winHeight) * 50) / 100;

    topcss = parseInt(winHeight) / 2;
    leftcss = parseInt(winWidth) / 2;

    $('.popcontent').width(winWidth);
    //$('.popcontent').height(winHeight);
    $('.popcontent').css("top", topcss);
    $('.popcontent').css("left", leftcss - 50);

    $(".closebtn").click(function () {
        $(".popcontent").fadeOut();
        $(".popbg").fadeOut();
    });

    $(".closebtn2").click(function () {
        $(".popcontent").fadeOut();
        $(".popbg").fadeOut();
    });

    //$(".popbg").click(function () {
    //    $(".popcontent").fadeOut();
    //    $(".popbg").fadeOut();
    //});

});

window.onload = function () {

    //result.state = granted, prompt, denied
    //ask times chrome - 4, edge - 4, mozilla - unlimited
    navigator.permissions.query({ name: 'geolocation' }).then(function (result) {
        $('#hfPermission').val(result.state);
        CheckState(result.state);
    });

    $('#hfBrowser').val(navigator.saysWho);

};

function CheckState(pstate) {

    $(".popcontent").hide();
    $(".popbg").hide();

    var ckstatus = $('#hfLcFound').val();

    if (pstate == "prompt") {
        GetGeoLocation();
    }
    else if (pstate == "granted") {
        if (ckstatus == 0) {
            GetGeoLocation();
        }
    }
    else if (pstate == "denied") {
        detectBrowser();
    }
}

function GetGeoLocation() {

    if ("geolocation" in navigator) {

        var startPos;

        var geoOptions = {
            enableHighAccuracy: true
        }

        var geoSuccess = function (position) {
            startPos = position;

            var lat = startPos.coords.latitude;
            var lng = startPos.coords.longitude;

            $('#hfLat').val(lat);
            $('#hfLon').val(lng);

            getAddress(lat, lng);
        };

        var geoError = function (error) {
            //console.log('Error occurred. Error code: ' + error.code);
            // error.code can be:
            //   0: unknown error
            //   1: permission denied
            //   2: position unavailable (error response from location provider)
            //   3: timed out
            $('#hfLcType').val(2);
            //ipLookUp();
        };

        navigator.geolocation.getCurrentPosition(geoSuccess, geoError, geoOptions);
    }
    else {
        //geolocation is not supported
        $('#hfLcType').val(2);
        //ipLookUp();
    }

}

function ipLookUp() {
    $('#hfLcType').val(2);
    $.ajax('http://ip-api.com/json?fields=61439') //259065
        .then(
            function success(response) {

                var latitude = response.lat;
                var longitude = response.lon;

                $('#hfLat').val(latitude);
                $('#hfLon').val(longitude);

                var address = response.city + '-' + response.zip + ', ' + response.regionName; // + ', ' + response.countryCode;
                $('#hfLocResponse').val(JSON.stringify(response));
                $('#hfLocation').val(address);
                $('#hfLcType').val(2);
            },

            function fail(data, status) {
                $('#hfLocResponse').val(JSON.stringify(response));
                $('#hfLocation').val('Not Found 2.0');
            }
        );
}

function getAddress(latitude, longitude) {

    var GOOGLE_MAP_KEY = 'AIzaSyCuYEQogqF3cTj_f8oj-eM3YabPaF57js4';
    $.ajax('https://maps.googleapis.com/maps/api/geocode/json?location_type=APPROXIMATE&latlng=' + latitude + ',' + longitude + '&key=' + GOOGLE_MAP_KEY)
        .then(
            function success(response) {
                if (response.results.length > 0) {
                    var myAddress = [];
                    for (i = 0; i < response.results.length; i++) {
                        myAddress[i] = response.results[i].formatted_address;
                        var address = myAddress[0];
                        $('#hfLcType').val(1);
                        $('#hfLocResponse').val(JSON.stringify(response));
                        $('#hfLocation').val(address);

                        break;
                    }
                }
                else {
                    $('#hfLcType').val(2);
                    //ipLookUp();
                    //$('#hfLocation').val(response.error_message + '-' + response.status);
                }
            },
            function fail(status) {
                $('#hfLcType').val(2);
                //ipLookUp();
                // $('#hfLocation').val(response.error_message + '-' + response.status);
            }
        )
}

function detectBrowser() {

    if (navigator.saysWho.indexOf("Chrome") != -1) {
        $("#chrome").css("display", "block");
        $(".popcontent").fadeIn();
        $(".popbg").fadeIn();
    } else if (navigator.saysWho.indexOf("Firefox") != -1) {
        $("#firefox").css("display", "block");
        $(".popcontent").fadeIn();
        $(".popbg").fadeIn();
    } else if (navigator.saysWho.indexOf("Edge") != -1 || (!!document.documentMode == true)) {
        $("#edge").css("display", "block");
        $(".popcontent").fadeIn();
        $(".popbg").fadeIn();
    }
    else {
        $("#other").css("display", "block");
        $(".popcontent").fadeIn();
        $(".popbg").fadeIn();
        //alert('Unable to get your location. Location is required to access this website. Please allow location access from the browser Address bar > Site settings and try again.');
    }
}

navigator.saysWho = (() => {
    const { userAgent } = navigator
    let match = userAgent.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || []
    let temp

    if (/trident/i.test(match[1])) {
        temp = /\brv[ :]+(\d+)/g.exec(userAgent) || []

        return `IE ${temp[1] || ''}`
    }

    if (match[1] === 'Chrome') {
        temp = userAgent.match(/\b(OPR|Edge)\/(\d+)/)

        if (temp !== null) {
            return temp.slice(1).join(' ').replace('OPR', 'Opera')
        }

        temp = userAgent.match(/\b(Edg)\/(\d+)/)

        if (temp !== null) {
            return temp.slice(1).join(' ').replace('Edg', 'Edge (Chromium)')
        }
    }

    match = match[2] ? [match[1], match[2]] : [navigator.appName, navigator.appVersion, '-?']
    temp = userAgent.match(/version\/(\d+)/i)

    if (temp !== null) {
        match.splice(1, 1, temp[1])
    }

    return match.join(' ')
})()
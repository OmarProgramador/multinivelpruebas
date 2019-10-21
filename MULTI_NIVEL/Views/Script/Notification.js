
var userName = "";
var params="";


window.onload = function () {
  //  alert("Jiji");
    //document.getElementById("u_0_h").innerHTML = '<span>jejeje</span>';
    
  //  var userName = getParameterByName('Key');
     userName = encodeURI(document.cookie);
     params = "Key=" + userName;
    Send('NotificationC', userName, Http);
    //Send('CurrentPointsC', params, Http2);
    
}


function Http() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var parameters = '' + httpRequest.responseText;
            var tableFromBDD = parameters.split('$')[0].split('&')[0];
            var tableFromBDD2 = parameters.split('$')[1];
            var quantity = parameters.split('$')[0].split('&')[1];
            if (quantity >= 1) {
                document.getElementById('quantity').innerHTML = quantity.toString();
                document.getElementById('globo').style.display = 'block';
            }
            document.getElementById('u_0_h').innerHTML = tableFromBDD + tableFromBDD2;
            //Send('CurrentPointsC', params, Http2);
        }
    }
}


function Http2() {

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            var parameters = '' + httpRequest.responseText;
            document.getElementById('glob').innerHTML = '<br/>' + '<br/>' + '<span style="color:white; font-size:19px; ">' + parameters.split('|')[1] + ' </span>' +
                '<br/>' + '<span style="color:white; font-size:25px; font-weight: bold;">' + parameters.split('|')[0] + ' ' + 'pts' + ' </span>'
            document.getElementById('lblRankVolume').innerHTML = parameters.split('|')[0] + ' ' + 'pts';
        }
    }
}
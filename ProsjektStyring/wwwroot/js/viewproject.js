
function getHourStats(id) {
    var request = new XMLHttpRequest();
    request.open('GET', '../GetLogForLastHourAsync/' + id, true);

    request.onload = function () {
        if (request.status >= 200 && request.status < 400) {
            // Success!
            var data = JSON.parse(request.responseText);

            TempH = new Array(); HumH = new Array(); UpdH = new Array();
            for (i = 0; i < data.length; i++) {
                TempH.push(data[i].temperature);
                HumH.push(data[i].humidity);
                var b = data[i].update_time.split("T");
                var t = b[1].split(".");
                UpdH.push(t[0]);
            }
            console.log(data.hour);
            draw_hourlyGraph(TempH, HumH, UpdH);
        } else {
            // We reached our target server, but it returned an error

        }
    };

    request.onerror = function () {
        // There was a connection error of some sort
    };

    request.send();
}
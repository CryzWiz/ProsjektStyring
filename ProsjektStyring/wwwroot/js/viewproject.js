// Tests
function TestApi() {
    var request = new XMLHttpRequest();
    request.open('GET', '../api/Project/TestAPI/', true);

    request.onload = function () {
        if (request.status >= 200 && request.status < 400) {
            // Success!
            var data = JSON.parse(request.responseText);
            console.log(data);
        } else {
            // We reached our target server, but it returned an error
            console.log("damn!We didnt get a successfull result...");
        }
    };

    request.onerror = function () {
        // There was a connection error of some sort
        console.log("connection error in TestApi()!");
    };

    request.send();
}



// Helpers
function addCycle() {
    var user = document.getElementById("NCreatedBy").value;
    var cname = document.getElementById("NCycleName").value;
    var cdescription = document.getElementById("NCycleDescription").value;
    var sd = document.getElementById("NPStart").value;
    var ed = document.getElementById("NPSlutt").value;
    var pid = document.getElementById("NProjectId").value;
    AddProjectCycle(user, pid, cname, cdescription, sd, ed);
}




// API-calls
function AddProjectCycle(u, pid, cn, cd, sd, ed) {
    var request = new XMLHttpRequest();
    var data = {
        "projectId" : pid,
        "user" : u,
        "cycleName" : cn,
        "cycleDescription" : cd,
        "startDate" : sd,
        "endDate" : ed
    };
    request.open('POST', '../api/Project/AddProjectCycle/', true);
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    request.send(JSON.stringify(data));
    request.onreadystatechange = function () { // Call a function when the state changes.
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            // Request finished. Do processing here.
            var res = JSON.parse(request.responseText);
            console.log(res);
        }
    };
    request.onerror = function () {
        // There was a connection error of some sort
        console.log("connection error in TestApi()!");
    };
}
function AddProjectComment() {
    var request = new XMLHttpRequest();
    request.open('GET', '../api/Project/AddProjectComment/', true);

    request.onload = function () {
        if (request.status >= 200 && request.status < 400) {
            // Success!
            var data = JSON.parse(request.responseText);
            console.log(data);


        } else {
            // We reached our target server, but it returned an error
            console.log("damn!We didnt get a successfull result...");
        }
    };

    request.onerror = function () {
        // There was a connection error of some sort
        console.log("connection error in TestApi()!");
    };

    request.send();
}
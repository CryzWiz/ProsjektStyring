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
    request.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            // Request finished. Do processing here.
            var res = JSON.parse(request.responseText);
            console.log("AddProjectCycle: " + request.responseText);
            // Lets insert the new cycle to our cycletable
            // create a new row
            var table = document.getElementById("CT");
            var row = table.insertRow(res.cycleNumber);
            var cell1 = row.insertCell(0); var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2); var cell4 = row.insertCell(3);
            var cell5 = row.insertCell(4); var cell6 = row.insertCell(5);
            var cell7 = row.insertCell(6);
            // create node for all the new cells
            var cNum = document.createTextNode(res.cycleNumber);
            var cName = document.createTextNode(res.cycleName);
            var cDesc = document.createTextNode(res.cycleDescription);
            var cSd = document.createTextNode(res.cyclePlannedStart);
            var cEd = document.createTextNode(res.cyclePlannedEnd);
            var a = res.cycleActive ? "Åpen" : "Stengt";
            var cA = document.createTextNode(a);
            var link = document.createElement('a');
            var linkText = document.createTextNode("Detaljer");
            link.appendChild(linkText);
            link.title = "Detaljer";
            link.href = "ViewProjectCycle/" + res.unique_CycleIdString;
            // append the new cell content
            cell1.appendChild(cNum); cell2.appendChild(cName);
            cell3.appendChild(cDesc); cell4.appendChild(cSd);
            cell5.appendChild(cEd); cell6.appendChild(cA);
            cell7.appendChild(link);


        }
        else {
            // We reached our target server, but it returned an error
            console.log("damn!We didnt get a successfull result from AddProjectCycle()...");
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


        }
        else {
            // We reached our target server, but it returned an error
            console.log("damn!We didnt get a successfull result from AddProjectComment()...");
        }
    };
    request.onerror = function () {
        // There was a connection error of some sort
        console.log("connection error in TestApi()!");
    };

    request.send();
}
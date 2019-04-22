// Helpers
function addCycleTask() {
    var tn = document.getElementById("newTaskName").value;
    var td = document.getElementById("newTaskDescription").value;
    var tp = document.getElementById("newTaskPlannedHours").value;
    var tdue = document.getElementById("newTaskDueDate").value;
    var user = document.getElementById("newTaskCreatedBy").value;
    var pid = document.getElementById("newTaskProjectCycleId").value;
    AddProjectCycleTask(user, pid, tn, td, tp, tdue);
}

function addComment() {
    var user = document.getElementById("CommentMadeBy").value;
    var ch = document.getElementById("CommentHeadline").value;
    var ct = document.getElementById("CommentText").value;
    var pid = document.getElementById("CProjectCycleId").value;
    AddProjectComment(user, pid, ch, ct);
}




// API-calls
function AddProjectCycleTask(u, pid, tn, td, tp, tdue) {
    var request = new XMLHttpRequest();
    var data = {
        "projectCycleId": pid,
        "user": u,
        "cycleTTaskName": tn,
        "cycleTaskDescription": td,
        "plannedHours": tp,
        "dueDate": tdue
    };
    request.open('POST', '../api/Project/AddProjectCycleTask/', true);
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
            var cell5 = row.insertCell(4);
            // create node for all the new cells
            var tName = document.createTextNode(res.taskName);
            var tDesc = document.createTextNode(res.taskDescription);
            var tDue = document.createTextNode(res.taskDusedDate);
            var a = res.taskCompleted ? "Åpen" : "Stengt";
            var tStat = document.createTextNode(a);
            var link = document.createElement('a');
            var linkText = document.createTextNode("Detaljer");
            link.appendChild(linkText);
            link.title = "Detaljer";
            link.href = "ViewProjectCycleTask/" + res.unique_CycleTaskIdString;
            // append the new cell content
            cell1.appendChild(tName); cell2.appendChild(tDesc);
            cell3.appendChild(tDue); cell4.appendChild(tStat);
            cell5.appendChild(link);


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
function AddProjectComment(u, pid, ch, ct) {
    var request = new XMLHttpRequest();
    var data = {
        "projectCycleId": pid,
        "user": u,
        "commentHeading": ch,
        "comment": ct
    };

    request.open('POST', '../api/Project/AddProjectCycleComment/', true);
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    request.send(JSON.stringify(data));

    request.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            // Request finished. Do processing here.
            var res = JSON.parse(request.responseText);
            console.log("AddProjectComment: " + request.responseText);
            // Get the div holding all the comments
            var commentDiv = document.getElementById("pComments");
            // create a new card - outer card class
            var card = document.createElement('div');
            card.classList.add('card', 'mb-3');
            // create card body
            var cardBody = document.createElement('div');
            cardBody.className = "card-body";
            // create card title
            var cTitle = document.createElement('h5');
            cTitle.className = "card-title";
            var cTitleText = document.createTextNode(res.commentHeading);
            cTitle.appendChild(cTitleText);
            // create card text
            var cText = document.createElement('p');
            cText.className = "card-text";
            var cTextText = document.createTextNode(res.comment);
            cText.appendChild(cTextText);
            // create sub-text
            var csText = document.createElement('p');
            csText.className = "card-text";
            var csSmall = document.createElement('small');
            csSmall.className = "text-muted";
            var csTextText = document.createTextNode(res.commentRegistered + ' - ' + res.byUser);
            csSmall.appendChild(csTextText);
            csText.appendChild(csSmall);
            // putt it all togheter
            cardBody.appendChild(cTitle);
            cardBody.appendChild(cText);
            cardBody.appendChild(csText);
            card.appendChild(cardBody);
            commentDiv.appendChild(card);
        }
    };
    request.onerror = function () {
        // There was a connection error of some sort
        console.log("connection error in TestApi()!");
    };
}
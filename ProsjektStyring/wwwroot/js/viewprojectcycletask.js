// Helpers
function addComment() {
    var user = document.getElementById("CommentMadeBy").value;
    var ch = document.getElementById("CommentHeadline").value;
    var ct = document.getElementById("CommentText").value;
    var pid = document.getElementById("CCycleTaskId").value;
    AddProjectCycleTaskComment(user, pid, ch, ct);
}


function AddProjectCycleTaskComment(u, pid, ch, ct) {
    var request = new XMLHttpRequest();
    var data = {
        "projectCycleTaskId": pid,
        "user": u,
        "commentHeading": ch,
        "comment": ct
    };

    request.open('POST', '../../api/Project/AddProjectCycleTaskComment/', true);
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
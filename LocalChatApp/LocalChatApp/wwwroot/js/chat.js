"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (username, message) {
    var dt = document.createElement("dt");
    var dd = document.createElement("dd");

    document.getElementById("messagesList").appendChild(dt);
    document.getElementById("messagesList").appendChild(dd);

    dt.textContent = username + ":";
    dd.textContent = message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let username = document.getElementById("usernameInput").value;
    let message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", username, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    $.ajax({
        type: "GET",
        data: { "username": username, "message": message }
    });
});
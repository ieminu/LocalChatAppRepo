let editButton = document.getElementById("editButton");

editButton.addEventListener("click", function (event) {
    document.getElementById("chatMode").style.display = "none";
    document.getElementById("editUsernameMode").style.display = "block";

    event.preventDefault();
});
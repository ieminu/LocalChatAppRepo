let editButton = document.getElementById("editButton");

editButton.addEventListener("click", function (event) {
    editButton.style.display = "none";
    document.getElementById("editUsername").style.display = "block";

    event.preventDefualt();
})
function commentRemoved() {
    alert("The comment has been removed");
};

var text = document.getElementById("testText1").textContent;
var textArea = document.getElementsByClassName("textWrite1");
var i = 0
setInterval(function () {
    textArea[0].textContent = text.slice(0, i++)
    if (i === text.length)
        document.getElementById("testText1").style.textAlign = "center";
}, 50);
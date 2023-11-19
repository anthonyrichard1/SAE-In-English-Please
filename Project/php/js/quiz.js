var currentQuestion = 0;
var score = 0;

function validateAndNext(correct) {
    if (correct) score++;
    nextQuestion();
}


function nextQuestion() {
    var currentQuestionDiv = document.getElementById("question" + currentQuestion);
    currentQuestionDiv.style.display = "none";

    currentQuestion++;

    if (currentQuestion < len) {
        var nextQuestionDiv = document.getElementById("question" + currentQuestion);
        nextQuestionDiv.style.display = "block";
    }
    else alert("Quiz terminé. Votre score est de " + score + "/" + len);
}

window.onload = function () {
    var firstQuestionDiv = document.getElementById("question0");
    firstQuestionDiv.style.display = "block";
};
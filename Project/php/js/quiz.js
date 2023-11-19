var currentQuestion = 0;
var score = 0;


function nextQuestion() {
    var currentQuestionDiv = document.getElementById("question" + currentQuestion);
    currentQuestionDiv.style.display = "none";

    currentQuestion++;
    if (currentQuestion < len) {
        var nextQuestionDiv = document.getElementById("question" + currentQuestion);
        nextQuestionDiv.style.display = "block";
    } else {
        // Toutes les questions ont été posées, afficher le score
        alert("Quiz terminé. Votre score est de " + score + "/" + len);
    }
}

function validateAndNext() {

    var currentForm = document.getElementById("quizForm" + currentQuestion);
    var selectedAnswer = currentForm.querySelector('input[name="answer' + currentQuestion + '"]:checked');

    if (selectedAnswer) {
        // L'utilisateur a sélectionné une réponse
        if (selectedAnswer.classList.contains("correct")) {
            // C'est la bonne réponse, augmenter le score
            score++;
        }
        // Passer à la question suivante
        nextQuestion();
    } else {
        // Aucune réponse sélectionnée, afficher un message d'erreur
        alert("Veuillez sélectionner une réponse avant de passer à la question suivante.");
    }
}

window.onload = function () {
    var firstQuestionDiv = document.getElementById("question0");
    firstQuestionDiv.style.display = "block";
};
var currentQuestion = 0;
var currentScore = 0;

function validateAndNext(correct) {
    if (correct) currentScore++;
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
    else{
        alert()
        let form = document.createElement('form');
        form.method = 'post';
        form.action = 'resultatsQuiz';

        let score = document.createElement('input');
        score.type = 'hidden';
        score.name = 'score';
        score.value = currentScore;

        let total = document.createElement('input');
        total.type = 'hidden';
        total.name = 'total';
        total.value = len;



        form.appendChild(score);
        form.appendChild(total);
        document.body.appendChild(form);

        form.submit();
    }
}

window.onload = function () {
    var firstQuestionDiv = document.getElementById("question0");
    firstQuestionDiv.style.display = "block";
};
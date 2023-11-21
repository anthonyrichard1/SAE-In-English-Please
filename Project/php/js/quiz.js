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
    else{
        window.location.href = 'resultatsJeux';
        var form = document.createElement('form');
        form.method = 'post';
        form.action = 'resultatsJeux';

        var input = document.createElement('input');
        input.type = 'hidden';
        input.name = 'score';
        input.value = score + '/20';

        form.appendChild(input);
        document.body.appendChild(form);

        form.submit();
    }
}

window.onload = function () {
    var firstQuestionDiv = document.getElementById("question0");
    firstQuestionDiv.style.display = "block";
};
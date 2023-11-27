document.addEventListener('DOMContentLoaded', function () {
    var cards = document.querySelectorAll('.card');
    var nbCard = 0;
    var word1;
    var word2;
    var clickEnabled = true;
    var score = 500;

    cards.forEach(function (card) {
        card.addEventListener('click', function () {
            if(clickEnabled === false || card.dataset.word === word1 || card.classList.contains('found')){
                return;
            }
            card.classList.toggle('flipped');
            nbCard += 1;
            if (nbCard === 1) {
                word1 = card.dataset.word;
            } else if (nbCard === 2) {
                word2 = card.dataset.word;
            }

            if (nbCard === 2) {
                clickEnabled = false;
                if (checkForMatch(word1, word2) === true) {
                    cards.forEach(function (card) {
                        if (card.dataset.word === word1 || card.dataset.word === word2) {
                            card.classList.add('found');
                            card.removeEventListener('click', null); // Remove click event listener
                        }
                    });
                    setTimeout(function () {
                        cards.forEach(function (card) {
                            if (card.dataset.word === word1 || card.dataset.word === word2) {
                                card.classList.add('invisibleFound');
                                card.removeEventListener('click', null); // Remove click event listener
                            }
                        });
                        checkGameCompletion(); // Check if all pairs are found
                        clickEnabled = true;
                    }, 2000);
                } else {
                    cards.forEach(function (card) {
                        if (!card.classList.contains('found') && (card.dataset.word === word1 || card.dataset.word === word2)) {
                            card.classList.add('wrong');
                        }
                    });
                    setTimeout(function () {
                        cards.forEach(function (card) {
                            if (!card.classList.contains('found') && (card.dataset.word === word1 || card.dataset.word === word2)) {
                                card.classList.toggle('flipped');
                                card.classList.remove('wrong');
                            }
                        });
                        clickEnabled = true;
                    }, 1500);
                }
                nbCard = 0;
            }
        });
    });

    function checkForMatch(word1, word2) {
        for (let i = 0; i < pairs.length; i++) {
            const pair = pairs[i];
            if (
                (pair[0] === word1 && pair[1] === word2) ||
                (pair[0] === word2 && pair[1] === word1)
            ) {
                return true;
            }
        }
        if(score !== 0){
            score-=5;
        }
        return false;
    }

    function checkGameCompletion(){
        if (document.querySelectorAll('.card.found').length === cards.length) {
            window.location.href = 'resultatsJeux';
            var form = document.createElement('form');
            form.method = 'post';
            form.action = 'resultatsMemory';

            var input = document.createElement('input');
            input.type = 'hidden';
            input.name = 'score';
            input.value = score;

            form.appendChild(input);
            document.body.appendChild(form);

            form.submit();
        }
    }
});
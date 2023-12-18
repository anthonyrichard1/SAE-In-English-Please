<?php

namespace controller;

use config\Validation;
use gateway\TranslationGateway;
use gateway\VocabularyListGateway;
use model\MdlStudent;
use model\MdlTeacher;
use model\MdlUser;
use Exception;

class VisitorController
{
    public function memory(): void
    {
        global $twig;
        global $user;

        try {
            $idVoc = Validation::filter_int($_GET['idVoc'] ?? 4);
            $wordList = (new MdlTeacher())->findByIdVoc($idVoc);
            $name = ((new MdlStudent())->getVocabById($idVoc))->getName();
            $wordShuffle = array();

            shuffle($wordList);
            $pairs = [];
            $maxWords = 28;

            for ($i = 0; $i < min(count($wordList), $maxWords / 2); $i++) {
                $wordShuffle[] = $word1 = $wordList[$i]->getWord1();
                $wordShuffle[] = $word2 = $wordList[$i]->getWord2();

                $pairs[] = [$word1, $word2];
            }


            shuffle($wordShuffle);

            if (isset($user)) {
                echo $twig->render('memory.html', [
                    'wordShuffle' => $wordShuffle,
                    'pairs' => json_encode($pairs),
                    'name' => $name,
                    'userID' => $user->getID(),
                    'userRole' => $user->getRoles()
                ]);
            } else {
                echo $twig->render('memory.html', [
                    'wordShuffle' => $wordShuffle,
                    'pairs' => json_encode($pairs),
                    'name' => $name
                ]);
            }

        } catch (Exception $e) {
            throw new Exception($e->getMessage());
        }
    }
    public function quiz(): void
    {
        global $twig;
        global $user;

        try {
            $vocabId = Validation::filter_int($_GET['idVoc'] ?? 4);
            $vocabList = (new VocabularyListGateway())->findById($vocabId) ?? null;

            if ($vocabList == null) {
                throw new Exception("liste inconnue");
            }

            $mdl = new TranslationGateway();
            $allTranslation = $mdl->findByIdVoc($vocabId);
            $shuffle = $allTranslation;
            shuffle($shuffle);

            $questions = array();
            $goodAnswers = array();
            $allEnglishWords = array();

            foreach ($allTranslation as $translation) {
                $questions[] = $translation->getWord1();
                $allEnglishWords[] = $translation->getWord2();
                $goodAnswers[] = $translation->getWord2();
            }

            $answers = array();

            for ($i = 0; $i < count($questions); $i++) {
                $correctAnswer = $allTranslation[$i]->getWord2();
                array_splice($allEnglishWords, array_search($correctAnswer, $allEnglishWords), 1);

                if (count($allEnglishWords) < 3) {
                    throw new Exception("pas assez de vocabulaire");
                }

                $tab = array_rand(array_flip($allEnglishWords), 3);

                array_push($allEnglishWords, $correctAnswer);

                $tab[] = $correctAnswer;
                shuffle($tab);
                $answers[] = $tab;
            }

            if (isset($user)) {
                echo $twig->render('quizView.html', [
                    'questions' => $questions,
                    'answers' => $answers,
                    'goodAnswers' => $goodAnswers,
                    'listName' => $vocabList->getName(),
                    'userID' => $user->getID(),
                    'userRole' => $user->getRoles()]);
            } else {
                echo $twig->render('quizView.html', [
                    'questions' => $questions,
                    'answers' => $answers,
                    'goodAnswers' => $goodAnswers,
                    'listName' => $vocabList->getName()]);
            }
        } catch (Exception $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function login(): void
    {
        global $twig;
        echo $twig->render('login.html');
    }

    public function confirmLogin(): void
    {
        global $user;
        $model = new MdlUser();

        if ($_POST['logemail']!=null && $_POST['logpass']!=null) {
            $login = strip_tags($_POST['logemail']);
            $password = strip_tags($_POST['logpass']);
        } else {
            throw new Exception("logmail ou logpass null");
        }

        if (!$this->checkLoginExist($login)) {
            throw new Exception(("login invalide"));
        }

        $user = $model->connection($login, $password);

        if ($user == null) {
            throw new Exception("mot de passe invalide");
        }

        UserController::home();
    }

    public function checkLoginExist(string $login): bool
    {
        $mdl = new MdlUser();
        return $mdl->checkLoginExist($login);
    }

    public function disconnect(): void
    {
        $mdl = new MdlUser();
        $mdl->deconnection();
        UserController::home();
    }

    public function resultatsQuiz(): void
    {
        global $twig;
        global $user;
        $score = Validation::filter_int(intval($_POST['score'] ?? null));
        $len = Validation::filter_int(intval($_POST['total']??null));
        $res = $score . '/'. $len;

        if (isset($user)) {
            echo $twig->render('resultatsJeux.html', ['userID' => $user->getId(),
                'res' => $res,
                'userRole' => $user->getRoles()]);
        } else {
            echo $twig->render('resultatsJeux.html', ['res' => $res]);
        }
    }

    public function resultatsMemory(): void
    {
        global $twig;
        global $user;
        $score = Validation::filter_int(intval($_POST['score'] ?? null));

        if (isset($user)) {
            echo $twig->render('resultatsJeux.html', ['userID' => $user->getId(),
                'res' => $score,
                'userRole' => $user->getRoles()]);
        } else {
            echo $twig->render('resultatsJeux.html', ['res' => $score]);
        }
    }
}

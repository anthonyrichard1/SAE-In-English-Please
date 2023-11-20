<?php

namespace controller;

use config\Validation;
use Exception;
use gateway\TranslationGateway;
use gateway\VocabularyListGateway;
use model\MdlStudent;
use model\VocabularyList;
use model\Translation;

class UserController
{

    public function showAccountInfos(): void {
        try {
            global $twig;
            $userID = Validation::filter_int($_GET['user'] ?? null);
            $mdl = new MdlStudent();
            $user = $mdl->getUser($userID);
            echo $twig->render('myAccountView.html', ['user' => $user]);
        }
        catch (Exception $e){
            throw new Exception("invalid user ID");
        }
    }

    public function modifyPassword(): void {
        try {
            $userID = $_GET['user'];
            $currentPassword = Validation::val_password($_GET['currentPassword'] ?? null);
            $newPassword = Validation::val_password($_GET['newPassword'] ?? null);
            $confirmNewPassword = Validation::val_password($_GET['confirmNewPassword'] ?? null);
            $mdl = new MdlStudent();
            $user = $mdl->getUser($userID);

            if ($user->getPassword() != $currentPassword || $newPassword != $confirmNewPassword)
                throw new Exception("");

            $mdl->ModifyPassword($userID, $newPassword);
            $_GET['user'] = $userID;
            $this->showAccountInfos();
        }
        catch (Exception $e){
            throw new Exception("invalid entries");
        }
    }

    public function modifyNickname(): void {
        try {
            $userID = Validation::filter_int($_GET['user'] ?? null);
            $newNickname = Validation::filter_str_nospecialchar($_GET['newNickname'] ?? null);
            $mdl = new MdlStudent();
            $mdl->modifyNickname($userID, $newNickname);
            $_GET['user'] = $userID;
            $this->showAccountInfos();
        }
        catch (Exception $e){
            throw new Exception("invalid entries");
        }
    }

    public static function memory($match): void{
        global $twig;

        try{
            $idVoc = Validation::filter_int($match['id'] ?? null);
            $wordList = (new \gateway\TranslationGateway)->findByIdVoc($idVoc);
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

            echo $twig->render('memory.html', [
                'wordShuffle' => $wordShuffle,
                'pairs' => json_encode($pairs),
            ]);

        }
        catch (Exception $e){
            throw new Exception("Erreur");
        }
    }
    public function quiz($match): void
    {
        global $twig;
        $vocabId = Validation::filter_int($match['id'] ?? null);
        $vocabList = (new VocabularyListGateway())->findById($vocabId) ?? null;
        if ($vocabList == null) throw new Exception("liste inconnue");
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

        for($i=0 ; $i< count($questions) ; $i++) {
            $correctAnswer = $allTranslation[$i]->getWord2();
            array_splice($allEnglishWords, array_search($correctAnswer, $allEnglishWords), 1);

            $tab = array_rand(array_flip($allEnglishWords), 3);

            array_push($allEnglishWords, $correctAnswer);

            $tab[] = $correctAnswer;
            shuffle($tab);
            $answers[] = $tab;
        }

        echo $twig->render('quizView.html', ['questions' => $questions, 'answers' => $answers, 'goodAnswers' => $goodAnswers, 'listName' => $vocabList->getName()]);
    }

    public function login(): void {
        global $twig;
        echo $twig->render('login.html');
    }

    public function confirmLogin(): void {
        $model = new MdlStudent();
        if($_POST['logemail']!=null && $_POST['logpass']!=null) {
            $login = strip_tags($_POST['logemail']);
            $password = strip_tags($_POST['logpass']);
        }
        else throw new Exception("logmail ou logpass null");
        if (!$this->checkLoginExist($login)) throw new Exception(("login invalide"));
        $user = $model->connection($login, $password);
        if ($user == null) throw new Exception("mot de passe invalide");
        FrontController::home();
    }

    public function checkLoginExist(string $login): bool {
        $mdl = new MdlStudent();
        return $mdl->checkLoginExist($login);
    }

    public function disconnect(): void {
        $mdl = new MdlStudent();
        $mdl->deconnection();
        FrontController::home();
    }

    public function resultatsJeux(): void{
        global $twig;
        echo $twig->render('resultatsJeux.html');
    }
}
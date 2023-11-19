<?php

namespace controller;

use config\Validation;
use Exception;
use gateway\TranslationGateway;
use gateway\VocabularyListGateway;
use model\MdlStudent;
use model\VocabularyList;

abstract class AbsController
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
            $idVoc = Validation::filter_int($match['params']['id'] ?? null);
            $wordList = (new \gateway\TranslationGateway)->findByIdVoc($idVoc);
            $wordShuffle = array();

            $pairs = [];
            for ($i = 0; $i != count($wordList); $i += 1) {
                $wordShuffle[] = $word1 = $wordList[$i]->getWord1();
                $wordShuffle[] = $word2 = $wordList[$i]->getWord2();

                $pairs[] = [$word1, $word2];
            }

            shuffle($wordShuffle);

            echo $twig->render('memory.html', [
                'wordShuffle' => $wordShuffle,
                'pairs' => $pairs,
            ]);

        }
        catch (Exception $e){
            throw new Exception("Erreur");
        }
    }
    public function quiz(): void
    {
        global $twig;
        $vocabId = $_GET['vocabID'];
        $mdl = new TranslationGateway();
        $allTranslation = $mdl->findByIdVoc($vocabId);
        echo $twig->render('quizzView.html', ['translations' => $allTranslation]);
    }
}
<?php

namespace controller;
use config\Validation;
use gateway\TranslationGateway;
use gateway\VocabularyListGateway;
use model\MdlStudent;
use Exception;
use model\Translation;

class StudentController
{
    public function affAllVocab(): void
    {
        global $twig;
        $mdl = new MdlStudent();
        $voc = $mdl->getAll();
        echo $twig->render('manageVocabListView.html', ['vocabularies' => $voc]);

    }


    public function affAllStudent(): void
    {
        global $twig;
        $mdl = new MdlStudent();
        $student = $mdl->getAll();
        echo $twig->render('usersView.html', ['users' => $student]);

    }

    public function getByName(): void
    {
        global $twig;
        $mdl = new MdlStudent();
        $name = Validation::filter_str_simple($_GET['listName'] ?? null);
        $vocab = $mdl->getVocabByName($name);
        echo $twig->render('manageVocabView.html', ['vocabularies' => $vocab]);
    }

    public function showAccountInfos(): void {
        try {
            global $twig;
            $userID = Validation::filter_int($_GET['user'] ?? null);
            $mdl = new MdlStudent();
            $user = $mdl->getUser($userID);
            echo $twig->render('myAccountView.html', ['user' => $user]);
        }
        catch (Exception $e){
            throw new Exception("invalid user ID".$e->getFile().$e->getLine());
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
    public function quiz(): void {
        global $twig;
        $vocabId = $_GET['vocabID'];
        $mdl = new TranslationGateway();
        $allTranslation = $mdl->findByIdVoc($vocabId);
        echo $twig->render('quizzView.html',  ['translations' => $allTranslation ]);
    }
/*
    public function flashcard(VocabularyList $v) {
        $idVoc = $v->getId();
        $mdl = new TranslationGateway();
        $allTranslation = $mdl->findByIdVoc($idVoc);
        while(1) {

        }
    }
*/
}
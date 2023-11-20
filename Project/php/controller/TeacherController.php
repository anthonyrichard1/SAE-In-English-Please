<?php

namespace controller;
use config\Validation;
use model\MdlTeacher;
use gateway\VocabularyListGateway;
use Exception;

class TeacherController extends UserController
{
    public function affAllStudent(): void
    {
        global $twig;
        $mdl = new MdlTeacher();
        $student = $mdl->getAllStudent();
        echo $twig->render('usersView.html', ['users' => $student]);

    }

    public function affAllVocab(): void
    {
        global $twig;
        global $user;
        $id = $user->getId();
        $mdl = new MdlTeacher();
        $vocabularies = $mdl->getAll();
        echo $twig->render('manageVocabListView.html', ['vocabularies' => $vocabularies, 'userId' => $id]);
    }

    public function getByName(): void
    {
        global $twig;
        global $user;
        $mdl = new MdlTeacher();
        $id = $user->getId();
        $name = Validation::filter_str_simple($_GET['listName'] ?? null);
        $vocab = $mdl->getVocabByName($name);
        echo $twig->render('manageVocabListView.html', ['vocabularies' => $vocab, 'selectedName' => $name, 'userId' => $id ]);

    }

    public function DelById():void{
        global $twig;
        global $user;
        $mdl = new MdlTeacher();
        $id = $user->getId();
        $vocab = $mdl->removeVocById($id);
        echo $twig->render('manageVocabListView.html', [ 'vocabularies' => $vocab, 'userId' => $id ]);
    }

    public function showVocabListForm(): void {
        global $twig;
        $userID = Validation::filter_int($_GET['userID'] ?? null);
        echo $twig->render('addVocabList.html', ['user' => $userID]);
    }

    public function addVocabList():void {
        global $twig;
        $mdl = new MdlTeacher();
        $userID = Validation::filter_int($_GET['userID'] ?? null);
        $name = Validation::filter_str_simple($_GET['listName'] ?? null);
        $words = array();
        for ($i = 0; $i <= 1; $i++) {
            $frenchWord = Validation::filter_str_simple($_GET['frenchWord'.$i] ?? null);
            $englishWord = Validation::filter_str_simple($_GET['englishWord'.$i] ?? null);
            $words[] = array($frenchWord, $englishWord);
        }
        var_dump($words);
        $mdl->addVocabList($userID, $name, "", $words);
        echo $twig->render('addVocabList.html');
    }
}
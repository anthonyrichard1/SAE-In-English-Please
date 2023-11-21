<?php

namespace controller;
use config\Validation;
use model\MdlTeacher;
use gateway\VocabularyListGateway;
use Exception;
use model\MdlUser;

class TeacherController extends UserController
{
    public function affAllVocab(): void
    {
        global $twig;
        global $user;
        $mdl = new MdlTeacher();
        $vocabularies = $mdl->getAll();
        $groups = $mdl->getAllGroups();
        echo $twig->render('manageVocabListView.html', ['vocabularies' => $vocabularies, 'groups' => $groups, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function DelById():void{
        global $twig;
        global $user;
        $mdl = new MdlTeacher();
        $id = $user->getId();
        $vocab = $mdl->removeVocById($id);
        echo $twig->render('manageVocabListView.html', [ 'vocabularies' => $vocab, 'userID' => $user->getId(), 'userRole' => $user->getRoles() ]);
    }

    public function showVocabListForm(): void {
        global $twig;
        global $user;
        echo $twig->render('addVocabList.html', ['userID' => $user->getId(), 'userRole' => $user->getRoles() ]);
    }

    public function addVocabList():void {
        global $twig;
        global $user;
        $mdl = new MdlTeacher();
        $name = Validation::filter_str_simple($_POST['listName'] ?? null);
        $words = array();

        for ($i = 0; $i <= 19; $i++) {
            echo $i;
            if (!isset($_POST['frenchWord' . $i]) == null || !isset($_POST['englishWord' . $i]) == null) break;

            $frenchWord = Validation::filter_str_simple($_POST['frenchWord' . $i] ?? null);
            $englishWord = Validation::filter_str_simple($_POST['englishWord' . $i] ?? null);

            $words[] = array($frenchWord, $englishWord);
        }

        if (count($words) % 2 == 1) throw new Exception("il manque un mot");
        else {
            $addvoc= $mdl->addVocabList($user->getId(), $name, "", $words);
            $this->affAllVocab();
        }
    }

}
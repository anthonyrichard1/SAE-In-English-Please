<?php

namespace controller;
use config\Validation;
use model\MdlStudent;
use gateway\TranslationGateway;
use Exception;

class StudentController extends UserController
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

    public function memoryChoice(): void {
        global $twig;
        global $user;
        $model = new MdlStudent();
        $voc = $model->getAll();
        echo $twig->render('vocabList.html', ['vocabularies' => $voc, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }
}
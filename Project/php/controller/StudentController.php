<?php

namespace controller;
use config\Validation;
use model\MdlStudent;
use Exception;

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
}
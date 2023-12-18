<?php

namespace controller;

use config\Validation;
use model\MdlStudent;
use gateway\TranslationGateway;
use Exception;

class StudentController extends UserController
{
    public function getByName(): void
    {
        global $twig;
        $mdl = new MdlStudent();
        $name = Validation::filter_str_simple($_GET['listName'] ?? null);
        $vocab = $mdl->getVocabByName($name);
        echo $twig->render('manageVocabView.html', ['vocabularies' => $vocab]);
    }

    public function listVocChoice(): void
    {
        global $twig;
        global $user;
        $jeu = Validation::filter_str_nospecialchar($_GET['jeu'] ?? null);
        $model = new MdlStudent();
        $voc = $model->getVocByGroup($user->getGroup());
        echo $twig->render('vocabList.html', ['jeu' => $jeu,
            'vocabularies' => $voc,
            'userID' => $user->getId(),
            'userRole' => $user->getRoles()]);
    }

    public function gameChoice(): void
    {
        global $twig;
        global $user;
        echo $twig->render('gamesList.html', [ 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }
}

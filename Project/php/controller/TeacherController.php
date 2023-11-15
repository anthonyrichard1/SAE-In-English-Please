<?php

namespace controller;
use config\Validation;
use model\MdlTeacher;
use Exception;

class TeacherController
{
    public function __construct()
    {
        global $twig;

        try {
            $action = Validation::val_action($_REQUEST['action'] ?? null);
            switch ($action) {

                case 'getAllStudent':
                    $this->affAllStudent();
                    break;

                case 'showAllVocab':
                    $this->affAllVocab();
                    break;
                case 'getVocabByName':
                    $this->getByName();
                    break;
                case 'addVocab':
                    break;
                case 'showAllGroup':
                    $this->findAllGroup();
                    break;


   /*             case 'delVoc':
                    $this->delById($_REQUEST['id']);
                    break;*/

                case null:
                    echo $twig->render('home.html');
                    break;

                default:
                    $dVueEreur[] = "Erreur d'appel php";
                    echo $twig->render('vuephp1.html', ['dVueEreur' => $dVueEreur]);
                    break;
            }
        }
        catch (Exception $e) {
            $dVueEreur[] = $e->getMessage()." ".$e->getFile()." ".$e->getLine().'Erreur inattendue!!! ';
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
    }
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
        $mdl = new MdlTeacher();
        $student = $mdl->getAll();
        echo $twig->render('usersView.html', ['users' => $student]);

    }

    public function getByName(): void
    {
        global $twig;
        $mdl = new MdlTeacher();
        if (isset($_GET['name'])) {
            // Get the 'name' parameter from the $_GET array
            $name = $_GET['name'];
            $vocab = $mdl->getVocabByName($name);
            echo $twig->render('usersView.html', ['users' => $vocab,]);
        }

    }

    public function DelById($id):void{
        global $twig;
        $mdl = new MdlTeacher();
        $vocab = $mdl->removeVocById($id);
        echo $twig->render('usersView.html', ['vocab' => $vocab]);

    }

    public function findAllGroup(){
        global $twig;
        $mdl = new MdlTeacher();
        $group = $mdl->getGroup();
        $user = $mdl->getUnassignedUsers();
        echo $twig->render('manageVocabListView.html', ['groups' => $group,'unassignedUsers' => $user]);
    }


}
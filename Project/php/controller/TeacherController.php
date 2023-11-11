<?php

namespace controller;
use model\MdlTeacher;
use Exception;

class TeacherController
{
    public function __construct()
    {
        global $twig;

        try {
            $action = $_REQUEST['action'] ?? null;
            switch ($action) {

                case 'getAllStudent':
                    $this->affAllStudent();
                    break;

                case 'allVocab':
                    $this->affAllVocab();
                    break;
                case 'getVocabByName':
                    $this->getByName($_REQUEST['name']);
                    break;
                case 'addVocab':
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

    public function getByName($name): void
    {
        global $twig;
        $mdl = new MdlTeacher();
        $vocab = $mdl->getVocabByName($name);
        echo $twig->render('usersView.html', ['users' => $vocab]);

    }

    public function DelById($id):void{
        global $twig;
        $mdl = new MdlTeacher();
        $vocab = $mdl->removeVocById($id);
        echo $twig->render('usersView.html', ['users' => $vocab]);

    }



}
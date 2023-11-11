<?php

namespace controller;
use model\MdlStudent;
use Exception;

class StudentController
{
    public function __construct()
    {
        global $twig;

        try {
            $action = $_REQUEST['action'] ?? null;
            switch ($action) {
                case 'allVocab':
                    $this->affAllVocab();
                    break;

                case 'getByName':
                    $this->getByName($_REQUEST['nom']);
                    break;


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

        public function affAllVocab(): void
        {
            global $twig;
            $mdl = new MdlStudent();
            $student = $mdl->getAll();
            echo $twig->render('usersView.html', ['users' => $student]);

        }

    public function affAllStudent(): void
    {
        global $twig;
        $mdl = new MdlStudent();
        $student = $mdl->getAll();
        echo $twig->render('usersView.html', ['users' => $student]);

    }

        public function getByName($name): void
        {
            global $twig;
            $mdl = new MdlStudent();
            $vocab = $mdl->getVocabByName($name);
            echo $twig->render('usersView.html', ['users' => $vocab]);
        }



        }


<?php

namespace controller;
use model\MdlTeacher;
use gateway\UserGateway;
use config\Connection;
class TeacherController
{
    public function __construct()
    {
        global $twig;
        session_start();
        $actionList = ['getAllStudent','getAllVocab','getVocabByName','AddVocab', 'DelVocab'];
        $dVueEreur = [];
        try {
            $action = $_REQUEST['action'] ?? null;
            switch ($action) {
                case null:
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

                default:
                    $dVueEreur[] = "Erreur d'appel php";
                    echo $twig->render('vuephp1.html', ['dVueEreur' => $dVueEreur]);
                    break;
            }
        }
        catch (\PDOException $e) {
            $dataVueEreur[] = "Erreur inattendue";
            $twig->render("vuephp1.html", ['dVueErreur' => $dataVueEreur]);

        } catch (Exception $e2) {
            $dataVueEreur[] = "Erreur inattendue!!! ";
            require($dataVueEreur['erreur']);
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
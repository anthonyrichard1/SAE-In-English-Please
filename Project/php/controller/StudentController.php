<?php

namespace controller;
use model\MdlStudent;
use gateway\UserGateway;
use config\Connection;

class StudentController
{

    public function __construct(){
        global $twig;
         global $gtw;
         global $con;
         $con = new Connection('mysql:host=localhost;dbname=dbanrichard7','anrichard7','achanger');
         $gtw = new UserGateway($con);
        $actionList = ['showUsers'];
        $dVueEreur= [];
        session_start();
        try{
            $action = $_REQUEST['action']?? null;
            switch($action) {
                case "AllVocab":
                    affAllVocab();
                    break;
                case "getByName":
                    getByName();
                    break;

                default:
                    $dVueEreur[] = "Erreur d'appel php";
                    echo $twig->render('vuephp1.html', ['dVueEreur' => $dVueEreur]);
                    break;
            }
        }
        catch(\PDOException $e){
            $dataVueEreur[]= "Erreur inattendue";
            $twig->render("vuephp1.html",['dVueErreur' =>$dataVueEreur]);

        }
        catch (Exception $e2)
        {
            $dataVueEreur[] = "Erreur inattendue!!! ";
            require($dataVueEreur['erreur']);
        }
    }
    public function affAllVocab():void{
        global $twig;
        $mdl = new MdlStudent();
        $student = $mdl->getAll();
        echo $twig->render('usersView.html', ['users'=> $student]);

    }

    public function getByName($name):void{
        global $twig;
        $mdl = new MdlStudent();
        $vocab = $mdl->getVocabByName($name);
        echo $twig->render('usersView.html', ['users'=> $vocab]);

    }


        }


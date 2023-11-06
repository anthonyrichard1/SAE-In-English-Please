<?php

namespace controller;
use model\Student;
use model\MdlStudent;
use model\UserGateway;

class StudentController
{

    public function __construct(){
        global $twig;
         global $gtw;
         global $con;
         $con = new Connection('mysql:host=localhost;dbname=dbanrichard7','anrichard7','achanger');
         $gtw = new UserGateway($con);
        session_start();
        try{
            $action = $_REQUEST['action']?? null;
            switch($action) {
                case NULL:
                    break;
                case "ajouter":
                    ajouter($_REQUEST['']);
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
    function ajouter(){
        $mdl = new MdlStudent();
    }

        }


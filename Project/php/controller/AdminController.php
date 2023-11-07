<?php

namespace controleur;

use config\Connection;
use model\MdlAdmin;
use model\UserGateway;

class AdminController
{
    public function __construct()
    {
        global $twig;
        $mdl = new MdlAdmin(new UserGateway(new Connection($dsn, $login, $password)));
        session_start();

        $actionList = ['addUser', 'removeUser', 'addGroup', 'removeGroup', 'showGroups', 'findUser'];
        $dVueEreur = [];

        try {
            $action = $_REQUEST['action'] ?? null;

            switch($action) {
                case null:
                    $this->Reinit();
                    break;

                case 'addUser':
                    $mdl->addUser();
                    break;

                default:
                    $dVueEreur[] = "Erreur d'appel php";
                    echo $twig->render('vuephp1.html', ['dVueEreur' => $dVueEreur]);
                    break;
            }
        } catch (\PDOException $e) {

            $dVueEreur[] = 'Erreur inattendue!!! ';
        } catch (\Exception $e2) {
            $dVueEreur[] = 'Erreur inattendue!!! ';
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
        exit(0);
    }

    public function Reinit()
    {
        global $twig;

        $dVue = [
            'nom' => '',
            'age' => 0,
        ];
        echo $twig->render('vuephp1.html', [
            'dVue' => $dVue
        ]);
    }
}

<?php

namespace controller;

use gateway\GroupGateway;
use model\MdlAdmin;
use model\UserGateway;

class AdminController
{
    public function __construct()
    {
        global $twig;
        session_start();

        $dVueEreur = [];

        try {
            $action = $_REQUEST['action'] ?? null;

            switch($action) {
                case 'showAllUsers':
                case null:
                    $this->showAllUsers();
                    break;

                case 'showAllAdmins':
                    $this->showAllAdmins();
                    break;

                case 'showAllTeachers':
                    $this->showAllTeachers();
                    break;

                case 'showAllStudents':
                    $this->showAllStudents();
                    break;

                case 'removeUser':
                    $this->removeUser();
                    break;
                case 'showAllGroups':
                    $this->showAllGroups();
                    break;
                case 'showGroupDetails':
                    $this->showGroupDetails();
                    break;
                case 'removeUserFromGroup':
                    $this->removeUserFromGroup();
                    break;
                case 'removeGroup':
                    $this->removeGroup();
                    break;

                case 'addGroup':
                    $this->addGroup();
                    break;

                default:
                    $dVueEreur[] = "Erreur d'appel php";
                    echo $twig->render('vuephp1.html', ['dVueEreur' => $dVueEreur]);
                    break;
            }
        } catch (\PDOException $e) {

            $dVueEreur[] = 'Erreur inattendue!!! ';
        } catch (\Exception $e2) {
            $dVueEreur[] = $e2->getMessage().'Erreur inattendue!!! ';
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
        exit(0);
    }

    /*public function Reinit()
    {
        global $twig;

        $dVue = [
            'nom' => '',
            'age' => 0,
        ];
        echo $twig->render('vuephp1.html', [
            'dVue' => $dVue
        ]);
    }*/

    public function showAllUsers(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->showAllUsers();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllAdmins(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->showAllAdmins();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllTeachers(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->showAllTeachers();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllStudents(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->showAllStudents();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function removeUser(): void {
        $id = $_GET['id'];
        $model = new MdlAdmin();
        $model->removeUser($id);
        $this->showAllUsers();
    }

    public function showAllGroups(): void {
        global $twig;
        $model = new MdlAdmin();
        $groups = $model->showAllGroups();
        echo $twig->render('groupView.html', ['groups' => $groups]);
    }

    public function showGroupDetails(): void {
        global $twig;
        $model = new MdlAdmin();
        $id = $_GET['selectedGroup'];
        $groups = $model->showAllGroups();
        $users = $model->getUsersOfGroup($id);
        echo $twig->render('groupView.html', ['groups' => $groups, 'selectedGroup' => $id, 'users' => $users]);
    }

    public function removeUserFromGroup(): void {
        $model = new MdlAdmin();
        $id = $_GET['id'];
        $model->removeUserFromGroup($id);
        $this->showGroupDetails();
    }

    public function removeGroup(): void {
        $model = new MdlAdmin();
        $id = $_GET['selectedGroup'];
        $model->removeGroup($id);
        $this->showAllGroups();
    }

    public function addGroup(): void {
        $model = new MdlAdmin();
        $num = $_GET['num'];
        $year = $_GET['year'];
        $sector = $_GET['sector'];
        $model->addGroup($num, $year, $sector);
        $this->showAllGroups();
    }
}

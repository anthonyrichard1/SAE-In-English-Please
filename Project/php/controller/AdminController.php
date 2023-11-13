<?php

namespace controller;

use config\Validation;
use model\MdlAdmin;
use Exception;

class AdminController
{
    public function __construct()
    {
        global $twig;

        try {
            $action = Validation::val_action($_REQUEST['action']);

            switch($action) {
                case 'showAllUsers':
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

                case 'addUserToGroup':
                    $this->addUserToGroup();
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
        exit(0);
    }

    public function showAllUsers(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->getAllUsers();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllAdmins(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->getAllAdmins();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllTeachers(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->getAllTeachers();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function showAllStudents(): void {
        global $twig;
        $model = new MdlAdmin();
        $users = $model->getAllStudents();
        echo $twig->render('usersView.html', ['users' => $users]);
    }

    public function removeUser(): void {
        try {
            $id = Validation::filter_int($_GET['id']);
            $model = new MdlAdmin();
            $model->removeUser($id);
            $this->showAllUsers();
        }
        catch (Exception $e) {
            throw new Exception("invalid user ID");
        }
    }

    public function showAllGroups(): void {
        global $twig;
        $model = new MdlAdmin();
        $groups = $model->getAllGroups();
        $unassignedUsers = $model->getUnassignedUsers();
        echo $twig->render('manageGroupView.html', ['groups' => $groups, 'unassignedUsers' => $unassignedUsers]);
    }

    public function showGroupDetails(): void {
        try {
            global $twig;
            $selectedGroup = Validation::filter_int($_GET['selectedGroup'] ?? null);
            $model = new MdlAdmin();
            $groups = $model->getAllGroups();
            $users = $model->getUsersOfGroup($selectedGroup);
            $unassignedUsers = $model->getUnassignedUsers();
            echo $twig->render('manageGroupView.html', ['groups' => $groups, 'selectedGroup' => $selectedGroup, 'users' => $users, 'unassignedUsers' => $unassignedUsers]);
        }
        catch (Exception $e) {
                throw new Exception("invalid group ID");
        }
    }

    public function removeUserFromGroup(): void {
        try {
            $id = Validation::filter_int($_GET['id']);
            $model = new MdlAdmin();
            $model->removeUserFromGroup($id);
            $this->showGroupDetails();
        }
        catch (Exception $e) {
            throw new Exception("invalid group ID");
        }
    }

    public function removeGroup(): void {
        try {
            $selectedGroup = Validation::filter_int($_GET['selectedGroup']);
            $model = new MdlAdmin();
            $model->removeGroup($selectedGroup);
            $this->showAllGroups();
        }
        catch (Exception $e) {
            throw new Exception("invalid group ID");
        }
    }

    public function addGroup(): void {
        try {
            $num = Validation::filter_int($_GET['num']);
            $year = Validation::filter_int($_GET['year']);
            $sector = Validation::filter_str_simple($_GET['sector']);

            $model = new MdlAdmin();
            $groupID = $model->addGroup($num, $year, $sector);
            $_GET['selectedGroup'] = $groupID;
            $this->showGroupDetails();
        }
        catch (Exception $e) {
            throw new Exception("invalid form");
        }
    }

    public function addUserToGroup(): void {
        try {
            $user = Validation::filter_int($_GET['userID']);
            $group = Validation::filter_int($_GET['groupID']);
            $model = new MdlAdmin();
            $model->addUserToGroup($user, $group);
            $_GET['selectedGroup'] = $group;
            $this->showGroupDetails();
        }
        catch (Exception $e) {
            throw new Exception("invalid IDs");
        }
    }
}

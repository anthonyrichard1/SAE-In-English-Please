<?php

namespace controller;

use config\Validation;
use model\MdlAdmin;
use Exception;

class AdminController
{
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
            $id = Validation::filter_int($_GET['userID'] ?? null);
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
            $id = Validation::filter_int($_GET['id'] ?? null);
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
            $selectedGroup = Validation::filter_int($_GET['selectedGroup'] ?? null);
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
            $num = Validation::filter_int($_GET['num'] ?? null);
            $year = Validation::filter_int($_GET['year'] ?? null);
            $sector = Validation::filter_str_simple($_GET['sector'] ?? null);

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
            $user = Validation::filter_int($_GET['userID'] ?? null);
            $group = Validation::filter_int($_GET['groupID'] ?? null);
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

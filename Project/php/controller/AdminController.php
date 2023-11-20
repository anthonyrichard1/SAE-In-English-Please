<?php

namespace controller;

use config\Validation;
use model\MdlAdmin;
use Exception;

class AdminController extends UserController
{
    public function showAllUsers(): void {
        global $twig;
        global $user;
        $model = new MdlAdmin();
        $users = $model->getAllUsers();
        echo $twig->render('usersView.html', ['users' => $users, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function showAllAdmins(): void {
        global $twig;
        global $user;
        $model = new MdlAdmin();
        $users = $model->getAllAdmins();
        echo $twig->render('usersView.html', ['users' => $users, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function showAllTeachers(): void {
        global $twig;
        global $user;
        $model = new MdlAdmin();
        $users = $model->getAllTeachers();
        echo $twig->render('usersView.html', ['users' => $users, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function showAllStudents(): void {
        global $twig;
        global $user;
        $model = new MdlAdmin();
        $users = $model->getAllStudents();
        echo $twig->render('usersView.html', ['users' => $users, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function removeUser(): void {
        try {
            $userToRemove = Validation::filter_int($_GET['userToRemove'] ?? null);
            $model = new MdlAdmin();
            $model->removeUser($userToRemove);
            $this->showAllUsers();
        }
        catch (Exception $e) {
            throw new Exception("invalid user ID");
        }
    }

    public function showAllGroups(): void {
        global $twig;
        global $user;
        $model = new MdlAdmin();
        $groups = $model->getAllGroups();
        $unassignedUsers = $model->getUnassignedUsers();
        echo $twig->render('manageGroupView.html', ['groups' => $groups, 'unassignedUsers' => $unassignedUsers, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function showGroupDetails(): void {
        try {
            global $twig;
            global $user;
            $selectedGroup = Validation::filter_int($_GET['selectedGroup'] ?? null);
            $model = new MdlAdmin();
            $groups = $model->getAllGroups();
            $users = $model->getUsersOfGroup($selectedGroup);
            $unassignedUsers = $model->getUnassignedUsers();

            echo $twig->render('manageGroupView.html', ['groups' => $groups, 'selectedGroup' => $selectedGroup, 'users' => $users, 'unassignedUsers' => $unassignedUsers, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
        }
        catch (Exception $e) {
            throw new Exception("invalid group ID");
        }
    }

    public function removeUserFromGroup(): void {
        try {
            $userToRemove = Validation::filter_int($_GET['userToRemove'] ?? null);
            $groupID = Validation::filter_int($_GET['selectedGroup'] ?? null);
            $model = new MdlAdmin();
            $model->removeUserFromGroup($userToRemove);
            $_GET['selectedGroup'] = $groupID;
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
            $num = Validation::filter_int($_POST['num'] ?? null);
            $year = Validation::filter_int($_POST['year'] ?? null);
            $sector = Validation::filter_str_simple($_POST['sector'] ?? null);

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
            $userToAdd = Validation::filter_int($_GET['userToAdd'] ?? null);
            $group = Validation::filter_int($_GET['groupID'] ?? null);
            $model = new MdlAdmin();
            $model->addUserToGroup($userToAdd, $group);
            $_GET['selectedGroup'] = $group;
            $this->showGroupDetails();
        }
        catch (Exception $e) {
            throw new Exception("invalid IDs");
        }
    }
}

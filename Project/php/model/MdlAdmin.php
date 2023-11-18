<?php

namespace model;

use gateway\GroupGateway;
use gateway\UserGateway;

class MdlAdmin extends AbsModel
{
    public function __construct()
    {
        parent::__construct("admin");
    }

    public function getAllUsers(): array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }

    public function getAllAdmins(): array {
        $gtw = new UserGateway();
        return $gtw->findAllAdmins();
    }

    public function getAllTeachers(): array {
        $gtw = new UserGateway();
        return $gtw->findAllTeachers();
    }

    public function getAllStudents(): array {
        $gtw = new UserGateway();
        return $gtw->findAllStudents();
    }

    public function removeUser(int $id): void {
        $gtw = new UserGateway();
        $gtw->remove($id);
    }

    public function getAllGroups(): array {
        $gtw = new GroupGateway();
        return $gtw->findAll();
    }

    public function getUsersOfGroup(int $id): array {
        $gtw = new UserGateway();
        return $gtw->findUsersByGroup($id);
    }

    public function removeUserFromGroup(int $id): void {
        $gtw = new UserGateway();
        $gtw->modifyGroup($id);
    }

    public function removeGroup(int $id): void {
        $gtw = new GroupGateway();
        $gtw->remove($id);
    }

    public function addGroup(int $num, int $year, string $sector): int {
        $gtw = new GroupGateway();
        return $gtw->add(array($num, $year, $sector));
    }

    public function addUserToGroup(int $user, int $group): void {
        $gtw = new UserGateway();
        $gtw->modifyGroup($user, $group);
    }

    public function getUnassignedUsers(): array {
        $gtw = new UserGateway();
        return $gtw->findUnassignedUsers();
    }

    public function is()
    {
        if (
            isset($_SESSION['id']) &&
            isset($_SESSION['password']) &&
            isset($_SESSION['email']) &&
            isset($_SESSION['name']) &&
            isset($_SESSION['surname']) &&
            isset($_SESSION['nickname']) &&
            isset($_SESSION['image']) &&
            isset($_SESSION['extraTime']) &&
            isset($_SESSION['group']) &&
            isset($_SESSION['roles']) &&
            $_SESSION['roles'] === 'admin'
        ) {
            $id = (int)$_SESSION['id'];
            $password = $_SESSION['password'];
            $email = $_SESSION['email'];
            $name = $_SESSION['name'];
            $surname = $_SESSION['surname'];
            $nickname = $_SESSION['nickname'];
            $image = $_SESSION['image'];
            $extraTime = (bool)$_SESSION['extraTime'];
            $group = (int)$_SESSION['group'];
            $roles = $_SESSION['roles'];

            return new User($id, $password, $email, $name, $surname, $nickname, $image, $extraTime, $group, $roles);
        } else {
            return null;
        }
    }
}
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

    /*public function isAdmin(){
        if( isset ($_SESSION['login'])){
            $login = strip_tags($_SESSION['login']);
            $user = $this->gtw->findUserByEmail($login);
            if ($user && $this->gtw->isAdmin($user->getId())) return $user;
            else return null;
        }
        else return null;
    }*/

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

    public function addUserToGroup($user, $group): void {
        $gtw = new UserGateway();
        $gtw->modifyGroup($user, $group);
    }

    public function getUnassignedUsers(): array {
        $gtw = new UserGateway();
        return $gtw->findUnassignedUsers();
    }
}
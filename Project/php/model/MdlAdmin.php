<?php

namespace model;

use config\Connection;
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

    public function showAllUsers(): array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }

    public function showAllAdmins(): array {
        $gtw = new UserGateway();
        return $gtw->findAllAdmins();
    }

    public function showAllTeachers(): array {
        $gtw = new UserGateway();
        return $gtw->findAllTeachers();
    }

    public function showAllStudents(): array {
        $gtw = new UserGateway();
        return $gtw->findAllStudents();
    }

    public function removeUser(int $id): void {
        $gtw = new UserGateway();
        $gtw->remove($id);
    }

    public function showAllGroups(): array {
        $gtw = new GroupGateway();
        return $gtw->findAll();
    }

    public function getUsersOfGroup(int $id): array {
        $gtw = new UserGateway();
        return $gtw->findUsersByGroup($id);
    }

    public function removeUserFromGroup(int $id): void {
        $gtw = new UserGateway();
        $gtw->modifyGroup($id, 0);
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
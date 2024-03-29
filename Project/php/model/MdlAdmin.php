<?php

namespace model;

use gateway\GroupGateway;
use gateway\UserGateway;

class MdlAdmin extends MdlUser
{
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

    public function is(string $login, array $roles): User
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);

        if ($user->getRoles() == $roles && in_array('admin', $user->getRoles())) return $user;
        else return null;
    }
}
<?php

namespace model;

use gateway\UserGateway;

class MdlUser extends AbsModel {

    public function modifyNickname(int $id, string $newNickname): void{
        $gtw = new UserGateway();
        $gtw->modifyNickname($id, $newNickname);
    }

    public function ModifyPassword(int $id, string $newPassword): void {
        $gtw = new UserGateway();
        $gtw->modifyPassword($id, $newPassword);
    }

    public function is(string $login, array $roles)
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);

        if (!empty($user->getRoles())) return $user;
        else return false;
    }

    public function getUserById($id): User
    {
        $gtw = new UserGateway();
        return $gtw->findById($id);
    }
}

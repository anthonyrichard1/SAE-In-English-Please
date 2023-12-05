<?php

namespace model;

use gateway\UserGateway;

class MdlUser extends AbsModel
{

    public function modifyNickname(int $id, string $newNickname): void
    {
        $gtw = new UserGateway();
        $gtw->modifyNickname($id, $newNickname);
    }

    public function modifyPassword(int $id, string $newPassword): void
    {
        $gtw = new UserGateway();
        $gtw->modifyPassword($id, $newPassword);
    }

    public function is(string $login, array $roles): ?User
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);
        return !empty($user->getRoles()) ? $user : null;
    }

    public function getUserById($id): User
    {
        $gtw = new UserGateway();
        return $gtw->findById($id);
    }
}

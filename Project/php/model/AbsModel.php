<?php

namespace model;

use gateway\UserGateway;

abstract class AbsModel
{
    public function connection(string $login, string $password):?User
    {
        $gtw = new UserGateway();
        $hash = $gtw->login($login) ?? null;

        if ($hash != null && password_verify($password, $hash)) {
            $user = $gtw->findUserByEmail($login);
            $_SESSION['login'] = $login;

            $roles = array();

            foreach ($user->getRoles() as $role) {
                $roles[] = $role;
            }

            $_SESSION['roles'] = $roles;

            return $user;
        }

        return null;
    }

    public function deconnection():void
    {
        session_unset();
        session_destroy();
        $_SESSION = array();
    }

    public function checkLoginExist(string $login): bool
    {
        $gtw = new UserGateway();
        return $gtw->findUserByEmail($login) != null;
    }

    abstract public  function is(string $login, array $roles): ?User;
}

<?php

namespace model;

use gateway\UserGateway;

abstract class AbsModel
{
    private string $role;

    /**
     * @param string $role
     */
    public function __construct(string $role)
    {
        $this->role = $role;
    }

    public function connection(string $login, string $password){
        $gtw = new UserGateway();
        $hash = $gtw->login($login) ?? null;

        if ($hash != null && password_verify($password, $hash)) {
            $user = $gtw->findUserByEmail($login);
            $_SESSION['login'] = $login;

            $roles = array();
            foreach ($user->getRoles() as $role) $roles[] = $role;
            $_SESSION['roles'] = $roles;

            return $user;
        }

        return null;
    }

    public function deconnection(){
        session_unset();
        session_destroy();
        $_SESSION = array();
    }

    public function checkLoginExist(string $login) {
        $gtw = new UserGateway();
        return $gtw->findUserByEmail($login) != null;
    }

    public abstract function is(string $login, array $roles);
}
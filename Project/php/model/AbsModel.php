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
        $cleanedLogin = strip_tags($login);
        $cleanedPassword = strip_tags($password);
        $gtw = new UserGateway();

        if (password_verify($cleanedPassword, $gtw->login($cleanedLogin)[0][0])) {
            $user = $gtw->findUserByEmail($cleanedLogin);
            $_SESSION['login'] = $cleanedLogin;
            $roles = array();
            foreach ($roles as $role) $roles[] = $role;
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

    public abstract function is();
}
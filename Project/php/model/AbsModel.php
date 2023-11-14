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
        $student = $gtw->findUserByLoginPassword($cleanedLogin, $cleanedPassword);

        if ($student) {
            session_start();
            $_SESSION['role'] = $this->role;
            $_SESSION['login'] = $cleanedLogin;
            return true;
        }
        else return false;
    }

    public function deconnection(){
        session_unset();
        session_destroy();
        $_SESSION = array();
    }

    public abstract function is();
}
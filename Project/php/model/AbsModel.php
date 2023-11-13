<?php

namespace model;

use gateway\UserGateway;

class AbsModel
{
    private string $role;

    /**
     * @param string $role
     */
    public function __construct(string $role)
    {
        $this->role = $role;
    }

    public function connection($login, $password){
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

    public function deconnexion(){
        session_unset();
        session_destroy();
        $_SESSION = array();
    }
}
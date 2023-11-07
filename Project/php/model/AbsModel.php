<?php

namespace model;

use gateway\UserGateway;

class AbsModel
{
    protected UserGateway $gtw;
    private string $role;

    /**
     * @param UserGateway $gtw
     * @param string $role
     */
    public function __construct(UserGateway $gtw, string $role)
    {
        $this->gtw = $gtw;
        $this->role = $role;
    }

    public function connection($login, $password){
        $cleanedLogin = strip_tags($login);
        $cleanedPassword = strip_tags($password);

        $student = $this->gtw->findUserByLoginPassword($cleanedLogin, $cleanedPassword);

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
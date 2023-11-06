<?php

namespace model;

class MdlAdmin
{

    /**
     * @param UserGateway $gtw
     */
    public function __construct(UserGateway $gtw)
    {
        $this->gtw = $gtw;
    }


    public function connection($login, $password){
        $cleanedLogin = strip_tags($login);
        $cleanedPassword = strip_tags($password);

        $student = $this->gtw->findUserByLoginPassword($cleanedLogin, $cleanedPassword);

        if ($student) {
            session_start();
            $_SESSION['role'] = 'admin';
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

    public function isAdmin(){
        if( isset ($_SESSION['login'])){
            $login=strip_tags($_SESSION['login']);
            $user = $this->gtw->findUserByEmail($login);
            var_dump($user->getId());
            echo "coucou";
            if ($user && $this->gtw->isAdmin($user->getId())) return $user;
            else return null;
        }
        else return null;
    }
}
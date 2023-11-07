<?php

namespace model;

use gateway\UserGateway;

class MdlStudent extends AbsModel
{
    /**
     * @param UserGateway $gtw
     */
    public function __construct(UserGateway $gtw)
    {
        parent::__construct($gtw, "student");
    }

/*
    public function isStudent(){
        if( isset ($_SESSION['login']) && isset ($_SESSION['role'])){
            //Créer une classe nettoyer
            $login=Nettoyer::nettoyer_string($_SESSION['login']);
            $role=Nettoyer::nettoyer_string($_SESSION['role']);
            return self::$gtw->findUserByEmail($login);
        }
        else return null;
    }
*/

}


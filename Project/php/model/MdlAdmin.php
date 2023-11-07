<?php

namespace model;

use gateway\UserGateway;

class MdlAdmin extends AbsModel
{
    /**
     * @param UserGateway $userGtw
     */
    public function __construct(UserGateway $userGtw)
    {
        parent::__construct($userGtw, "admin");
    }

    public function isAdmin(){
        if( isset ($_SESSION['login'])){
            $login = strip_tags($_SESSION['login']);
            $user = $this->gtw->findUserByEmail($login);
            if ($user && $this->gtw->isAdmin($user->getId())) return $user;
            else return null;
        }
        else return null;
    }

    public function addUser(string $password, string $email, string $name, string $surname, string $nickname, string $image, bool $extraTime, int $group, array $roles){

    }
}
<?php

namespace model;

use gateway\UserGateway;
use gateway\VocabularyGateway;
class MdlStudent extends AbsModel
{

    public function __construct()
    {
        parent::__construct("student");
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
    public function getAll():array{
        global $twig;
        $gtw = new VocabularyGateway();
        return  $gtw->findAll();
        /*
        foreach ($data as $row){
            $AllStudent[] = User($row['id'],$row['password'],$row['email'],$row['name'],$row['surname'],$row['nickname'],$row['image'],$row['extraTime'],$row['group'],$row['roles']);
        }
        return  $AllStudent;
        */
}

    public function getVocabByName($name):array{
        $gtw = new VocabularyGateway();
        $res = $gtw->findByName($name);
        return $res;
    }

    public function getUser(int $id): User{
        $gtw = new UserGateway();
        return $gtw->findById($id);
    }

    public function modifyNickname(int $id, string $newNickname): void{
        $gtw = new UserGateway();
        $gtw->modifyNickname($id, $newNickname);
    }

    public function ModifyPassword(int $id, string $newPassword): void {
        $gtw = new UserGateway();
        $gtw->modifyPassword($id, $newPassword);
    }
}


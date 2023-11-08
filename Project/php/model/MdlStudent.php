<?php

namespace model;

use gateway\VocabularyGateway;
//use http\Client\Curl\User;
use model\AbsModel;
use config\Connection;
use model\User;
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
    public function getAll(){
        global $twig;
        $gtw = new VocabularyGateway(new Connection('mysql:host=localhost;dbname=dbanrichard7','anrichard7','achanger'));
        return  $gtw->findAll();
        /*
        foreach ($data as $row){
            $AllStudent[] = User($row['id'],$row['password'],$row['email'],$row['name'],$row['surname'],$row['nickname'],$row['image'],$row['extraTime'],$row['group'],$row['roles']);
        }
        return  $AllStudent;
        */
}

    public function getById($id){
        $gtw = new VocabularyGateway(new Connection());
        $res = $gtw->getById($id);
        return $res;
    }




}


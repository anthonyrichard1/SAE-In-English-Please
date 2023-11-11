<?php

namespace model;

//use http\Client\Curl\User;
use model\AbsModel;
use config\Connection;
use gateway\UserGateway;
use gateway\VocabularyGateway;
class MdlTeacher extends AbsModel
{

    public function __construct()
    {
        parent::__construct("teacher");
    }

    public function getAll():array{
        $gtw = new VocabularyGateway();
        return  $gtw->findAll();
        /*
        foreach ($data as $row){
            $AllStudent[] = User($row['id'],$row['password'],$row['email'],$row['name'],$row['surname'],$row['nickname'],$row['image'],$row['extraTime'],$row['group'],$row['roles']);
        }
        return  $AllStudent;
        */
    }

    public function getAllStudent():array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }

    public function getVocabByName($name):array{
        $gtw = new VocabularyGateway();
        $res = $gtw->findByName($name);
        return $res;
    }

    public function RemoveVocById($id):void{
        $gtw = new VocabularyGateway();
        $res = $gtw->remove($id);
    }




}
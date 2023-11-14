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

    public function getVocabByName(string $name):array{
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

    public function is()
    {
        // TODO: Implement is() method.
    }
}


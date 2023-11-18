<?php

namespace model;

use gateway\UserGateway;
use gateway\VocabularyGateway;
use gateway\VocabularyListGateway;

class MdlStudent extends AbsModel
{

    public function __construct()
    {
        parent::__construct("student");
    }
    public function checkIdExist(int $id):bool {
        $gtw = new UserGateway();
        return $gtw->checkIdExist($id);
    }

    public function getAll():array{
        $gtw = new VocabularyListGateway();
        return  $gtw->findAll();
        /*
        foreach ($data as $row){
            $AllStudent[] = User($row['id'],$row['password'],$row['email'],$row['name'],$row['surname'],$row['nickname'],$row['image'],$row['extraTime'],$row['group'],$row['roles']);
        }
        return  $AllStudent;
        */
}

    public function getVocabByName(string $name):array{
        $gtw = new VocabularyListGateway();
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
        if (
            isset($_SESSION['id']) &&
            isset($_SESSION['password']) &&
            isset($_SESSION['email']) &&
            isset($_SESSION['name']) &&
            isset($_SESSION['surname']) &&
            isset($_SESSION['nickname']) &&
            isset($_SESSION['image']) &&
            isset($_SESSION['extraTime']) &&
            isset($_SESSION['group']) &&
            isset($_SESSION['roles']) &&
            $_SESSION['roles'] === 'student'
        ) {
            $id = (int)$_SESSION['id'];
            $password = $_SESSION['password'];
            $email = $_SESSION['email'];
            $name = $_SESSION['name'];
            $surname = $_SESSION['surname'];
            $nickname = $_SESSION['nickname'];
            $image = $_SESSION['image'];
            $extraTime = (bool)$_SESSION['extraTime'];
            $group = (int)$_SESSION['group'];
            $roles = $_SESSION['roles'];

            return new User($id, $password, $email, $name, $surname, $nickname, $image, $extraTime, $group, $roles);
        } else {
            return null;
        }
    }

}


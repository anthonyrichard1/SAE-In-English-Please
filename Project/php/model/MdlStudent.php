<?php

namespace model;

use gateway\UserGateway;
use gateway\VocabularyGateway;
use gateway\VocabularyListGateway;

class MdlStudent extends MdlUser
{
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

    public function is(string $login, array $roles): ?User
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);

        if ($user->getRoles() == $roles && in_array('student', $user->getRoles())) return $user;
        else return null;
    }
}


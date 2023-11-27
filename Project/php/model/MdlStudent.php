<?php

namespace model;

use gateway\UserGateway;
use gateway\VocabularyGateway;
use gateway\VocabularyListGateway;

class MdlStudent extends MdlUser
{
    public function getAll():array{
        $gtw = new VocabularyListGateway();
        return $gtw->findAll();
}

    public function getVocabByName(string $name):array{
        $gtw = new VocabularyListGateway();
        $res = $gtw->findByName($name);
        return $res;
    }

    public function getVocByGroup(int $group): array{
        $gtw = new VocabularyListGateway();
        return $gtw->findByGroup($group);
    }

    public function getVocabById(int $id): VocabularyList {
        $gtw = new VocabularyListGateway();
        return $gtw->findById($id);
    }

    public function is(string $login, array $roles): ?User
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);

        if ($user->getRoles() == $roles && in_array('student', $user->getRoles())) return $user;
        else return null;
    }
}


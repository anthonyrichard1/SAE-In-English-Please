<?php

namespace model;

use gateway\GroupGateway;
use gateway\UserGateway;
use gateway\VocabularyListGateway;
class MdlTeacher extends AbsModel
{

    public function __construct()
    {
        parent::__construct("teacher");
    }

    public function getAll():array{
        $gtw = new VocabularyListGateway();
        return  $gtw->findAll();
    }

    public function getAllStudent():array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }

    public function getVocabByName(string $name):array{
        $gtw = new VocabularyListGateway();
        $res = $gtw->findByName($name);
        return $res;
    }

    public function RemoveVocById(int $id):void{
        $gtw = new VocabularyListGateway();
        $gtw->remove($id);
    }

    public function getGroup():array{
        $gtw = new GroupGateway();
        return $gtw->findAll();
    }

    public function getUnassignedUsers(): array {
        $gtw = new UserGateway();
        return $gtw->findUnassignedUsers();
    }


    public function is()
    {
        // TODO: Implement is() method.
    }
}
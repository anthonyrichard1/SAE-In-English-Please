<?php

namespace model;

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
    }

    public function getAllStudent():array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }

    public function getVocabByName(string $name):array{
        $gtw = new VocabularyGateway();
        $res = $gtw->findByName($name);
        return $res;
    }

    public function RemoveVocById(int $id):void{
        $gtw = new VocabularyGateway();
        $res = $gtw->remove($id);
    }


    public function is()
    {
        // TODO: Implement is() method.
    }
}
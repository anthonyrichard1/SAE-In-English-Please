<?php

namespace model;

use gateway\TranslationGateway;
use gateway\UserGateway;
use gateway\VocabularyGateway;
use gateway\VocabularyListGateway;

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

    public function addVocabList(int $userID, string $name, string $image, array $words): void {
        $vocabGtw = new VocabularyListGateway();
        $vocabID = $vocabGtw->add(array($name, $image, $userID));
        $transGtw = new TranslationGateway();
        foreach ($words as $word) {
            var_dump($word[0]." ".$word[1]);
            $transGtw->add(array($word[0], $word[1], $vocabID));
        }
    }

    public function is()
    {
        // TODO: Implement is() method.
    }
}
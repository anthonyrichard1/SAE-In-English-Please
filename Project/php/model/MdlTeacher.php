<?php

namespace model;

use gateway\GroupGateway;
use gateway\TranslationGateway;
use gateway\UserGateway;
use gateway\VocabularyGateway;
use gateway\VocabularyListGateway;

class MdlTeacher extends MdlUser
{
    public function getAll():array{
        $gtw = new VocabularyListGateway();
        return  $gtw->findAll();
    }

    public function getAllGroups(): array {
        $gtw = new GroupGateway();
        return $gtw->findAll();
    }

    public function getAllStudent():array {
        $gtw = new UserGateway();
        return $gtw->findAll();
    }
    public function findByUser($id):array
    {
        $gtw = new VocabularyListGateway();
        return $gtw->findByUser($id);
        }


    public function getVocabByName(string $name):array{
        $gtw = new VocabularyListGateway();
        $res = $gtw->findByName($name);
        return $res;
    }
    public function findByIdVoc($id):array {
        $gtw = new TranslationGateway();
        return $gtw->findByIdVoc($id);

    }

    public function removeVocabFromGroup(int $vocabID, int $groupID): void{
        $mdl = new GroupGateway();
        $mdl->removeVocabFromGroup($vocabID, $groupID);
    }

    public function addVocabToGroup(int $vocabID, int $groupID): void{
        $mdl = new GroupGateway();
        $mdl->addVocabToGroup($vocabID, $groupID);
    }

    public function findGroupVocab(int $vocab): array {
        $mdl = new GroupGateway();
        return $mdl->findGroupVocab($vocab);
    }

    public function findGroupNoVocab(int $vocab): array {
        $mdl = new GroupGateway();
        return $mdl->findGroupNoVocab($vocab);
    }

    public function RemoveVocById(int $id):void{
        $gtw = new VocabularyListGateway();
        $res = $gtw->remove($id);
    }

    public function addVocabList(int $userID, string $name, string $image, array $words): void {
        $vocabGtw = new VocabularyListGateway();
        $vocabID = $vocabGtw->add(array($name, $image, $userID));
        $transGtw = new TranslationGateway();
        foreach ($words as $word) {
            $transGtw->add(array($word[0], $word[1], $vocabID));
        }
    }

    public function is(string $login, array $roles): ?User
    {
        $gtw = new UserGateway();
        $user = $gtw->findUserByEmail($login);

        if ($user->getRoles() == $roles && in_array('teacher', $user->getRoles())) return $user;
        else return null;
    }
}
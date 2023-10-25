<?php

namespace model;
require_once("User.php");

class Teacher extends User
{
    protected array $vocab;

    public function __construct(int $id, string $mail, string $name, string $surname, array $vocab) {
        parent::__construct($id, $mail, $name, $surname);
        $this->vocab = $vocab;
    }

    /**
     * @return array
     */
    public function getVocab(): array
    {
        return $this->vocab;
    }

    /**
     * @param array $vocab
     */
    public function setVocab(array $vocab): void
    {
        $this->vocab = $vocab;
    }

    /*
    public function createVocabulary($array = [], String $name_test, String $url_image){
        $a = new Vocabulary($array,$name_test,$url_image);
        $this->vocab[] = $a;
        return $a;
    }

    protected function deleteVocabulary(Vocabulary $a){
        foreach($this->vocab as $r){
            if($r == $a) unset($this->vocab[$r]);
        }
    }
    */

}

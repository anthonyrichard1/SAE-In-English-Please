<?php
namespace modeles;

class Teacher extends User
{
    protected array $vocab;

    public function __construct(int $id, string $mail, string $name, string $surname, array $vocab) {
        parent::__construct($id, $mail, $name, $surname);
        $this->vocab = $vocab;
    }

    public function createVocabulary($array = [], String $name_test, String $url_image):{
        $a = new Vocabulary($array,$name_test,$url_image);
        $vocab[] = $a;
        return $a;
    }

    protected function modifyVocabulary(){

    }


}
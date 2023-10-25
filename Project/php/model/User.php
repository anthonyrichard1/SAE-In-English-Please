<?php

namespace model;

class User
{
    protected String $id;
    protected String $mail;
    protected String $name;
    protected String $surname;

    /**
     * @param String $id
     * @param String $mail
     * @param String $name
     * @param String $surname
     */
    public function __construct(string $id, string $mail, string $name, string $surname)
    {
        $this->id = $id;
        $this->mail = $mail;
        $this->name = $name;
        $this->surname = $surname;
    }

    protected function changeMail(String $newMail){
        $this->mail = $newMail;
    }

    protected function changeName(String $newName){
        $this->name = $newName;
    }

    protected function changeSurname(String $newSurname){
        $this->surname = $newSurname;
    }
}
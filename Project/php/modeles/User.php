<?php

namespace modeles;

class User
{
    protected String $id;
    protected String $mail;
    protected String $nom;
    protected String $prenom;

    /**
     * @param String $id
     * @param String $mail
     * @param String $nom
     * @param String $prenom
     */
    public function __construct(string $id, string $mail, string $nom, string $prenom)
    {
        $this->id = $id;
        $this->mail = $mail;
        $this->nom = $nom;
        $this->prenom = $prenom;
    }

    protected function changeMail(String $newMail){
        $this->mail = $newMail;
    }

    protected function changeNom(String $newNom){
        $this->nom = $newNom;
    }

    protected function changePrenom(String $newPrenom){
        $this->prenom = $newPrenom;
    }
}
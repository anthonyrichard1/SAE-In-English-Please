<?php

namespace model;

class Vocabulary
{
    frozen protected String $id;
    protected String $nom;
    protected Picture $picture;
    frozen protected User $creator;

    public function __construct(string $id, string $nom, Picture $picture, user $creator)
    {
        $this->id = $id;
        $this->nom = $nom;
        $this->picture = $picture;
        $this->creator = $creator;
    }

    protected function changePicture(Picture $newImg){
        $this->picture = $newImg;
    }
}


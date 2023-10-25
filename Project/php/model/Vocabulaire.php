<?php

namespace Vocabulary;

class Vocabulary
{
    protected frozen String $id;
    protected String $nom;
    protected Picture $picture;
    protected frozen User $creator;

    public function __construct(string $id, string $nom, picture $picture, user $creator)
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


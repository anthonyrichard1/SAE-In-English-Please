<?php

namespace model;

class Vocabulary
{
    protected $map = array(
        "fr" => "eng"
    );
    protected String $nom;
    protected String $image;
    protected String $theme;

    /**
     * @param string[] $map
     * @param String $nom
     * @param String $image
     * @param String $theme
     */
    public function __construct(array $map, $nom, $image, $theme)
    {
        $this->map = $map;
        $this->nom = $nom;
        $this->image = $image;
        $this->theme = $theme;
    }


    public function translateToEnglish($fr) {
        return isset($this->map[$fr]) ? $this->map[$fr] : $fr;
    }

    public function translateToFrench($eng) {
        // Chercher la clé correspondante pour la valeur en anglais
        $key = array_search($eng, $this->map);

        // Si la traduction est trouvée, retourner la clé (en français)
        return $key !== false ? $key : $eng;
    }

    public function addTranslation($fr, $eng) {
        $this->map[$fr] = $eng;
    }

    /**
     * @return string[]
     */
    public function getMap()
    {
        return $this->map;
    }

    /**
     * @return String
     */
    public function getNom()
    {
        return $this->nom;
    }

    /**
     * @return String
     */
    public function getImage()
    {
        return $this->image;
    }

    /**
     * @return String
     */
    public function getTheme()
    {
        return $this->theme;
    }

    /**
     * @param string[] $map
     */
    public function setMap($map)
    {
        $this->map = $map;
    }

    /**
     * @param String $nom
     */
    public function setNom($nom)
    {
        $this->nom = $nom;
    }

    /**
     * @param String $image
     */
    public function setImage($image)
    {
        $this->image = $image;
    }

    /**
     * @param String $theme
     */
    public function setTheme($theme)
    {
        $this->theme = $theme;
    }




}


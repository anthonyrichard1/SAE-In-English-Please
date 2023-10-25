<?php

namespace model;

class Vocabulary
{
    protected $map = array(
        "fr" => "eng"
    );
    protected String $name;
    protected String $image;

    /**
     * @param string[] $map
     * @param String $name
     * @param String $image
     */
    public function __construct(array $map, $name, $image)
    {
        $this->map = $map;
        $this->name = $name;
        $this->image = $image;
    }

/*
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
*/

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
    public function getName()
    {
        return $this->name;
    }

    /**
     * @return String
     */
    public function getImage()
    {
        return $this->image;
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
    public function setName($name)
    {
        $this->name = $name;
    }

    /**
     * @param String $image
     */
    public function setImage($image)
    {
        $this->image = $image;
    }


}
/*
$v = new Vocabulary(array("bonjour" =>"hello"),"test_A1","pas d'image");

$res1 = $v->getMap();
print_r($res1);
echo "\n";
$trad = $v->translateToEnglish("bonjour");
echo "$trad";
$v->addTranslation("chaise","chair");
echo "\n";
$res1 = $v->getMap();
print_r($res1);

$trad = $v->translateToFrench("chair");
echo "$trad";
*/

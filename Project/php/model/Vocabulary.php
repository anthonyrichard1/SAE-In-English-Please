<?php

namespace model;

class Vocabulary
{
    protected String $name;
    protected String $image;
    protected  int $id;
    protected ?int $aut;

    /**
     * @param String $name
     * @param String $image
     * @param int $id
     * @param int|null $aut
     */
    public function __construct(int $id,string $name, string $image, ?int $aut= null)
    {
        $this->name = $name;
        $this->image = $image;
        $this->id = $id;
        $this->aut = $aut;
    }




    public function __toString(): string
    {
        return "Vocabulaire :" . $this->id . $this->name . $this->image . $this->aut;
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

    public function getId(): int
    {
        return $this->id;
    }

    public function getAut(): int
    {
        return $this->aut;
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

    public function setId(int $id): void
    {
        $this->id = $id;
    }

    public function setAut(int $aut): void
    {
        $this->aut = $aut;
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

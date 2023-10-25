<?php

namespace model;

class User
{
    protected int $id;
    protected String $mail;
    protected String $name;
    protected String $surname;

    /**
     * @param int $id
     * @param string $mail
     * @param string $name
     * @param string $surname
     */
    public function __construct(int $id, string $mail, string $name, string $surname)
    {
        $this->id = $id;
        $this->mail = $mail;
        $this->name = $name;
        $this->surname = $surname;
    }

    public function changeMail(String $newMail){
        $this->mail = $newMail;
    }

    public function changeName(String $newName){
        $this->name = $newName;
    }

    public function changeSurname(String $newSurname){
        $this->surname = $newSurname;
    }

    /**
     * @return int|int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @return string|string
     */
    public function getMail()
    {
        return $this->mail;
    }

    /**
     * @return string|string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @return string|string
     */
    public function getSurname()
    {
        return $this->surname;
    }

    /**
     * @param int|int $id
     */
    public function setId($id)
    {
        $this->id = $id;
    }

    /**
     * @param string|string $mail
     */
    public function setMail($mail)
    {
        $this->mail = $mail;
    }

    /**
     * @param string|string $name
     */
    public function setName($name)
    {
        $this->name = $name;
    }

    /**
     * @param string|string $surname
     */
    public function setSurname($surname)
    {
        $this->surname = $surname;
    }





}
/*
$u = new User(1,"mail","name","surname");
$res = $u->getMail();
echo "$res";
$u->changeMail("new_mail");
$res = $u->getMail();
echo "<br>";
echo "$res";

$res = $u->getName();
echo "<br>";
echo "$res";
$u->changeName("new_name");
$res = $u->getName();
echo "<br>";
echo "$res";

$res = $u->getSurname();
echo "<br>";
echo "$res";
$u->changeSurname("new_name");
$res = $u->getSurname();
echo "<br>";
echo "$res";
*/


<?php

namespace model;

use JetBrains\PhpStorm\Pure;

class Student extends User
{
    public string $nickname;
    private bool $extraTime;

    /**
     * @param String $nickname
     * @param bool $extraTime
     */
    #[Pure] public function __construct(string $id, string $mail, string $nom, string $prenom, string $nickname, bool $extraTime)
    {
        parent::__construct($id,$mail, $nom, $prenom);
        $this->nickname = $nickname;
        $this->extraTime = $extraTime;
    }

    /**
     * @return bool
     */
    public function isExtraTime(): bool
    {
        return $this->extraTime;
    }

    /**
     * @param bool $extraTime
     */
    public function setExtraTime(bool $extraTime): void
    {
        $this->extraTime = $extraTime;
    }

    /**
     * @param String $nickname
     */
    public function setNickname(string $nickname): void
    {
        $this->nickname = $nickname;
    }






}
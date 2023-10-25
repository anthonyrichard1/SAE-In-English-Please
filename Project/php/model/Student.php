<?php

namespace model;

class Student extends User
{
    public string $nickname;
    private bool $extraTime;

    /**
     * @param String $nickname
     * @param bool $extraTime
     */
    public function __construct(string $id, string $mail, string $name, string $surname, string $nickname, bool $extraTime)
    {
        parent::__construct($id, $mail, $name, $surname);
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

    public function __toString(): string
    {
        return "Student : ".parent::__toString()." ".$this->nickname." ".$this->extraTime;
    }

}
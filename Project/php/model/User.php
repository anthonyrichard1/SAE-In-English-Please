<?php

namespace model;

class User
{
    private int $id;
    private string $password;
    private string $email;
    private string $name;
    private string $surname;
    private string $nickname;
    private string $image;
    private bool $extraTime;
    private int $group;
    private array $roles;

    /**
     * @param int $id
     * @param string $password
     * @param string $email
     * @param string $name
     * @param string $surname
     * @param string $nickname
     * @param string $image
     * @param bool $extraTime
     * @param int|null $group
     * @param array $roles
     */
    public function __construct(int $id, string $password, string $email, string $name, string $surname, string $nickname, string $image, ?bool $extraTime, ?int $group, array $roles)
    {
        $this->id = $id;
        $this->password = $password;
        $this->email = $email;
        $this->name = $name;
        $this->surname = $surname;
        $this->nickname = $nickname;
        $this->image = $image;
        $this->extraTime = ($extraTime !== null) ? $extraTime : false;
        $this->group = ($group !== null) ? $group : -1;
        $this->roles = $roles;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getPassword(): string
    {
        return $this->password;
    }

    public function getEmail(): string
    {
        return $this->email;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getSurname(): string
    {
        return $this->surname;
    }

    public function getNickname(): string
    {
        return $this->nickname;
    }

    public function getImage(): string
    {
        return $this->image;
    }

    public function isExtraTime(): bool
    {
        return $this->extraTime;
    }

    public function getGroup(): int
    {
        return $this->group;
    }

    public function getRoles(): array
    {
        return $this->roles;
    }

    public function __toString(): string
    {
        $s = "User : ".$this->id." ".$this->name." ".$this->surname." ".$this->nickname." ".$this->email;
        foreach ($this->roles as $role) $s = $s." ".$role;
        return $s;
    }
}


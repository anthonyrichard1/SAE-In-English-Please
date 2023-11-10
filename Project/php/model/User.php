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

    /**
     * @return int
     */
    public function getId(): int
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId(int $id): void
    {
        $this->id = $id;
    }

    /**
     * @return string
     */
    public function getPassword(): string
    {
        return $this->password;
    }

    /**
     * @param string $password
     */
    public function setPassword(string $password): void
    {
        $this->password = $password;
    }

    /**
     * @return string
     */
    public function getEmail(): string
    {
        return $this->email;
    }

    /**
     * @param string $email
     */
    public function setEmail(string $email): void
    {
        $this->email = $email;
    }

    /**
     * @return string
     */
    public function getName(): string
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName(string $name): void
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getSurname(): string
    {
        return $this->surname;
    }

    /**
     * @param string $surname
     */
    public function setSurname(string $surname): void
    {
        $this->surname = $surname;
    }

    /**
     * @return string
     */
    public function getNickname(): string
    {
        return $this->nickname;
    }

    /**
     * @param string $nickname
     */
    public function setNickname(string $nickname): void
    {
        $this->nickname = $nickname;
    }

    /**
     * @return string
     */
    public function getImage(): string
    {
        return $this->image;
    }

    /**
     * @param string $image
     */
    public function setImage(string $image): void
    {
        $this->image = $image;
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
     * @return int
     */
    public function getGroup(): int
    {
        return $this->group;
    }

    /**
     * @param int $group
     */
    public function setGroup(int $group): void
    {
        $this->group = $group;
    }

    /**
     * @return array
     */
    public function getRoles(): array
    {
        return $this->roles;
    }

    /**
     * @param array $roles
     */
    public function setRoles(array $roles): void
    {
        $this->roles = $roles;
    }

    public function __toString(): string
    {
        $s = "User : ".$this->id." ".$this->name." ".$this->surname." ".$this->nickname." ".$this->email;
        foreach ($this->roles as $role) $s = $s." ".$role;
        return $s;
    }
}


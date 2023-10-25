<?php
namespace model;

use function Sodium\add;

class Group
{
    private int $id;
    private int $num;
    private int $year;
    private string $sector;
    private array $students;
    private array $vocabs;

    /**
     * @param int $id
     * @param int $num
     * @param int $year
     * @param string $sector
     */
    public function __construct(int $id, int $num, int $year, string $sector, array $students, array $vocab)
    {
        $this->id = $id;
        $this->num = $num;
        $this->year = $year;
        $this->sector = $sector;
    }

    /**
     * @return int
     */
    public function getId(): int
    {
        return $this->id;
    }

    /**
     * @return int
     */
    public function getNum(): int
    {
        return $this->num;
    }

    /**
     * @return int
     */
    public function getYear(): int
    {
        return $this->year;
    }

    /**
     * @return string
     */
    public function getSector(): string
    {
        return $this->sector;
    }

    public function addUser(Users $user){
        $this->students.add($user);
    }

    public function removeUser(Users $user){
        $this->students . remove($user);
    }
}
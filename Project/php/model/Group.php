<?php
namespace model;

class Group
{
    protected int $id;
    protected int $num;
    protected int $year;
    protected string $sector;

    /**
     * @param int $id
     * @param int $num
     * @param int $year
     * @param string $sector
     */
    public function __construct(int $id, int $num, int $year, string $sector)
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

    public function setId(int $id): void
    {
        $this->id = $id;
    }

    public function setNum(int $num): void
    {
        $this->num = $num;
    }

    public function setYear(int $year): void
    {
        $this->year = $year;
    }

    public function setSector(string $sector): void
    {
        $this->sector = $sector;
    }

}
<?php

namespace model;

class VocabularyList
{
    private int $id;
    private String $name;
    private String $image;
    private ?int $aut;

    /**
     * @param int $id
     * @param String $name
     * @param String $image
     * @param int|null $aut
     */
    public function __construct(int $id, string $name, string $image, ?int $aut)
    {
        $this->id = $id;
        $this->name = $name;
        $this->image = $image;
        $this->aut = $aut;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getImage(): string
    {
        return $this->image;
    }

    public function getAut(): ?int
    {
        return $this->aut;
    }
}
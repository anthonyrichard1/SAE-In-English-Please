<?php

namespace model;

class VocabularyList
{
    private String $name;
    private String $image;
    private  int $id;
    private ?int $aut;
    private array $vocabList;

    /**
     * @param String $name
     * @param String $image
     * @param int $id
     * @param int|null $aut
     * @param array $vocabList
     */
    public function __construct(string $name, string $image, int $id, ?int $aut, array $vocabList)
    {
        $this->name = $name;
        $this->image = $image;
        $this->id = $id;
        $this->aut = $aut;
        $this->vocabList = $vocabList;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getImage(): string
    {
        return $this->image;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getAut(): ?int
    {
        return $this->aut;
    }

    public function getVocabList(): array
    {
        return $this->vocabList;
    }

    public function __toString(): string
    {
        return "Vocabulaire :" . $this->id . $this->name . $this->image . $this->aut;
    }
}
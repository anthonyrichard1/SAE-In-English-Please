<?php

namespace model;

class Translation
{
    private int $id;
    private string $word1;
    private string $word2;
    private int $listVocab;

    /**
     * @param int $id
     * @param string $word1
     * @param string $word2
     * @param int $listVocab
     */
    public function __construct(int $id, string $word1, string $word2, int $listVocab)
    {
        $this->id = $id;
        $this->word1 = $word1;
        $this->word2 = $word2;
        $this->listVocab = $listVocab;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function getWord1(): string
    {
        return $this->word1;
    }

    public function getWord2(): string
    {
        return $this->word2;
    }

    public function getListVocab(): int
    {
        return $this->listVocab;
    }
}
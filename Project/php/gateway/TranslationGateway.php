<?php

namespace gateway;

use Exception;
use model\Translation;
use PDO;
use PDOException;

class TranslationGateway extends AbsGateway
{
    private function addWord(string $word): void {
        try {
            $query = "INSERT INTO Vocabulary VALUES (:word) ON DUPLICATE KEY UPDATE word=:word";
            $args = array(':word' => array($word, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function add(array $parameters): int // require 4 elements
    {
        try {
            $this->addWord($parameters[0]);
            $this->addWord($parameters[1]);
            $query = "INSERT INTO Translate VALUES(null, :word1, :word2, :idVoc)";
            $args = array(':word1' => array($parameters[0], PDO::PARAM_STR),
                ':word2' => array($parameters[1], PDO::PARAM_STR),
                ':idVoc' => array($parameters[2], PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return $this->con->lastInsertId();
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage().+$e->getLine());
        }
    }

    public function remove(int $id): void {
        try {
            $query = "DELETE FROM Translate WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage().+$e->getLine());
        }
    }

    public function findAll(): array
    {
        try {
            $query = "SELECT * FROM Translate";
            $this->con->executeQuery($query);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row) $tab[] = new Translation($row['id'], $row['firstWord'], $row['secondWord'], $row['listVoc']);

            return $tab;
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function findById(int $id)
    {
        try {
            $query = "SELECT * FROM Translate WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return  $this->con->getResults();
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function findByIdVoc(int $id): array
    {
        try {
            $query = "SELECT * FROM Translate WHERE listVoc=:idVoc";
            $args = array(':idVoc' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row) $tab[] = new Translation($row['id'], $row['firstWord'], $row['secondWord'], $row['listVoc']);

            return $tab;
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }
}
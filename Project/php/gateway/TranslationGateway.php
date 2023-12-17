<?php

namespace gateway;

use Exception;
use model\Translation;
use PDO;
use PDOException;

class TranslationGateway extends AbsGateway
{
    private function addWord(string $word): void
    {
        try {
            $query = "INSERT INTO Vocabulary (word) VALUES (:word) ON DUPLICATE KEY UPDATE word=:word";
            $args = array(':word' => array($word, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        } catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function add(array $parameters): int
    {
        try {
            $this->addWord($parameters[0]);
            $this->addWord($parameters[1]);
            $lastInsert = $this->con->lastInsertId("Vocabulary");
            $query = "INSERT INTO Translate VALUES(null, :word1, :word2, :idVoc)";
            $args = array(':word1' => array($lastInsert-1, PDO::PARAM_INT),
                ':word2' => array($lastInsert, PDO::PARAM_INT),
                ':idVoc' => array($parameters[2], PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return $this->con->lastInsertId();
        } catch (PDOException $e) {
            throw new Exception($e->getMessage().+$e->getLine());
        }
    }

    public function remove(int $id): void
    {
        try {
            $query = "DELETE FROM Translate WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
        } catch (PDOException $e) {
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

            foreach ($results as $row) {
                $tab[] = new Translation($row['id'], $row['firstWord'], $row['secondWord'], $row['listVoc']);
            }
            return $tab;
        } catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function findById(int $id): array
    {
        try {
            $query = "SELECT * FROM Translate WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return  $this->con->getResults();
        } catch (PDOException $e) {
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

            foreach ($results as $row) {
                $firstWord = $this->findWordById($row['firstWordID']);
                $secondWord = $this->findWordById($row['secondWordID']);
                $tab[] = new Translation($row['id'], $firstWord, $secondWord, $row['listVoc']);
            }
            return $tab;
        } catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    private function findWordById(int $id): String
    {
        try{
            $query = "SELECT word FROM Vocabulary WHERE id=:id";
            $args = array('id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return $this->con->getResults()[0]['word'];
        } catch (PDOException $e){
            throw new Exception(($e->getMessage()));
        }
    }
}

<?php
namespace gateway;

use PDO;
use PDOException;
use Exception;
use model\VocabularyList;

class VocabularyListGateway extends AbsGateway
{
    public function __construct(){
        parent::__construct();
    }

    public function add(array $parameters): int // require 3 elements
    {
        try{
            $query = "INSERT INTO VocabularyList VALUES(NULL, :name,:img,:aut)";
            $args = array(':name'=>array($parameters[0],PDO::PARAM_STR),
                ':img'=>array($parameters[1],PDO::PARAM_STR),
                ':aut'=>array($parameters[2],PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
            return $this->con->lastInsertId();
        }
        catch (PDOException $e){
            throw new Exception('problème pour ajouter une liste de vocabulaire');
        }
    }

    public function remove(int $id): void
    {
        try{

            $query = "DELETE FROM Translate WHERE listVoc=:id";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);

            $query = "DELETE FROM Practice WHERE vocabID=:id";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);

            $query = "DELETE FROM VocabularyList WHERE id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception('problème pour supprimer les vocabulaires avec leur Id'. $e->getMessage());
        }
    }

    public function findAll(): array
    {
        try{

            $query = "SELECT * FROM VocabularyList";
            $this->con->ExecuteQuery($query);

            $res = $this->con->getResults();
            $tab_vocab=[];
            foreach($res as $r){
                $tab_vocab[]=new VocabularyList($r['id'],$r['name'],$r['image'],$r['userID']);
            }
            Return $tab_vocab;
        }
        catch(PDOException $e ){
            throw new Exception('problème pour affichage de tous les vocabulaires');
        }
    }

    public function findById(int $id) : ?VocabularyList
    {
        try{
            $query = "SELECT * FROM VocabularyList WHERE id = :id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            if (empty($results)) return null;
            return new VocabularyList($results[0]['id'],$results[0]['name'],$results[0]['image'],$results[0]['userID']);
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function findByName(String $name): array {
        try{

            $query = "SELECT * FROM VocabularyList v WHERE v.name = :name";
            $args = array(':name'=>array($name,PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);

            $res = $this->con->getResults();
            $tab_vocab=[];
            foreach($res as $r){
                $tab_vocab[]=new VocabularyList($r['id'],$r['name'],$r['image'],$r['userID']);
            }
            Return $tab_vocab;
        }

        catch(PDOException $e ){
            throw new Exception('problème pour affichage d\'vocabulaire en fonction de son nom');
        }

    }

    public function ModifVocabListById(int $id, String $name,String $img,String $aut):void{
        try{
            $query = "UPDATE VocabularyList SET name=:name, image=:img, userID=:aut WHERE id=:id";
            $args = array(':id'=>array($id,PDO::PARAM_INT),
                ':name'=>array($name,PDO::PARAM_STR),
                ':img'=>array($img,PDO::PARAM_STR),
                ':aut'=>array($aut,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception('problème pour modifier les vocabulaires');
        }
    }

    public function findByGroup(int $id): array {
        try {
            $query = "SELECT v.* FROM VocabularyList v, Practice p WHERE v.id=p.vocabID AND p.groupID=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row) $tab[] = new VocabularyList($row['id'], $row['name'], $row['image'], $row['userID']);
            return $tab;
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function findByUser(int $id): array {
        try {
            $query = "SELECT * FROM VocabularyList WHERE userID=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row) $tab[] = new VocabularyList($row['id'], $row['name'], $row['image'], $row['userID']);
            return $tab;
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }
}
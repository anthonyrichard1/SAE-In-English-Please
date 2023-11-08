<?php
namespace gateway;

use PDO;
use PDOException;
use config\Connection;
use model\Vocabulary;

class VocabularyGateway extends AbsGateway
{
    public function __construct(Connection $con){
        parent::__construct($con);
    }

    public function add(array $parameters): int // require 4 elements
    {
        try{
            $query = "INSERT INTO Vocabulary values(:id,:name,:img,:aut)";
            $args = array(':id'=>array($parameters[0],PDO::PARAM_INT),
                ':name'=>array($parameters[1],PDO::PARAM_STR),
                ':img'=>array($parameters[2],PDO::PARAM_STR),
                ':aut'=>array($parameters[3],PDO::PARAM_INT));
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
            $query = "DELETE FROM Vocabulary v WHERE v.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception('problème pour supprimer les vocabulaires avec leur Id');
        }
    }

    public function findAll(): array
    {
        try{

            $query = "SELECT * FROM Vocabulary";
            $this->con->ExecuteQuery($query);

            $res = $this->con->getResults();
            $tab_vocab=[];
            foreach($res as $r){
                $tab_vocab[]=new Vocabulary($r['id'],$r['name'],$r['image'],$r['creator']);
            }
            Return $tab_vocab;
        }
        catch(PDOException $e ){
            throw new Exception('problème pour affichage de tous les vocabulaires');
        }
    }

    public function findById(int $id)
    {
        // TODO: Implement findById() method.
    }

    public function findByName(String $name): array {
        try{

            $query = "SELECT * FROM Vocabulary v WHERE v.name = :name";
            $args = array(':name'=>array($name,PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);

            $res = $this->con->getResults();
            $tab_vocab=[];
            foreach($res as $r){
                $tab_vocab[]=new Vocabulary($r['id'],$r['name'],$r['image'],$r['creator']);
            }
            Return $tab_vocab;
        }

        catch(PDOException $e ){
            throw new Exception('problème pour affichage d\'vocabulaire en fonction de son nom');
        }

    }

    public function ModifVocabById(int $id, String $name,String $img,String $aut):void{
        try{
            $query = "UPDATE Vocabulary SET name=:name, image=:img, creator=:aut WHERE id=:id";
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
}
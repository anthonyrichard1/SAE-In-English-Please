<?php

namespace gateway;

use PDO;
use PDOException;
use Exception;
use config\Connection;
use model\Group;

class GroupGateway extends AbsGateway
{
    public function __construct(){
        parent::__construct();
    }

    public function add(array $parameters): int //require 4 elements
    {
        try{
            $query = "INSERT INTO Group_ values(null, :num,:year,:sec)";
            $args = array(':num'=>array($parameters[0],PDO::PARAM_INT),
                ':year'=>array($parameters[1],PDO::PARAM_INT),
                ':sec'=>array($parameters[2],PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);
            return $this->con->lastInsertId();
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function remove(int $id): void
    {
        try{
            $query="UPDATE User_ SET groupID=NULL WHERE groupID=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $query = "DELETE FROM Practice WHERE groupID=:id ";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $query = "DELETE FROM Group_ WHERE id=:id ";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function findAll(): array
    {
        try{
            $query = "SELECT * FROM Group_";
            $this->con->ExecuteQuery($query);

            $res = $this->con->getResults();
            $tab_group=[];
            foreach($res as $r){
                $tab_group[]=new Group($r['id'],$r['num'],$r['year'],$r['sector']);
            }
            Return $tab_group;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findById(int $id)
    {
        try{
            $query = "SELECT * FROM Group_ WHERE id = :id";
            $args = array(':id'=>array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);

            return $this->con->getResults();
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function findByNum(String $num): array{
        try{

            $query = "SELECT * FROM Group_ g WHERE g.num = :num";
            $args = array(':num'=>array($num,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);

            $res = $this->con->getResults();
            $tab_group=[];
            foreach($res as $r){
                $tab_group[]=new Group($r['id'],$r['num'],$r['year'],$r['sector']);
            }
            Return $tab_group;
        }

        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifGroupById(int $id, int $num, int $year ,String $sector):void{
        try{
            $query = "UPDATE Group_ SET num=:num, year=:year, sector=:sector WHERE id=:id";
            $args = array(':id'=>array($id,PDO::PARAM_INT),
                ':num'=>array($num,PDO::PARAM_INT),
                ':year'=>array($year,PDO::PARAM_INT),
                ':sector'=>array($sector,PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function addVocabToGroup(int $vocab, int $group) {
        try {
            $query = "INSERT INTO Practice VALUES (:vocabID, :groupID)";
            $args = array(':vocabID'=>array($vocab,PDO::PARAM_INT),
                ':groupID'=>array($group,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function removeVocabFromGroup(int $vocab, int $group) {
        try {
            $query = "DELETE FROM Practice WHERE vocabID=:vocabID and groupID=:groupID";
            $args = array(':vocabID'=>array($vocab,PDO::PARAM_INT),
                ':groupID'=>array($group,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function findGroupVocab(int $vocab) : array{
        $query = "SELECT g.* FROM Practice p, Group_ g WHERE g.id=p.groupID AND p.vocabID=:vocabID;";
        $args = array(':vocabID'=>array($vocab,PDO::PARAM_INT));
        $this->con->ExecuteQuery($query,$args);
        $results = $this->con->getResults();
        $tab = array();

        foreach ($results as $row) $tab[] = new Group($row['id'],$row['num'],$row['year'],$row['sector']);

        return $tab;
    }

    public function findGroupNoVocab(int $vocab) : array {
        $query = "SELECT * FROM Group_ WHERE id NOT IN (SELECT groupID FROM Practice Where vocabID=:vocabID);";
        $args = array(':vocabID'=>array($vocab,PDO::PARAM_INT));
        $this->con->ExecuteQuery($query,$args);
        $results = $this->con->getResults();
        $tab = array();

        foreach ($results as $row) $tab[] = new Group($row['id'],$row['num'],$row['year'],$row['sector']);

        return $tab;
    }
}
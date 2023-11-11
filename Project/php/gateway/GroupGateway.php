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
            $query = "DELETE FROM Group_ g WHERE g.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
            $query = "DELETE FROM Practice WHERE groupID=:id ";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $query="UPDATE User_ SET groupID=0 WHERE groupID=:id";
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
        // TODO: Implement findById() method.
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

    public function ModifGroupbById(int $id, int $num, int $year ,String $sector):void{
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
}
<?php

namespace gateway;

use PDO;
use PDOException;

class GroupGateway extends AbsGateway
{
    public function __construct(Connection $con){
        parent::__construct($con);
    }

    public function add(array $parameters): int //require 4 elements
    {
        try{
            $query = "INSERT INTO Group_ values(:id,:num,:year,:sec)";
            $args = array(':id'=>array($parameters[0],PDO::PARAM_INT),
                ':num'=>array($parameters[1],PDO::PARAM_INT),
                ':year'=>array($parameters[2],PDO::PARAM_INT),
                ':sec'=>array($parameters[3],PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);
            return $this->con->lastInsertId();
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function remove(array $id): void
    {
        try{
            $query = "DELETE FROM Group_ g WHERE g.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
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
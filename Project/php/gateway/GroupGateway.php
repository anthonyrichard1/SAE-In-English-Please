<?php

namespace gateway;

class GroupGateway
{
    private Connection $con;
    public function __construct(Connection $con){
        $this->con = $con;
    }

    public function findAllGroup(){
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
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');
        }

    }
    public function findByNum(String $num){
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
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');
        }

    }

    public function addGroup(int $id, int $num, int $year,string $sector):void{
        try{
            $query = "INSERT INTO Group_ values(:id,:num,:year,:sec)";
            $args = array(':id'=>array($id,PDO::PARAM_INT),
                ':num'=>array($num,PDO::PARAM_INT),
                ':year'=>array($year,PDO::PARAM_INT),
                ':sec'=>array($sector,PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

        }

    }

    public function delGroupById(int $id):void{
        try{
            $query = "DELETE FROM Group_ g WHERE g.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

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
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

        }

    }

}
/*
$con = new Connection('mysql:host=localhost;dbname=project','root','');
$g = new GroupGateway($con);
var_dump($g->findAllGroup());
var_dump($g->findByNum(1));
var_dump($g->addGroup(2,2,2,"b"));
var_dump($g->addGroup(1,1,1,"a"));
var_dump($g->findAllGroup());
var_dump($g->delGroupById(1));
var_dump($g->findAllGroup());
var_dump($g->ModifGroupbById(2,3,3,"c"));
*/
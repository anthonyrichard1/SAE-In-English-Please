<?php
namespace model;
use config\Connection;
require_once('../config/Connection.php');
require_once('Vocabulary.php');
use PDO;
class VocabularyGateway
{
    private Connection $con;
    public function __construct(Connection $con){
        $this->con = $con;
    }


    public function findByName(String $name){
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
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');
        }

    }

    public function addVocab(int $id, String $name, String $img, int $aut):void{
        try{
            $query = "INSERT INTO Vocabulary values(:id,:name,:img,:aut)";
            $args = array(':id'=>array($id,PDO::PARAM_INT),
                ':name'=>array($name,PDO::PARAM_STR),
                ':img'=>array($img,PDO::PARAM_STR),
                ':aut'=>array($aut,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

        }

    }

    public function delVocabById(int $id):void{
        try{
            $query = "DELETE FROM Vocabulary v WHERE v.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

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
        catch (\PDOException $e){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');

        }

    }


}
/*
$con = new Connection('mysql:host=localhost;dbname=project','root','');
$g = new VocabularyGateway($con);
print_r($g->findByName('gogo'));
echo "<br> avant <br>";

$g->addVocab(3,"gogo","img",2);
$g->addVocab(4,"gogo","img",2);
echo"apres <br>";
print_r($g->findByName('gogo'));

echo" <br> suppression normalement <br>";

$g->delVocabById(3);

print_r($g->findByName('gogo'));

echo "<br> modifié normalement <br>";
$g->ModifVocabById(4,"changer","new_img",4);

print_r($g->findByName('gogo'));
print_r($g->findByName('changer'));
*/
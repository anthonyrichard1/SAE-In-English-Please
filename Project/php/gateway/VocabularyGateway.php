<?php
namespace gateway;

class  VocabularyGateway
{
    private Connection $con;
    public function __construct(Connection $con){
        $this->con = $con;
    }

    public function findAllVoc(){
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
            throw new Exception('problème pour affichage d\'vocabulaire en fonction de son nom');
        }

    }

    public function addVocab(int $id, String $name, String $img, ?int $aut):void{
        try{
            $query = "INSERT INTO Vocabulary values(:id,:name,:img,:aut)";
            $args = array(':id'=>array($id,PDO::PARAM_INT),
                ':name'=>array($name,PDO::PARAM_STR),
                ':img'=>array($img,PDO::PARAM_STR),
                ':aut'=>array($aut,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            throw new Exception('problème pour ajouter une liste de vocabulaire');

        }

    }

    public function delVocabById(int $id):void{
        try{
            $query = "DELETE FROM Vocabulary v WHERE v.id=:id ";
            $args = array(':id'=>array($id,PDO::PARAM_INT));
            $this->con->ExecuteQuery($query,$args);
        }
        catch (\PDOException $e){
            throw new Exception('problème pour supprimer les vocabulaires avec leur Id');

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
            throw new Exception('problème pour modifier les vocabulaires');

        }

    }


}
/*
$con = new Connection('mysql:host=localhost;dbname=dbanrichard7','anrichard7','achanger');
$g = new VocabularyGateway($con);
var_dump($g->findByName('gogo'));
echo "<br> avant <br>";

$g->addVocab(3,"gogo","img",2);
$g->addVocab(4,"gogo","img",2);
$g->addVocab(5,"troto","img",2);
echo"apres <br>";
var_dump($g->findAllVoc());
//print_r($g->findByName('gogo'));

echo" <br> suppression normalement <br>";

$g->delVocabById(3);

var_dump($g->findByName('gogo'));

echo "<br> modifié normalement <br>";
$g->ModifVocabById(4,"changer","new_img",4);
var_dump($g->findByName('gogo'));
var_dump($g->findByName('changer'));
*/
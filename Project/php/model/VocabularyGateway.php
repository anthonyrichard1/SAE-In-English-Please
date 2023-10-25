<?php

namespace model;
use model\Vocabulary;
use config\Connection;

use PDO;
class VocabularyGateway
{
    private Connection $con;
    public function __construct(Connection $con){
        $this->con = $con;
    }


    public function findByName(String $name){
        try{

            $query = "SELECT * FROM Vocabulary v WHERE v.name=:name";
            $args = array(':name'=>array($name,PDO::PARAM_STR));
            $this->con->ExecuteQuery($query,$args);

            $res = $this->con->getResults();
            $tab_vocab=[];
            foreach($res as $r){
                $tab_vocab[]=new Vocabulary($r['id'],$r['name'],$r['image']);
            }
            Return $tab_vocab;
        }

        catch(PDOException $e ){
            error_log('PDOException: ' . $e->getMessage(), 3, 'error.log');
        }

    }


}




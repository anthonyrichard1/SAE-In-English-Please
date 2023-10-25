<?php
namespace model;

use config\Connection;
use PDO;

class UserGateway
{
    private Connection $con;

    /**
     * @param Connection $con
     */
    public function __construct(Connection $con)
    {
        $this->con = $con;
    }

    public function findAllStudents() : array{
        $query = "SELECT u.* FROM User_ u, Be b, Role_ r WHERE u.id=b.userID AND b.roleID=r.id AND r.name='student'";
        $this->con->executeQuery($query, array());
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new Student($row['id'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['extraTime']);
        return $tab;
    }

    public function findStudentByName(string $name): array{
        $query = "SELECT u.* FROM User_ u, Be b, Role_ r WHERE u.id=b.userID AND b.roleID=r.id AND r.name='student' AND u.name=:name";
        $args = array(':name' => array($name, PDO::PARAM_STR));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new Student($row['id'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['extraTime']);
        return $tab;
    }

    public function findStudentBySurname(string $surname): array{
        $query = "SELECT u.* FROM User_ u, Be b, Role_ r WHERE u.id=b.userID AND b.roleID=r.id AND r.name='student' AND u.surname=:surname";
        $args = array(':surname' => array($surname, PDO::PARAM_STR));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new Student($row['id'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['extraTime']);
        return $tab;
    }
}
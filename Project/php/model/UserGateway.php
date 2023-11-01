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

    public function findAllUsers() : array{
        $query = "SELECT * FROM User_";
        $this->con->executeQuery($query, array());
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
        return $tab;
    }

    public function findUserById(int $id) : array{
        $query = "SELECT * FROM User_ WHERE id=:id";
        $args = array(':id' => array($id, PDO::PARAM_INT));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
        return $tab;
    }

    public function findUserByName(string $name) : array{
        $query = "SELECT * FROM User_ WHERE name=:name";
        $args = array(':name' => array($name, PDO::PARAM_STR));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
        return $tab;
    }

    public function findUserBySurname(string $surname) : array{
        $query = "SELECT * FROM User_ WHERE surname=:surname";
        $args = array(':surname' => array($surname, PDO::PARAM_STR));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
        return $tab;
    }

    public function findUserByNickname(string $nickname) : array{
        $query = "SELECT * FROM User_ WHERE nickname=:nickname";
        $args = array(':nickname' => array($nickname, PDO::PARAM_STR));
        $this->con->executeQuery($query, $args);
        $results = $this->con->getResults();
        $tab = array();
        foreach ($results as $row)
            $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
        return $tab;
    }

    public function isAdmin(int $id):bool {
        $query = "SELECT * FROM Be WHERE userID=:id AND roleID=1";
        $args = array(':id' => array($id, PDO::PARAM_INT));
        $this->con->executeQuery($query, $args);
        return !empty($this->con->getResults());
    }

    public function addUser(string $password, string $email, string $name, string $surname, string $nickname, string $image, bool $extraTime, int $group, array $roles): int {
        $query = "INSERT INTO User_ VALUES (NULL, :password, :email, :name, :surname, :nickname, :image, :extraTime, :group)";
        $args = array(':password' => array($password, PDO::PARAM_STR),
            ':email' => array($email, PDO::PARAM_STR),
            ':name' => array($name, PDO::PARAM_STR),
            ':surname' => array($surname, PDO::PARAM_STR),
            ':nickname' => array($nickname, PDO::PARAM_STR),
            ':image' => array($image, PDO::PARAM_STR),
            ':extraTime' => array($extraTime, PDO::PARAM_BOOL),
            ':group' => array($group, PDO::PARAM_INT));
        $this->con->executeQuery($query, $args);
        $userID = $this->con->lastInsertId();

        foreach ($roles as $role) {
            $query = "INSERT INTO Be VALUES (:userID, :roleID)";
            $args = array(':userID' => array($userID, PDO::PARAM_INT),
                ':roleID' => array($role, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
        }

        return $userID;
    }

    public function RemoveUser(int $id) {
        $query="DELETE FROM Vocabulary WHERE creator=:id";
        $args = array(':id' => array($id, PDO::PARAM_INT));
        $this->con->executeQuery($query, $args);

        $query="DELETE FROM Be WHERE userID=:id";
        $this->con->executeQuery($query, $args);

        $query="DELETE FROM User_ WHERE id=:id";
        $this->con->executeQuery($query, $args);
    }
}
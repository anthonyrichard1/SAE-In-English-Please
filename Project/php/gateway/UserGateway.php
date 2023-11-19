<?php
namespace gateway;

use config\Connection;
use model\User;
use PDO;
use PDOException;
use Exception;

class UserGateway extends AbsGateway
{
    public function __construct()
    {
        parent::__construct();
    }

    public function add(array $parameters): int //require 9 elements
    {
        try {
            $query = "INSERT INTO User_ VALUES (NULL, :password, :email, :name, :surname, :nickname, :image, :extraTime, :group)";
            $args = array(':password' => array($parameters[0], PDO::PARAM_STR),
                ':email' => array($parameters[1], PDO::PARAM_STR),
                ':name' => array($parameters[2], PDO::PARAM_STR),
                ':surname' => array($parameters[3], PDO::PARAM_STR),
                ':nickname' => array($parameters[4], PDO::PARAM_STR),
                ':image' => array($parameters[5], PDO::PARAM_STR),
                ':extraTime' => array($parameters[6], PDO::PARAM_BOOL),
                ':group' => array($parameters[7], PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $userID = $this->con->lastInsertId();

            foreach ($parameters[8] as $role) {
                $query = "INSERT INTO Be VALUES (:userID, :roleID)";
                $args = array(':userID' => array($userID, PDO::PARAM_INT),
                    ':roleID' => array($role, PDO::PARAM_INT));
                $this->con->executeQuery($query, $args);
            }

            return $userID;
        }
        catch (PDOException $e){
            throw new Exception($e->getMessage());
        }
    }

    public function remove(int $id): void
    {
        try {
            $query="DELETE FROM VocabularyList WHERE userID=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);

            $query="DELETE FROM Be WHERE userID=:id";
            $this->con->executeQuery($query, $args);

            $query="DELETE FROM User_ WHERE id=:id";
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findAll(): array
    {
        try {
            $this->con->executeQuery("SELECT * FROM User_");
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findAllAdmins(): array {
        try {
            $this->con->executeQuery("SELECT u.* FROM User_ u, Be b WHERE u.id=b.userID AND b.roleID=1 ");
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findAllTeachers(): array {
        try {
            $this->con->executeQuery("SELECT u.* FROM User_ u, Be b WHERE u.id=b.userID AND b.roleID=2");
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findAllStudents(): array {
        try {
            $this->con->executeQuery("SELECT u.* FROM User_ u, Be b WHERE u.id=b.userID AND b.roleID=3");
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findById(int $id)
    {
        try {
            $query = "SELECT * FROM User_ WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            if (empty($results)) return null;
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID'], $this->getRoles($results[0]['id']));
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    private function getRoles(int $id): array {
        try {
            $query = "SELECT r.name FROM Be b, Role_ r WHERE b.userID=:id AND b.roleID=r.id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row) $tab[] = $row['name'];
            return $tab;
        }
        catch (PDOException $e) {
            throw new Exception($e->getMessage());
        }
    }

    public function login(string $login) : string{
        try {
            $query = "SELECT password FROM User_ WHERE email=:email";
            $args = array(':email' => array($login, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            return $this->con->getResults()[0]['password'];
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserByEmail(string $email){
        try {
            $query = "SELECT * FROM User_ WHERE email=:email";
            $args = array(':email' => array($email, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            if (empty($results)) return null;
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID'], $this->getRoles($results[0]['id']));
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserByName(string $name) : array{
        try {
            $query = "SELECT * FROM User_ WHERE name=:name";
            $args = array(':name' => array($name, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserBySurname(string $surname) : array{
        try {
            $query = "SELECT * FROM User_ WHERE surname=:surname";
            $args = array(':surname' => array($surname, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID'], $this->getRoles($results[0]['id']));
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserByNickname(string $nickname) : array{
        try {
            $query = "SELECT * FROM User_ WHERE nickname=:nickname";
            $args = array(':nickname' => array($nickname, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyPassword(int $id, string $newPassword): void
    {
        try {
            $query="UPDATE User_ SET password=:password WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':password' => array($newPassword, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyNickname(int $id, string $newNickname): void
    {
        try {
            $query="UPDATE User_ SET nickname=:nickname WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':nickname' => array($newNickname, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyImage(int $id, string $newImage): void
    {
        try {
            $query="UPDATE User_ SET image=:image WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':image' => array($newImage, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyGroup(int $id, int $newGroup = null): void
    {
        try {
            $query="UPDATE User_ SET groupID=:group WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':group' => array($newGroup, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUsersByGroup(int $id): array {
        try {
            $query = "SELECT * FROM User_ WHERE groupID=:group";
            $args = array(':group' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUnassignedUsers(): array
    {
        try {
            $query = "SELECT * FROM User_, Be WHERE groupID IS NULL AND id = userID AND roleID = 3 ";
            $this->con->executeQuery($query);
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID'], $this->getRoles($row['id']));
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }
}
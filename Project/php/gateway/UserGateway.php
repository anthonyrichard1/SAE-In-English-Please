<?php
namespace gateway;

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
        try {
            $query = "SELECT * FROM User_";
            $this->con->executeQuery($query, array());
            $results = $this->con->getResults();
            $tab = array();
            foreach ($results as $row)
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserById(int $id) : User{
        try {
            $query = "SELECT * FROM User_ WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID']);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserByEmail(string $email) : User{
        try {
            $query = "SELECT * FROM User_ WHERE email=:email";
            $args = array(':email' => array($email, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID']);
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
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
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
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID']);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function findUserByLoginPassword(string $login, string $password) : User{
        try {
            $query = "SELECT * FROM User_ WHERE email=:email AND password=:password";
            $args = array(':email' => array($login, PDO::PARAM_STR), ':password' => array($password, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
            $results = $this->con->getResults();
            return new User($results[0]['id'], $results[0]['password'], $results[0]['email'], $results[0]['name'], $results[0]['surname'], $results[0]['nickname'], $results[0]['image'], $results[0]['extraTime'], $results[0]['groupID']);;
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
                $tab[] = new User($row['id'], $row['password'], $row['email'], $row['name'], $row['surname'], $row['nickname'], $row['image'], $row['extraTime'], $row['groupID']);
            return $tab;
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function isAdmin(int $id) : bool {
        try {
            $query = "SELECT * FROM Be WHERE userID=:id AND roleID=1";
            $args = array(':id' => array($id, PDO::PARAM_INT));
            $this->con->executeQuery($query, $args);
            return !empty($this->con->getResults());
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function addUser(string $password, string $email, string $name, string $surname, string $nickname, string $image, bool $extraTime, int $group, array $roles): int {
        try {
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
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyPassword(int $id, string $newPassword) {
        try {
            $query="UPDATE User_ SET password=:password WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':password' => array($newPassword, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyNickname(int $id, string $newNickname) {
        try {
            $query="UPDATE User_ SET nickname=:nickname WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':nickname' => array($newNickname, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyImage(int $id, string $newImage) {
        try {
            $query="UPDATE User_ SET image=:image WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':image' => array($newImage, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function modifyGroup(int $id, int $newGroup) {
        try {
            $query="UPDATE User_ SET groupID=:group WHERE id=:id";
            $args = array(':id' => array($id, PDO::PARAM_INT), ':group' => array($newGroup, PDO::PARAM_STR));
            $this->con->executeQuery($query, $args);
        }
        catch(PDOException $e ){
            throw new Exception($e->getMessage());
        }
    }

    public function removeUser(int $id) {
        try {
            $query="DELETE FROM Vocabulary WHERE creator=:id";
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
}
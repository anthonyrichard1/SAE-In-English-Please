<?php

namespace gateway;

use PDO;
use PDOException;
use config\Connection;

abstract class AbsGateway
{
    protected Connection $con;

    public function __construct() {
        global $dsn;
        global $login;
        global $password;
        $this->con = new Connection($dsn, $login, $password);
    }

    public abstract function add(array $parameters): int;
    //public abstract function remove(int $id): void;
    public abstract function findAll(): array;
    public abstract function findById(int $id);
}
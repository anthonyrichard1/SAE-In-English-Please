<?php

namespace gateway;

use PDO;
use PDOException;
use config\Connection;

abstract class AbsGateway
{
    protected Connection $con;

    public function __construct()
    {
        global $dsn;
        global $login;
        global $password;
        $this->con = new Connection($dsn, $login, $password);
    }

    abstract public function add(array $parameters): int;
    abstract public  function remove(int $id): void;
    abstract public  function findAll(): array;
    abstract public  function findById(int $id);
}

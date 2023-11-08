<?php

namespace gateway;

use PDO;
use PDOException;
use config\Connection;

abstract class AbsGateway
{
    protected Connection $con;

    public function __construct(Connection $con) {
        $this->con = $con;
    }

    public abstract function add(array $parameters): int;
    public abstract function remove(int $id): void;
    public abstract function findAll(): array;
    public abstract function findById(int $id);
}
<?php

//chargement config
require_once __DIR__ . '/config/config.php';

require __DIR__ . '/vendor/autoload.php';

use gateway\UserGateway;
use config\Connection;

//twig
$loader = new \Twig\Loader\FilesystemLoader('templates');
$twig   = new \Twig\Environment($loader, [
    'cache' => false,
]);

$gtw = new UserGateway(new Connection($dsn, $login, $password));

$results = $gtw->findAllUsers();

foreach ($results as $user) var_dump($user->getRoles());
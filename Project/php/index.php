<?php

//chargement config
require_once __DIR__ . '/config/config.php';

require __DIR__ . '/vendor/autoload.php';

use controleur\Controleur;

//twig
$loader = new \Twig\Loader\FilesystemLoader('templates');
$twig   = new \Twig\Environment($loader, [
    'cache' => '/tmp/anrichard7/cache',
]);

$cont = new Controleur();

<?php

//chargement config
require_once __DIR__ . '/config/config.php';

require __DIR__ . '/vendor/autoload.php';

use controller\FrontController;

//twig
$loader = new \Twig\Loader\FilesystemLoader('templates');
$twig   = new \Twig\Environment($loader, [
    'cache' => false,
]);

$ctrl = new FrontController();
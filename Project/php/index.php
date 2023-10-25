<?php

//chargement config
require_once __DIR__ . '/config/config.php';

require __DIR__ . '/vendor/autoload.php';
use model\User;
use model\Teacher;
use model\Vocabulary;
use model\Student;
use model\Group;
use controleur\Controleur;

//twig
$loader = new \Twig\Loader\FilesystemLoader('templates');
$twig   = new \Twig\Environment($loader, [
    'cache' => false,
]);

$cont = new Controleur();
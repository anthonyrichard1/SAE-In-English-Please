<?php

namespace controller;

use config\Validation;
use Exception;

class FrontController
{
    public function __construct() {
        global $twig;
        global $altorouterPath;

        try {
            $router = new \AltoRouter();
            $router->setBasePath($altorouterPath);

            $router->map('GET', '/', 'AppController');
            $router->map( 'GET|POST', '/admin/[i:id]/[a:action]?', 'AdminController');
            $router->map( 'GET|POST', '/teacher/[i:id]/[a:action]?', 'TeacherController');
            $router->map( 'GET|POST', '/student/[i:id]/[a:action]?', 'StudentController');

            $match = $router->match();

            if (!$match) { throw new Exception("Erreur 404");}

            $controller = $match['target'] ?? null;
            $action = Validation::val_action($match['params']['action'] ?? null);

            switch ($action) {
                case null:
                    echo $twig->render('home.html');
                    break;

                default :
                    $controller = '\\controller\\' . $controller;
                    $controller = new $controller;

                    if (is_callable(array($controller, $action)))
                        call_user_func_array(array($controller, $action), array($match['params']));

                    break;
            }
        }
        catch (Exception $e) {
            $dVueEreur[] = $e->getMessage();
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
    }
}
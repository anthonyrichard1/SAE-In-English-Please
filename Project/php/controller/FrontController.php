<?php

namespace controller;

use config\Validation;
use Exception;
use model\MdlStudent;

class FrontController
{
    public function __construct()
    {
        global $twig;
        global $altorouterPath;

        session_start();

        try {
            $router = new \AltoRouter();
            $router->setBasePath($altorouterPath);

            $getpost = 'GET|POST';

            $router->map('GET', '/', 'User');
            $router->map($getpost, '/admin/[i:id]/[a:action]?', 'Admin');
            $router->map($getpost, '/teacher/[i:id]/[a:action]?', 'Teacher');
            $router->map($getpost, '/student/[i:id]/[a:action]?', 'Student');
            $router->map($getpost, '/visitor/[a:action]', 'Visitor');

            $twig->addGlobal('base', $altorouterPath);

            $match = $router->match();

            if (!$match) {
                throw new Exception("Erreur 404 page not found");
            } else {
                $target = $match['target'] ?? null;
                $action = Validation::val_action($match['params']['action'] ?? null);
                $id = $match['params']['id'] ?? null;

                if ($target == 'Visitor') {
                    $userCtrl = new VisitorController();

                    if (is_callable(array($userCtrl, $action))) {
                        call_user_func_array(array($userCtrl, $action), array($match['params']));
                    }
                } else {
                    if ($target == null) {
                        throw new Exception("pas de target");
                    }

                    if (isset($_SESSION['login']) && isset($_SESSION['roles'])) {

                        $_SESSION['login'] = strip_tags($_SESSION['login']);

                        for ($i=0 ; $i<count($_SESSION['roles']) ; $i++) {
                            $_SESSION['roles'][$i] = strip_tags($_SESSION['roles'][$i]);
                        }

                        $mdl = '\\model\\Mdl' . $target;
                        $mdl = new $mdl;

                        if (is_callable(array($mdl, 'is'))) {
                            global $user;
                            $user = call_user_func_array(
                                array($mdl, 'is'),
                                array($_SESSION['login'],
                                    $_SESSION['roles'])
                            );

                            if ($target == 'User' && $action == null) {
                                UserController::home();
                            } elseif (!$user || $user->getId() != $id) {
                                throw new Exception("erreur 403 permission denied");
                            }

                            $controller = '\\controller\\' . $target . 'Controller';
                            $controller = new $controller;

                            if (is_callable(array($controller, $action))) {
                                call_user_func_array(array($controller, $action), array($match['params']));
                            }
                        }
                    } elseif ($target == 'User' && $action == null) {
                        UserController::home();
                    } else {
                        (new UserController())->login();
                    }
                }
            }
        } catch (Exception $e) {
                $dVueEreur[] = $e->getMessage();
                echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
    }
}
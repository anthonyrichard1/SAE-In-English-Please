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

            $router->map('GET', '/', 'FrontController');
            $router->map('GET|POST', '/admin/[i:id]/[a:action]?', 'Admin');
            $router->map('GET|POST', '/teacher/[i:id]/[a:action]?', 'Teacher');
            $router->map('GET|POST', '/student/[i:id]/[a:action]?', 'Student');
            $router->map('GET|POST', '/user/[a:action]?', 'User');
            $router->map('GET|POST', '/user/[a:action]/[i:id]', 'User');

            $twig->addGlobal('base', $altorouterPath);

            $match = $router->match();

            if (!$match) {
                throw new Exception("Erreur 404 page not found");
            }
            if ($match) {
                $target = $match['target'] ?? null;
                $action = Validation::val_action($match['params']['action'] ?? null);
                $id = $match['params']['id'] ?? null;

                if ($target == 'User') {
                    $userCtrl = new UserController();
                    if (is_callable(array($userCtrl, $action)))
                        call_user_func_array(array($userCtrl, $action), array($match['params']));
                }
                else {
                    switch ($action) {
                        case null:
                            $this->home();
                            break;

                        default :
                            if ($target == null) throw new Exception("pas de target");

                            if (isset($_SESSION['login']) && isset($_SESSION['roles'])) {

                                $_SESSION['login'] = strip_tags($_SESSION['login']);
                                for ($i=0 ; $i<count($_SESSION['roles']) ; $i++) $_SESSION['roles'][$i] = strip_tags($_SESSION['roles'][$i]);

                                $mdl = '\\model\\Mdl' . $target;
                                $mdl = new $mdl;

                                if (is_callable(array($mdl, 'is'))) {
                                    global $user;
                                    $user = call_user_func_array(array($mdl, 'is'), array($_SESSION['login'], $_SESSION['roles']));

                                    if (!$user || $user->getId() != $id) throw new Exception("erreur 403 permission denied");
                                }

                                $controller = '\\controller\\' . $target . 'Controller';
                                $controller = new $controller;

                                if (is_callable(array($controller, $action)))
                                    call_user_func_array(array($controller, $action), array($match['params']));

                                break;
                            }
                            else (new UserController())->login();
                    }
                }
            }
        }
        catch
            (Exception $e) {
                $dVueEreur[] = $e->getMessage();
                echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
            }
    }

    public static function home(): void {
        global $twig;
        echo $twig->render('home.html');
    }
}
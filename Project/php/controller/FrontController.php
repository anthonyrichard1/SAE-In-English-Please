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

        var_dump($_SESSION['login']);
        var_dump($_SESSION['roles']);

        try {
            $router = new \AltoRouter();
            $router->setBasePath($altorouterPath);

            $router->map('GET', '/', 'AppController');
            $router->map('GET|POST', '/[a:action]?', 'NULL');
            $router->map('GET|POST', '/admin/[i:id]/[a:action]?', 'AdminController');
            $router->map('GET|POST', '/teacher/[i:id]/[a:action]?', 'TeacherController');
            $router->map('GET|POST', '/student/[i:id]/[a:action]?', 'StudentController');

            $match = $router->match();

            if (!$match) {
                throw new Exception("Erreur 404");
            }
            if ($match) {
//list($controller, $action) = explode('#', $match['target'] );
                $controller = $match['target'] ?? null;
                $action = Validation::val_action($match['params']['action'] ?? null);
                $id = $match['params']['id'] ?? null;
                if(!$this->checkIdExist($id)) {
                    throw new Exception("L'identifiant est invalide");
                }

                print 'user Id received ' . $id . '<br>';
                print 'controleur appelé ' . $controller . '<br>';
                print $action . '<br>';
                print $id . '<br>';


                switch ($action) {
                    case null:
                        $this->home();
                        break;

                    case 'login':
                        $this->login();
                        break;

                    case 'confirmLogin':
                        $this->confirmLogin();
                        break;

                    default :
                        $controller = '\\controller\\' . $controller;
                        $controller = new $controller;

                        if (is_callable(array($controller, $action)))
                            call_user_func_array(array($controller, $action), array($match['params']));

                        break;
                }
            }
        }
        catch
            (Exception $e) {
                $dVueEreur[] = $e->getMessage();
                echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
            }
    }


    public function home(): void {
        global $twig;
        echo $twig->render('home.html');
    }

    public function login(): void {
        global $twig;
        echo $twig->render('login.html');
    }

    public function confirmLogin(): void {
        $model = new MdlStudent();
        $login = strip_tags($_POST['logemail']);
        $password = strip_tags($_POST['logpass']);
        $user = $model->connection($login, $password);
        $this->home();
    }
    public function checkIdExist($id):bool
    {
        $mdl = new MdlStudent();
        $res = $mdl->checkIdExist($id);
        return $res;
    }

}
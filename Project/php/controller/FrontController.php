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

            $router->map('GET', '/', 'AppController');
            $router->map('GET|POST', '/[a:action]?/[i:id]?', 'NULL');
            $router->map('GET|POST', '/admin/[i:id]/[a:action]?', 'Admin');
            $router->map('GET|POST', '/teacher/[i:id]/[a:action]?', 'Teacher');
            $router->map('GET|POST', '/student/[i:id]/[a:action]?', 'Student');

            $match = $router->match();

            if (!$match) {
                throw new Exception("Erreur 404 page not found");
            }
            if ($match) {
                $target = $match['target'] ?? null;
                $action = Validation::val_action($match['params']['action'] ?? null);
                $id = $match['params']['id'] ?? null;

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

                    case 'disconnect':
                        $this->disconnect();
                        break;
                    case 'quiz':
                        $this->quiz();
                        break;

                    default :
                        if ($id != null && !$this->checkIdExist($id)) throw new Exception("identifiant invalide");
                        if ($target == null) throw new Exception("pas de target");

                        if (isset($_SESSION['login']) && isset($_SESSION['roles'])) {

                            $_SESSION['login'] = strip_tags($_SESSION['login']);
                            for ($i=0 ; $i<count($_SESSION['roles']) ; $i++) $_SESSION['roles'][$i] = strip_tags($_SESSION['roles'][$i]);

                            $mdl = '\\model\\Mdl' . $target;
                            $mdl = new $mdl;

                            if (is_callable(array($mdl, 'is'))) {
                                $user = call_user_func_array(array($mdl, 'is'), array($_SESSION['login'], $_SESSION['roles']));

                                if (!$user || $user->getId() != $id) throw new Exception("erreur 403 permission denied");
                            }

                            $controller = '\\controller\\' . $target . 'Controller';
                            $controller = new $controller;

                            if (is_callable(array($controller, $action)))
                                call_user_func_array(array($controller, $action), array($match['params']));

                            break;
                        }
                        else $this->login();
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

    public function checkIdExist(int $id):bool
    {
        $mdl = new MdlStudent();
        $res = $mdl->checkIdExist($id);
        return $res;
    }

    public function disconnect(): void {
        $mdl = new MdlStudent();
        $mdl->deconnection();
        $this->home();
    }
    public function quiz(){
        $ctrl = new StudentController();
        $ctrl->quiz();
    }


}
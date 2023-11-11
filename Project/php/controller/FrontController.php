<?php

namespace controller;

use mysql_xdevapi\Exception;

class FrontController
{
    private array $adminActions = array(
    'showAllUsers',
    'showAllAdmins',
    'showAllTeachers',
    'showAllStudents',
    'removeUser',
    'showAllGroups',
    'showGroupDetails',
    'removeUserFromGroup',
    'removeGroup',
    'addGroup',
    'addUserToGroup'
    );

    private array $teacherActions = array(
    );

    private array $studentActions = array(
    );

    public function __construct()
    {
        global $twig;
        session_start();
        $dVueEreur = array();

        try {
            $action = $_REQUEST['action'] ?? null;

            switch ($action) {
                case null:
                    echo $twig->render('home.html');
                    break;

                default :
                    if (in_array($this->adminActions,$action)) new AdminController();
                    else if (in_array($this->teacherActions, $action)) new TeacherController();
                    else if (in_array($this->studentActions, $action)) new StudentController();
                    else throw new Exception("invalid Action");
                    break;
            }
        }
        catch (\PDOException $e) {
            $dVueEreur[] = 'Erreur inattendue!!! ';
        } catch (\Exception $e2) {
            $dVueEreur[] = $e2->getMessage().'Erreur inattendue!!! ';
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
    }
}
<?php

namespace controller;
use config\Validation;
use Exception;

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
        'showAllGroup',
        'showAllVocab',
        'getVocabByName'
    );

    private array $studentActions = array(
        'showAccountInfos',
        'modifyNickname',
        'modifyPassword'
    );

    public function __construct()
    {
        global $twig;
        session_start();
        $dVueEreur = array();

        try {
            $action = Validation::val_action($_REQUEST['action'] ?? null);

            switch ($action) {
                case null:
                    echo $twig->render('home.html');
                    break;

                default :
                    if (in_array($action, $this->adminActions)) new AdminController();
                    else if (in_array($action, $this->teacherActions)) new TeacherController();
                    else if (in_array($action, $this->studentActions)) new StudentController();
                    else throw new Exception("invalid Action");
                    break;
            }
        }
        catch (Exception $e) {
            $dVueEreur[] = $e->getMessage()." ".$e->getFile()." ".$e->getLine().'Erreur inattendue!!! ';
            echo $twig->render('erreur.html', ['dVueEreur' => $dVueEreur]);
        }
    }
}
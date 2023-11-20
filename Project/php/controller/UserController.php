<?php

namespace controller;

use config\Validation;
use Exception;
use gateway\TranslationGateway;
use gateway\VocabularyListGateway;
use model\MdlStudent;
use model\MdlUser;
use model\VocabularyList;
use model\Translation;

class UserController extends VisitorController
{

    public function showAccountInfos(): void {
        global $twig;
        global $user;
        echo $twig->render('myAccountView.html', ['user' => $user, 'userID' => $user->getId(), 'userRole' => $user->getRoles()]);
    }

    public function modifyPassword(): void {
        try {
            $userID = $_GET['user'];
            $currentPassword = Validation::val_password($_GET['currentPassword'] ?? null);
            $newPassword = Validation::val_password($_GET['newPassword'] ?? null);
            $confirmNewPassword = Validation::val_password($_GET['confirmNewPassword'] ?? null);
            $mdl = new MdlUser();
            $user = $mdl->getUser($userID);

            if ($user->getPassword() != $currentPassword || $newPassword != $confirmNewPassword)
                throw new Exception("");

            $mdl->ModifyPassword($userID, $newPassword);
            $_GET['user'] = $userID;
            $this->showAccountInfos();
        }
        catch (Exception $e){
            throw new Exception("invalid entries");
        }
    }

    public function modifyNickname(): void {
        try {
            $userID = Validation::filter_int($_GET['user'] ?? null);
            $newNickname = Validation::filter_str_nospecialchar($_GET['newNickname'] ?? null);
            $mdl = new MdlUser();
            $mdl->modifyNickname($userID, $newNickname);
            $_GET['user'] = $userID;
            $this->showAccountInfos();
        }
        catch (Exception $e){
            throw new Exception("invalid entries");
        }
    }
}
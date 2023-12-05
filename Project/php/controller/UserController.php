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
    public function showAccountInfos(): void
    {
        global $twig;
        global $user;
        echo $twig->render('myAccountView.html', ['user' => $user,
            'userID' => $user->getId(),
            'userRole' => $user->getRoles()]);
    }

    public function modifyPassword(): void
    {
        try {
            global $user;
            $currentPassword = Validation::val_password($_POST['currentPassword'] ?? null);
            $newPassword = Validation::val_password($_POST['newPassword'] ?? null);
            $confirmNewPassword = Validation::val_password($_POST['confirmNewPassword'] ?? null);

            if (!password_verify($currentPassword, $user->getPassword()) || $newPassword != $confirmNewPassword) {
                throw new Exception("");
            }

            $mdl = new MdlUser();
            $mdl->modifyPassword($user->getId(), password_hash($newPassword, null));
            $user = $mdl->getUserById($user->getId());
            $this->showAccountInfos();
        } catch (Exception $e) {
            throw new Exception("invalid entries".$e->getLine());
        }
    }

    public function modifyNickname(): void
    {
        try {
            global $user;
            $newNickname = Validation::filter_str_nospecialchar($_POST['newNickname'] ?? null);
            $mdl = new MdlUser();
            $mdl->modifyNickname($user->getId(), $newNickname);
            $user = $mdl->getUserById($user->getId());
            $this->showAccountInfos();
        } catch (Exception $e) {
            throw new Exception("invalid entries". $e->getMessage());
        }
    }

    public static function home(): void
    {
        global $twig;
        global $user;

        if (isset($user)) {
            echo $twig->render('home.html', ['userID' => $user->getId(), 'userRole' => $user->getRoles()]);
        } else {
            echo $twig->render('home.html');
        }
    }
}

<?php

namespace model;

class MdlStudent
{
    protected UserGateway $gtw;

    public function __construct($gtw){
        $this->gtw = $gtw;

    }
    public function connection($login, $mdp){
        // 1. Nettoyage des données (vous pouvez utiliser des méthodes de nettoyage spécifiques)
        $cleanedLogin = strip_tags($login);
        $cleanedPassword = strip_tags($mdp);

        // 2. Appel Gateway pour vérifier les identifiants dans la base de données
        $student = $this->gtw->findUserByLoginPassword($cleanedLogin,$cleanedPassword);

        if ($student) {
            // L'authentification a réussi, ajouter le rôle et le login à la session
            session_start();
            $_SESSION['role'] = 'student'; // Vous pouvez définir le rôle approprié
            $_SESSION['login'] = $cleanedLogin;
            return true;
        } else {
            throw Exception('problème d\'authentification');
            return false;
        }
    }

    public function deconnexion(){
        session_unset();
        session_destroy();
        $_SESSION = array();

    }
/*
    public function isStudent(){
        if( isset ($_SESSION['login']) && isset ($_SESSION['role'])){
            //Créer une classe nettoyer
            $login=Nettoyer::nettoyer_string($_SESSION['login']);
            $role=Nettoyer::nettoyer_string($_SESSION['role']);
            return self::$gtw->findUserByEmail($login);
        }
        else return null;
    }
*/

}


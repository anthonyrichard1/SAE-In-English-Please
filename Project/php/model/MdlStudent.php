<?php

namespace model;
use config\Connection;
require_once('../config/Connection.php');
require_once('Student.php');

class MdlStudent
{
    public function connection($login, $mdp){
        // 1. Nettoyage des données (vous pouvez utiliser des méthodes de nettoyage spécifiques)
        $cleanedLogin = strip_tags($login);
        $cleanedPassword = strip_tags($mdp);

        // 2. Appel Gateway pour vérifier les identifiants dans la base de données
        $db = new Connection('mysql:host=localhost;dbname=ma_base', 'utilisateur', 'mot_de_passe');
        $query = $db->prepare('SELECT * FROM Student_ WHERE login = :login AND password = :password');
        $query->bindParam(':login', $cleanedLogin, PDO::PARAM_STR);
        $query->bindParam(':password', $cleanedPassword, PDO::PARAM_STR);
        $query->execute();

        $student = $query->fetch(PDO::FETCH_ASSOC);

        if ($student) {
            // L'authentification a réussi, ajouter le rôle et le login à la session
            session_start();
            $_SESSION['role'] = 'student'; // Vous pouvez définir le rôle approprié
            $_SESSION['login'] = $cleanedLogin;
            return true;
        } else {
            // L'authentification a échoué
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
            return	new	Student($login,$role);
        }
        else return null;
    }
*/
}
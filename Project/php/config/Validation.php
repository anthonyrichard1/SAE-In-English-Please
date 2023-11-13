<?php
namespace config;

use Exception;

class Validation
{
    public static function val_action($action): string {
        $safeAction = htmlspecialchars($action, ENT_QUOTES);
        if (!isset($action))
            throw new \Exception('pas d\'action');
        else if ($safeAction != $action)
            throw new \Exception("tentative d'injection sql détectée");
        else return $safeAction;
    }

    public static function filter_int($value): int {
        if ($value == null || !filter_var($value, FILTER_VALIDATE_INT) || $value < 0)
            throw new Exception("invalid field");
        return $value;
    }

    public static function filter_str_simple($value): string {
        if ($value == null || !preg_match('/^[A-Za-z0-9\s\-]+$/', $value))
            throw new Exception("invalid field");
        return $value;
    }

    public static function filter_str_nospecialchar($value): string {
        if ($value == null || !preg_match('/^[A-Za-z\s\-]+$/', $value))
            throw new Exception("invalid field");
        return $value;
    }

    public static function val_form(string &$nom, string &$age, &$dVueEreur)
    {
        if (!isset($nom) || $nom == '') {
            $dVueEreur[] = 'pas de nom';
            $nom         = '';
        }

        if ( strlen(htmlspecialchars($nom, ENT_QUOTES)) != strlen($nom) ) {
            $dVueEreur[] = "testative d'injection de code (attaque sécurité)";
            $nom         = '';
        }

        if (!isset($age) || $age == '' || !filter_var($age, FILTER_VALIDATE_INT)) {
            $dVueEreur[] = "pas d'age ";
            $age         = 0;
        }
    }
}

<?php
$host = "10.0.128.111";
$user = "zarodolgozat";
$pwd = "zarodolgozat";
$db = "zarodolgozat_2018balben";
$port = 3306;

$connect = new mysqli($host, $user, $pwd, $db, $port);

if ($connect -> connect_error){
	die("Sikertelen csatlakozás!");
}

$connect -> set_charset("utf8");
?>
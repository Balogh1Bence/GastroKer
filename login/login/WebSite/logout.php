<?php
session_start();

echo $_SESSION['name'];
$_SESSION['name']="";
echo $_SESSION['name'];

unset($_SESSION['name']);
echo $_SESSION['name'];
	
?>
<?php
require_once('connect.php');
if (isset($_POST['pw'])){
    $jelszo = $_POST['pw'];
    $id=$_POST['id'];
	
    $sql = "UPDATE `deskusers` SET `password`='$jelszo' WHERE azon='$id'";


		$res=$connect->query($sql);
		

}


?>
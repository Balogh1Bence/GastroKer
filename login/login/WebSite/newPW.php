<?php
require_once('connect.php');
if (isset($_POST['pw'])){
    $jelszo = $_POST['pw'];
    $id=$_POST['id']
	
    $sql = "UPDATE `deskusers` SET `password`=[value-3] WHERE azon='$id'";

    
    if ($stmt -> errno == 0){
       echo "sikeres jelszóváltoztás"
    }

}


?>
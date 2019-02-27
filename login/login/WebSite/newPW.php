<?php
require_once('connect.php');
if (isset($_POST['pw'])){
    $jelszo = $_POST['pw'];
	$email=$_POST['email'];	
    $sql = "UPDATE `deskusers` SET `password`='$jelszo' WHERE email='$email'";
		
		if ($connect->query($sql) === TRUE) {
    echo "Record updated successfully";
} else {
    echo "Error updating record: " . $conn->error;
}
		
}
?>
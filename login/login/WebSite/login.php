﻿<?php
if (isset($_POST['pw'])){
    $us = $_POST['us'];
	$pw=$_POST['pw'];	
    $sql = "SELECT jelsz from vevok where felh='" . $us . "'";
	$result = $connect->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
if($row['jelsz']==$pw)
        header("index.php");
    }
} else {
    echo "0 results";
}
}
?>    
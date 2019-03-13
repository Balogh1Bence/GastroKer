<?php
require_once("connectG.php");
if(isset($_POST['us']))
{
$data=$_POST['us'];
$sql = "SELECT uj from vevok where felh='{$data}'";
	$result = $connect->query($sql);

    while($row = $result->fetch_assoc()) {
    $elso=$row['uj'];

    }
echo $elso;
}

?>
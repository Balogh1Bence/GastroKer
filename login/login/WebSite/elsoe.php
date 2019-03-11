<?php
require_once("connectG.php")
if(isset($_POST['us']))
{
$data=$_POST['us'];
$sql = "SELECT elsoe from vevok where felh='{$data}'";
	$result = $connect->query($sql);

    while($row = $result->fetch_assoc()) {
    $elso=row['elsoe'];

    }
echo $elso;
}

?>
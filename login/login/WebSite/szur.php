<?php
require_once("connectG.php");
if (isset($_POST['kat'])){
$kat=$_POST['kat'];
$sql = "SELECT Tnev, Tkeszl, Tar, Tkod FROM kat, termekek WHERE kat.Tkatkod=termekek.Tkatkod and termekek.Tkatkod=".$kat."";
	$result = $connect->query($sql);
	echo $sql;
	echo $connect->error;
$table="<table id='table' class='table'><tr><th>termék neve</th><th>raktár</th><th>termék ára</th><th></th><th id='mennyiseg'></th></tr>";
while($row = $result->fetch_assoc()) {
$table.="<tr><td>{$row['Tnev']}</td><td>{$row['Tkeszl']}</td><td>{$row['Tar']}</td><td><button id='{$row['Tkod']}' class='btn'  onclick='oneless(this.id, {$row['Tar']})'>-</button></td><td><button class='btn'  id='{$row['Tkod']}' onclick='onemore(this.id, {$row['Tar']})'>+</button></td><td><span  cols='1'  name='{$row['Tkod']}' class='{$row['Tkod']}'>0</span></td></tr>";
    }
$table.="</table>";

echo $table;
    /*
	$pw=$_POST['pw'];	
    

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
if($row['jelsz']==$pw)
        echo $us;
    }
} else {
    echo "0";
}*/
}
?>
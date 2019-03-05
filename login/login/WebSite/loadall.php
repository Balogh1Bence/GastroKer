<?php
require_once("connectG.php");
if (isset($_POST['us'])){
$html="<html>";
$html.="<p>random szöveg</p>";
$html.="</html>";
$sql = "SELECT * from termekek";
	$result = $connect->query($sql);
$table="<table border='1'><tr><th>termék neve</th><th>raktár</th><th>termék ára</th><th></th><th id='mennyiseg'></th></tr>";
while($row = $result->fetch_assoc()) {
$table.="<tr><td>{$row['Tnev']}</td><td>{$row['Tkeszl']}</td><td>{$row['Tar']}</td><td><button id='{$row['Tkod']}'  onclick='oneless(this.id, {$row['Tar']})'>-</button></td><td><button  id='{$row['Tkod']}' onclick='onemore(this.id, {$row['Tar']})'>+</button></td><td><span  cols='1'  name='{$row['Tkod']}' class='{$row['Tkod']}'>0</span></td></tr>";
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
<html>
<head>
 <link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap.css"/>
</head>
</html>
<?php
require_once("connectG.php");
if (isset($_POST['us'])){
$sql = "SELECT * from termekek";
	$result = $connect->query($sql);
$table="<div class='table-responsive'><table id='table' class='table  table-striped'><thead><tr><th>termék neve</th><th>raktár</th><th>termék ára</th><th></th><th id='mennyiseg'></th></tr></thead><tbody>";
while($row = $result->fetch_assoc()) {
$table.="<tr><td>{$row['Tnev']}</td><td>{$row['Tkeszl']}</td><td>{$row['Tar']}</td><td><button id='{$row['Tkod']}' class='btn'  onclick='oneless(this.id, {$row['Tar']})'>-</button></td><td><button class='btn'  id='{$row['Tkod']}' onclick='onemore(this.id, {$row['Tar']})'>+</button></td><td><span  cols='1'  name='{$row['Tkod']}' class='{$row['Tkod']}'>0</span></td></tr>";
    }
$table.="</tbody></table></div>";
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
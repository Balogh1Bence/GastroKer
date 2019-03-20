<?php
require_once("connectG.php");
$sql="select * from kat";
$result = $connect->query($sql);
$html="";
while($row = $result->fetch_assoc()) {
$html.="<input type='button' id=".$row['Tkatkod']." value=".$row['Tkatnev']." onclick='loadNewContent(this.id)'>";
}

echo $html;
?>
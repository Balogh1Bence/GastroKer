<?php
require_once("connectG.php");
$sql="select * from kat";
$result = $connect->query($sql);
$html="";
$selection="<select>";
while($row = $result->fetch_assoc()) {/*
$html.="<input type='button' id=".$row['Tkatkod']." value=".$row['Tkatnev']." onclick='loadNewContent(this.id)'>";*/
$selection.="<option id='".$row['Tkatkod']."', onclick='loadNewContent(this.id)'>".$row['Tkatnev']."</option>";

}
$selection.="</select>";
echo $selection;
?>
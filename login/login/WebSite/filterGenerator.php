<?php
require_once("connectG.php");
$sql="select * from kat";
$result = $connect->query($sql);
$html="";
$selection="<select onChange='loadNewContent(value)'>";

$selection.="<option value='termekek.Tkatkod'>öszes</option>";
while($row = $result->fetch_assoc()) {/*
$html.="<input type='button' id=".$row['Tkatkod']." value=".$row['Tkatnev']." onclick='loadNewContent(this.id)'>";*/
$selection.="<option value='".$row['Tkatkod']."'>".$row['Tkatnev']."</option>";

}
$selection.="</select>";
echo $selection;
?>
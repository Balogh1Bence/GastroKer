<?php require_once('connectG.php');
if (isset($_POST['vevo'])){

	$id=$_POST['id'];
	$ertek=$_POST['ammountOfProducts'];	
	$vnev=$_POST['vevo'];
	$dat = $_POST['date'];	
	$i=0;
	$sql="select * from rend where Vnev=".$vnev."";
	$result = $connect->query($sql);
	if (mysql_num_rows($result)==0) {  $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$id', '$ertek', '$vnev', '$dat')";
	$connect->query($sql);
	echo "sikeresen leadva a rendelés";
	}  
	else {
	sql="update rend where Vnev=".$vnev."";
	echo "sikeresen hozzáadva a rendeléshez";
	}
	


    
	
	/*while ($i<count($ertek)) {
    $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$i', '$ertek[$i]', '{$vnev}', '$dat')";
	$connect->query($sql);
	$i=$i+1;*/
	
	
}
?>
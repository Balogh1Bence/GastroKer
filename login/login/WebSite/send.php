<?php require_once('connectG.php');
if(isset($_SESSION['name']))
{
echo $_SESSION['user'];
}
if (isset($_POST['vevo'])){

	$id=$_POST['id'];
	$ertek=$_POST['ammountOfProducts'];	
	$vnev=$_POST['vevo'];
	$dat = $_POST['date'];	
	$i=0;
	$sql="select * from rend where Vnev='".$vnev."'";
	echo $sql;
	$result = $connect->query($sql);
	$rowcount = mysqli_num_rows($result);
	
	/*
	$cnt = $result->mysql_num_rows;*/
	
	
	
if ($rowcount==0) {  $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$id', '$ertek', '$vnev', '$dat')";
	echo $sql;
	$connect->query($sql);
	echo "sikeresen leadva a rendelés";
	}  
	else {
	$sql="UPDATE `rend` SET `Tmenny`=".$ertek." WHERE Vnev='".$vnev."' and Tkod=".$id."";
		$connect->query($sql);
		echo $sql;
	echo "sikeresen hozzáadva a rendeléshez";
	}
	


    
	
	/*while ($i<count($ertek)) {
    $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$i', '$ertek[$i]', '{$vnev}', '$dat')";
	$connect->query($sql);
	$i=$i+1;*/
	
	
}
?>
<?php require_once('connect.php');
if (isset($_POST['vevo'])){
	$ertek=$_POST['a'];	
	$vnev=$_POST['vevo'];
    $dat = $_POST['date'];	
	$i=0;
	while ($i<count($ertek)) {
    $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$i', '$ertek[i]', '{$vnev}', '$dat')";
	$connect->query($sql);
	$i=$i+1;
	}
	echo "jo";
}
?>
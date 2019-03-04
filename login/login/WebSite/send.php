<?php require_once('connectG.php');
if (isset($_POST['vevo'])){
	$id=$_POST['id'];
	$ertek=$_POST['ammountOfProducts'];	
	$vnev=$_POST['vevo'];
    $dat = $_POST['date'];	
	$i=0;
	$sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$id', '$ertek', '$vnev', '$dat')";
	$connect->query($sql);
	/*while ($i<count($ertek)) {
    $sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('$i', '$ertek[$i]', '{$vnev}', '$dat')";
	$connect->query($sql);
	$i=$i+1;*/
	
	echo "jo";
}
?>
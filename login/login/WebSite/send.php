<?php require_once('connect.php');
if (isset($_POST['id'])){
    $id= $_POST['id'];
	$ertek=$_POST['ertek'];	
	$vnev=$_POST['vnev'];
    $muv = $_POST['muv'];	
	$time= date ( string $format [, int $timestamp = time() ] ) : string;
	$sql="INSERT INTO `rend` (`Tkod`, `Tmenny`, `Vnev`, `Vdate`) VALUES ('{$id}', '1', '{$vnev}', '$time')";
		
		if ($connect->query($sql) === TRUE) {
    echo "Record updated successfully";
} else {
    echo "Error updating record: " . $conn->error;
}
		
}
?>
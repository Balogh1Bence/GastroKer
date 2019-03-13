<?php
require_once("connectG.php");
if(isset($_POST["us"]))
{
					 $us=$_POST["us"];

				    $nev=$_POST["nev"]; 
					$adoazon=$_POST["adoazon"];
					$banksz=$_POST["banksz"] ;
					$tel=$_POST["tel"];
					$jelsz=$_POST["jelsz"];
					$email=$_POST["email"];
					$irsz=$_POST["irsz"];
					$varos=$_POST["varos"];
					$utca=$_POST["utca"];
					$szam=$_POST["szam"];
	$sql="UPDATE `vevok` SET `nev`=".$nev.",`adoazon`=".$adoazon.",`banksz`=".$banksz.",`tel`=".$tel.",`jelsz`=".$jelsz.",`email`=".$email.",`uj`=1 WHERE felh=".$us."";
	$connect->query($sql);
	$sql="INSERT INTO `helyek`(`IntAzon`, `irsz`, `varos`, `utca`, `szam`) VALUES ((select azon from vevok where felh=".$us."),".$irsz.",".$varos.",".$utca.",".$szam.")";
	$connect->query($sql);
				
}
?>
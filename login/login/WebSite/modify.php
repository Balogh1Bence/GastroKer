﻿<?php
if(isset['user'])
{
$data=$_GET['user'];
}
else
{
$re="re";
}
?>
<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
          <link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap-grid.css"/>
		  <link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap.css"/>
		<link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="css/foundation.css"/>
	
        <script src="jquery-3.3.1.min.js"></script>
    </head>
    <body class="jumbotron">
        <div class ='kozepre'>
		<form>
		<input type="text" id="nev" placeholder="név" required>
		
		<input type="text" id="adoazon" placeholder="adóazonosító" required>
		 
		<input type="text" id="banksz" placeholder="bankszámla száma" required>
		
		<input type="text" id="tel" placeholder="telefonszám" required>
		
		<input type="text" id="jelsz" placeholder="jelszó" required>
		
		<input type="text" id="email" placeholder="email cím" required>
		
		<input type="text" id="irsz"  placeholder="az ön neve" required>
		
		<input type="text" id="varos" placeholder="város" required>
		
		<input type="text" id="utca" placeholder="utca" required>
		
		<input type="text" id="szam" placeholder="az ön neve" required>
		<input type="button" id="gombMehet" value="mehet" >
		</form>

                  
        </div>

        <script>
    if(re=="re")
	{
		windows.location("index.php");
	}
		function is_ZipCode()
{
 regexp = /^\d{4}$/;
  
        if (regexp.test(document.getElementById("irsz").value))
          {
            return true;
          }
        else
          {
            return false;
          }
}
		$("#gombMehet").click(function()
			{

			
				$.post("modifyUserData.php",
				  {
				  felhnev: <?php echo $data?>, 

				    nev: document.getElementById("nev").value,
					adoazon,
					banksz,
				
				  },
						
			})					
		</script>
    </body>
</html>
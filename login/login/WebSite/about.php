<?php
session_start();

?>
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
          <link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap-grid.css"/>
		  <link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap.css"/>
		<link rel="stylesheet" href="css/bootstrap-4.3.1-dist/css/bootstrap.min.css"/>
		<link rel = "stylesheet" href ="https://www.w3schools.com/w3css/4/w3.css">
<link rel = "stylesheet" href ="w3style.css">
        <link rel="stylesheet" href="css/foundation.css"/>
	
        <script src="jquery-3.3.1.min.js"></script>
		</head>
	<body class="jumbotron">
	<nav class = "w3-bar w3-red" id="bar">
					<div class = "w3-bar-item w3-button w3-mobile">Főoldal</div>
	
					<div   class="w3-bar-item w3-button w3-mobile", id="logout", onclick="log()" >kijelentkezés</div>	
					<div class = "w3-bar-item w3-button w3-mobile">Kapcsolat</div>
					<a href="about.php", style="color:#FFFFFF;"><div class = "w3-bar-item w3-button w3-mobile">A rendelés folyamatáról</div></a>		
					<a href="index.php" style="color:FFFFFF;"><div class= "w3-bar-item w3-button w3-mobile", font size="6">↩</div></a>
</nav>
<h3>
A rendelés mennyiségéről
</h3>
<br>
<p>
Bármennyi árucikket leadhat a megrendelésben, de kérem vegye figyelembe, hogy ha túl sok árut rendel, a rendelést sok idő lesz leadni, és a kiszállítás is több időbe telik.
</p>
<br>
<h3>
A kategóriánkénti szűrésről
</h3>
<br>
<p>
Kérem vegye figyelembe, hogy amennyiben kategóriánként szűrve adja le a rendelést, amint kiválasztotta a rendelés mennyiségé, azt küldje el, majd utána adjon hozzá ujjabb megrendelést.
 </p>

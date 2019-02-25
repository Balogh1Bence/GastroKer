<?php
require_once("connect.php");
if (isset($_POST['email'])){
    $email = $_POST['email'];
	$header="<h1 name='mail'>'$email'</h1>";
    echo $header;
}
?>
<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>


</body>
<form action="jelszo.php" method="post" enctype="multipart/form-data">
<input type="text" name="jelszo">
<br>
<input type="text" name="jelszo2">
<br>
<input type="button" name="kuldes" onclick="send()">
</form>
</html>
<script src="jquery-3.3.1.min.js">
</script>
<script>
    function newPW(clicked) {
        var xhttp;
		var email=document.getElementsByTagName("mail").value;
        var newpsw= document.getElementsByTagName("jelszo").value;
        xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                read();

            }
        };
        
        xhttp.open("POST", "newPW.php", true);
        xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xhttp.send("pw="+newpsw+"&email="+email+""); 

    }
</script>
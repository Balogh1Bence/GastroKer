<?php
require_once("connect.php");
if (isset($_GET['email'])){
    $email = $_GET['email'];
	
	
    
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
<input type="text" id="pw" name="jelszo">
<br>
<input type="text" name="jelszo2">
<br>
<input type="button" id="button" name="kuldes">
</form>
</html>
<script src="jquery-3.3.1.min.js">
</script>
<script>
    
	
        $("#button").click(function()
		{
			console.log("valami");
			var something=<?php echo json_encode($email); ?>;
			let jel=document.getElementById("pw").value;

			  $.post("newPW.php",
			  {
				pw: jel,
				email: something
			  },
			  function(data, status){
				alert("Data: " + data + "\nStatus: " + status);
			  });
			}
			
		);
		
</script>
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
<input type="text" id="pw" placeholder="jelszó" name="jelszo">
<br>
<input type="text" id="pw2" placeholder="jelszó újra" name="jelszo2">
<br>
<input type="button" value="küldés" id="button" name="kuldes">
</form>
</html>
<script src="jquery-3.3.1.min.js">
</script>
<script>
    
	
        $("#button").click(function()
		{
				if(document.getElementById(pw).value==document.getElementById(pw2))
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
					alert("sikeres jelszóváltás erre: "+data );
				  });
				}
			}
			else{
				alert("sikertelen jelszóváltás.");
			}
		);
		
</script>
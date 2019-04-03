<?php
session_start();
if(!isset($_SESSION['name']))
{
$_SESSION['name']="";
}
?>
<!DOCTYPE html>


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
					<a href="about.php", style="color:#FFFFFF;"><div class = "w3-bar-item w3-button w3-mobile">a rendelés folyamatáról</div></a>
					
				<div id="filters">
			</div>
</nav>
        <div class ='kozepre'>
            <div class="page-header">
                    <h1 id="bej" class="beljebbKezdes">
                        <font class="felkoverSerif">
                        Bejelentkezés
                        </font>
                    </h1>
            </div>
			<br>
			<div id="tartalom">
			
			</div>
		
			<form id="sendall">
			<input type="button" value="rendelés küldése" onclick="sender()"></button>
			
			
			
		
			</form>
		
			<form id="szam">
			<div disabled="disabled" id="szamlalo" value="0"></div>
			</form>
			
            <div id="urlapTarolo" class="jumbotron">
                <form>
                    <div id="formElemek" class="beljebbKezdes">
                        <input name="felhNev" id="felhNevMezo" class="kitoltendoMezo" type='text' placeholder="Felhasználói név" onkeyup="ellenorzes()">
                        <div id="hibaFelh" class="hibaVisszaJelzes">                            
                        </div>
                       
                        <br>
                        <input name="jelszo" id="jelszo" class="kitoltendoMezo" type="password" placeholder="Jelszó" onkeyup="ellenorzes()">
						<input type="checkbox" onclick="myFunction2()">Show Password 
                        <div id="hibaJelszo" class="hibaVisszaJelzes">                            
                        </div>
                        <br>
                        <div class="linkTaroloKozep">
                          
                        </div>
                        <input id="gombMehet" type="button" class="btn btn-sm btn-primary" value="Mehet"
                                   disabled="disabled">
                        
                    </div>
                </form>
            </div>
        </div>
        <script>
		var data="";
		
		  $.get("filterGenerator.php", function(filter, status){
	document.getElementById("filters").innerHTML=filter;
  });
		var ar;
		
		/*if(!localStorage.getItem(us))
		{
		data=localStorage.getItem(us);
		}*/
		var a;
		var lis= new Array();
		function myFunction2() {
	  var x = document.getElementById("jelszo");
	  if (x.type === "password") {
		x.type = "text";
	  } else {
		x.type = "password";
	  }
	} 
			$("#bar").hide();
			$("#szam").hide();
			$("#sendall").hide();
			$("#logout").hide();
			if("<?php echo $_SESSION['name'];?>"!="")
		{
		data="<?php echo $_SESSION['name'];?>";
		
			$("#urlapTarolo").hide();
								$("#bej").hide();
								$("#szam").show();
								$("#sendall").show();
								$("#logout").show();
								$("#bar").show();
									$.post("loadall.php",
									{
										us: data
									},
										function(t, status){
  
											$("#tartalom").html(t);
											})
		}
				function log()
		{

			
			$.get("logout.php",  function(){location.reload();});
		
			
		}
            function checkUsername()
            {
                if(document.getElementById('felhNevMezo').value.length < 4)
                {
                    document.getElementById('hibaFelh').innerHTML = "Felhasználónév hossza nem megfelelő!";
                    return false;
                }
                else
                {
                    document.getElementById('hibaFelh').innerHTML = "";
                    return true;
                }  
            }
            
            function checkPassword()
            {
                if(document.getElementById('jelszo').value.length < 4)
                {
                    document.getElementById('hibaJelszo').innerHTML = "A jelszó nem megfelelő hosszúságú!";
                    return false;
                }
                else
                {
                    document.getElementById('hibaJelszo').innerHTML = "";
                    return true;
                }
            }            
            
            function unloadconten()
			{
		
			document.getElementById('tartalom').innerHTML = "";
			}
			function loadNewContent(kategoria)
			{
		
				unloadconten();
				$.post("szur.php",
  {
    kat: kategoria
  },
  function(cont){
  	document.getElementById('tartalom').innerHTML = cont;
  });
			
			}
            function ellenorzes()
            {
                if(checkUsername() && checkPassword())
                {
                    $('#gombMehet').prop('disabled', false);
                }
                else
                {
                    $('#gombMehet').prop('disabled', true);
                }
			}
			
			$("#gombMehet").click(function()
			{
			
				$.post("login.php",
				  {
					us: document.getElementById("felhNevMezo").value,
					pw: document.getElementById("jelszo").value
				  },
						  function(data2, status){
							data=data2;
							
							if(data=="sikertelen bejelentkezés")
							{
								alert(data);
								window.location.replace("index.php");
							}
							if(data=="0")
							{
								console.log("nem jo");
							}
							else{
										 $.post( "elsoe.php", {us: data}, function( uj ) {
											  if(uj=="0")
											  {

											  console.log("uj"); 
												window.location.replace("modify.php?user="+data+"");
											  }
										});
								$("#urlapTarolo").hide();
								$("#bej").hide();
								$("#szam").show();
								$("#sendall").show();
								$("#logout").show();
								$("#bar").show();
									$.post("loadall.php",
									{
										us: data
									},
										function(t, status){
  
											$("#tartalom").html(t);
											})}
						  
						}
				)
			})			
				 

					
				
				 
				  
	
	
	
	function onemore(termek, vale)
	{
	document.getElementsByName(termek)[0].innerHTML=Number(document.getElementsByName(termek)[0].innerHTML)+Number(1);

		a=document.getElementsByTagName("span");
			
	
	
	var i= 0;
	while(i<a.length)
	{
	lis[i]=a[i];
	console.log(a[i].innerHTML);
	i++;
	}
		
		ar=$( "#szamlalo" ).html();

		ar=eval(Number(ar)+Number(vale));

		$( "#szamlalo" ).html(ar);
	

	}

  
	
	function oneless(termek, vale)
	{

	if(document.getElementsByClassName(termek)[0].innerHTML==0)
	{
	return;
	}
	document.getElementsByName(termek)[0].innerHTML=Number(document.getElementsByName(termek)[0].innerHTML)-Number(1);

	a=document.getElementsByTagName("span");

	var i= 0;
	while(i<a.length)
	{
	lis[i]=a[i];
	console.log(a[i].innerHTML);
	i++;
	}


		ar=$( "#szamlalo" ).html();
		
		ar=eval(Number(ar)-Number(vale));
		
		$( "#szamlalo" ).html(ar);
		var all=document.getElementsByTagName("textbox").value;
		
		




	}
	function getDate()
	{
	var i= 0;
	while(i<a.length)
	{
	lis[i]=a[i];
	console.log(a[i].innerHTML);
	i++;
	}
	var d = new Date();

var month = d.getMonth()+1;
var day = d.getDate();

var output = d.getFullYear() + '-' +
    (month<10 ? '0' : '') + month + '-' +
    (day<10 ? '0' : '') + day;
	return output;
	}

	function sender()
	{
	var eredmeny;
	var i= 0;
	while(i<a.length)
	{

	var eredmeny;
	 $.post("send.php",
			{
				id: Number(i+1),
				ammountOfProducts: a[i].innerHTML,
				vevo: data,
				date: getDate()


			},
				function(_eredmeny){
					eredmeny=_eredmeny;
				if(eredmeny=="jo")
					console.log(" ");
				}
			);
				i++;
			}
		
			if(eredmeny=="sikeresen leadva a rendelés")
			{
				alert("sikeres vásárlás");
				
			}
			else if(eredmeny=="sikeresen hozzáadva a rendeléshez")
				alert("vásárlás sikeresen frissítve");
			else
				alert("vásárlás sikertelen");
			
	

	}
	











            
		</script>
    </body>
</html>

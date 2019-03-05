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
       
        <link rel="stylesheet" href="css/foundation.css"/>
        <script src="jquery-3.3.1.min.js"></script>
    </head>
    <body class="jumbotron">
        <div class ='kozepre'>
            <div class="page-header">
                    <h1 id="bej" class="beljebbKezdes">
                        <font class="felkoverSerif">
                        Bejelentkezés
                        </font>
                    </h1>
            </div>
			<div id="tartalom">
			
			</div>
			<button id="sendall" onclick="sender()">send all</button>
			<form id="szam">
			<div disabled="disabled" id="szamlalo" value="0"></div>
			</form>
			
            <div id="urlapTarolo" class="jumbotron">
                <form>
                    <div id="formElemek" class="beljebbKezdes">
                        <input name="felhNev" id="felhNevMezo" class="kitoltendoMezo" type='text' placeholder="Felhasználói név" onkeyup="ellenorzes()">
                        <span id="hibaFelh" class="hibaVisszaJelzes">                            
                        </span>
                        <a id="regGomb" href="regisztracio.php" tabindex="4">
                            Regisztráció
                        </a>
                        <br>
                        <input name="jelszo" id="jelszo" class="kitoltendoMezo" type="password" placeholder="Jelszó" onkeyup="ellenorzes()">
                        <span id="hibaJelszo" class="hibaVisszaJelzes">                            
                        </span>
                        <br>
                        <div class="linkTaroloKozep">
                            <a id="regGombKozep" href="regisztracio.php" tabindex="4">
                                Regisztráció
                            </a>
                        </div>
                        <input id="gombMehet" type="button" class="btn btn-sm btn-primary" value="Mehet"
                                   disabled="disabled">
                        <div class="linkTaroloMini">
                            Még nem regisztrált 
                            <br> 
                            felhasználó? 
                            <br>
                            Megteheti itt: 
                            <a id="regGombMini" href="regisztracio.php" tabindex="4">
                                Regisztráció
                            </a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <script>
		var ar;
		var data="";
		var a;
			$("#szam").hide();

            function felhNevEllenorzes()
            {
                if($('#felhNevMezo').val().length < 4)
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
            
            function jelszoEllenorzes()
            {
                if($('#jelszo').val().length < 4)
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
            
            
            function ellenorzes()
            {
                if(felhNevEllenorzes() && jelszoEllenorzes())
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
						  function(data, status){
							data=data;
							alert(data);
							if(data=="0")
							{
								console.log("nem jo");
							}
							else{
								$("#urlapTarolo").hide();
								$("#bej").hide();
								$("#szam").show();
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

	 $.post("send.php",
			{
				ammountOfProducts: a,
				vevo: data,
				date: getDate()


			},
				function(eredmeny){
				if(eredmeny=="jo")
					alert("Data: " + data + "\nStatus: " + status);
				}
			);
	}
	



            
		</script>
    </body>
</html>

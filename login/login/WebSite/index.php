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
	
		console.log(document.getElementsByClassName(termek).value);
		

		
		ar=$( "#szamlalo" ).html();

		ar=eval(Number(ar)+Number(vale));

		$( "#szamlalo" ).html(ar);
	

	}

  
	
	function oneless(termek, vale)
	{

		console.log(document.getElementsByClassName(termek));
		ar=$( "#szamlalo" ).html();
		
		ar=eval(Number(ar)-Number(vale));
		
		$( "#szamlalo" ).html(ar);
	}
	



            
		</script>
    </body>
</html>

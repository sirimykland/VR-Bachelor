window.onload = function(){
    		game = "Atom Crusher";
    		level = 201;
    		showTable();
    	};
    	function gameClick(thisGame){
    		window.game = thisGame;
    		switch(window.game) {
  				case "Atom Crusher":
  					window.level = 201;
    				 var btn = document.getElementById("Easy");
    				 btn.checked = true;
    				 var label = btn.parentElement;
    				 label.classList.add("active");
    				 levelClick(label);				 
    				 document.getElementById("label-normal").classList.remove("active");
   				 break;
  				case "Molecular Memory":
    				window.level = 101;
    				var btn = document.getElementById("Level 1");
    				btn.checked = true;
    				var label = btn.parentElement;
    				 label.classList.add("active");
    				 levelClick(label);		
    				 document.getElementById("label-2").classList.remove("active");
    				 document.getElementById("label-3").classList.remove("active");
    				break;
  				case "Atom Thrower":
    				window.level = 301;
    				showTable();
    				break;
  				default:
    				window.level = null;
    				showTable();
			}		
    	}
      function levelClick(label){
        var btn = label.children;
        window.level = btn[0].value;
        showTable();
        if (window.game == "Atom Crusher") {
        		document.getElementById("level_headerA").innerHTML = btn[0].id;
        }
        else if (window.game == "Molecular Memory") {
        		document.getElementById("level_headerM").innerHTML = btn[0].id;
        }
      }
      function showTable() {
        var levelID = window.level;
        if (levelID == null) {
          document.getElementById("errorDisplay").innerHTML = "Error in displaying leaderboard";
          return;
        } else {
            if (window.XMLHttpRequest) {
              // code for IE7+, Firefox, Chrome, Opera, Safari
              xmlhttp = new XMLHttpRequest();
            } else {
              // code for IE6, IE5
              xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function() {
              if (this.readyState == 4 && this.status == 200) {
                  switch(window.game){
							case "Atom Crusher":
								document.getElementById("dataTableCrusher").innerHTML = this.responseText;
								break;	 
							case "Molecular Memory":
								document.getElementById("dataTableMemory").innerHTML = this.responseText;
								break;	       
							case "Atom Thrower":
								document.getElementById("dataTableThrower").innerHTML = this.responseText;
								break;	                       
                  }
              }
            }
            xmlhttp.open("GET","http://www.ux.uis.no/~sirim/GetLeaderboard.php?levelID="+levelID,true);
            xmlhttp.send();
        }
      }
<?php

session_start();

?>

<!DOCTYPE html>
<html>
  <head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="style.css">
    <meta charset="utf-8">
    <title> VR Bachelor 2019</title>
    <script src="script.js"></script>
  </head>
  <body>
  <div class="container">
    <header>
      <nav class="navbar fixed-top navbar-light bg-light">
          <div >
              <a href="http://www.ux.uis.no/~sirim/" id="home-btn"> <span class="glyphicon glyphicon-home"> </span>  VR Bachelor UiS </a>
          </div>
          <ul class="nav" id="myTab" role="tablist">
            <li class="nav-item active">
              <a class="nav-link active" id="crusher-tab" onclick="gameClick('Atom Crusher')" data-toggle="tab" href="#crusher" role="tab" aria-controls="crusher" aria-selected="true">Atom Crusher</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" id="memory-tab" onclick="gameClick('Molecular Memory')" data-toggle="tab" href="#memory" role="tab" aria-controls="memory" aria-selected="false">Molecular Memory</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" id="throw-tab" onclick="gameClick('Atom Thrower')" data-toggle="tab" href="#throw" role="tab" aria-controls="throw" aria-selected="false">Atom Thrower</a>
            </li>
          </ul>
			<?php

          	if($_SESSION['isAllowed'] == 1) {
          		echo "<div class='user'> Logged in as <strong>" . $_SESSION['user'] . "</strong></div>";
          		echo "<a href='http://www.ux.uis.no/~sirim/Admin.php'> <button id='login' class='btn btn-secondary' type='button'> Admin Page</button> </a>";
					echo "<div> <a href='http://www.ux.uis.no/~sirim/Logout.php' > <button id='login' class='btn btn-primary' type='button'>Log Out</button> </a> </div>";
				} else {
   				 echo "<div> <a href='http://www.ux.uis.no/~sirim/Login.php' > <button id='login' class='btn btn-primary' type='button'>Login</button> </a> </div>";
				}
      	?>
          <div>
            
          </div>
      </nav>
    </header>

    <div class="tab-content">
      <div class="tab-pane active" id="crusher" role="tabpanel" aria-labelledby="crusher-tab">
        <div class="container">
          <h1> Atom Crusher </h1>
          <h3 class="text-muted" id="level_headerA"> Easy </h3>
          </br>
           <div class="btn-group" data-toggle="buttons">
             <label class="btn btn-secondary active" onclick="levelClick(this)">
               <input type="radio" name="levels" class="level_buttons" id="Easy" value="201" autocomplete="off" checked> Easy
             </label>
             <label class="btn btn-secondary" id="label-normal" onclick="levelClick(this)">
               <input type="radio" name="levels" class="level_buttons" id="Normal" value="202" autocomplete="off"> Normal
             </label>
           </div>
          <a class="btn_refresh" onclick="showTable()"><span class="glyphicon glyphicon-refresh"></span></a>
          <div id="dataTableCrusher">
          </div>
        </div>
      </div>
      <div class="tab-pane" id="memory" role="tabpanel" aria-labelledby="memory-tab">
        <div class="container">
          <h1> Molecule Memory </h1>
          <h3 class="text-muted" id="level_headerM"> Level 1</h3>
          </br>
          <div class="btn-group" data-toggle="buttons">
           	<label class="btn btn-secondary active" onclick="levelClick(this)">
            	<input type="radio" name="levels" value="101" id="Level 1" autocomplete="off"> Level 1
           	</label>
           	<label class="btn btn-secondary" id="label-2" onclick="levelClick(this)">
           		<input type="radio" name="levels" value="102" id="Level 2" autocomplete="off"> Level 2
           	</label>
           	<label class="btn btn-secondary" id="label-3" onclick="levelClick(this)">
           		<input type="radio" name="levels" value="103" id="Level 3" autocomplete="off"> Level 3
           	</label>
          	</div>
          <a class="btn_refresh" onclick="showTable()"><span class="glyphicon glyphicon-refresh"></span></a>
          <div id="dataTableMemory">
          </div>
        </div>
      </div>
      <div class="tab-pane" id="throw" role="tabpanel" aria-labelledby="throw-tab">
        <div class="container">
          <h1> Atom Thrower </h1>
          <a class="btn_refresh" onclick="showTable()"><span class="glyphicon glyphicon-refresh"></span></a>
          <div id="dataTableThrower">
          </div>
        </div>
      </div>
    </div>
	<div id="errorDisplay"></div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
	</div>  
  </body>
</html>
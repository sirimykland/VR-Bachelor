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
    <title> VR Bachelor 2019 | Logout </title>
</head>
<body>
	<div class="container">
  			<header>
      		<nav class="navbar fixed-top navbar-light bg-light">
          		<div >
          		    <a href="http://www.ux.uis.no/~sirim/" id="home-btn"> <span class="glyphicon glyphicon-home"> </span>  VR Bachelor UiS </a>
         		 </div>
          		<div>
          		  <a href="http://www.ux.uis.no/~sirim/Login.php" > <button id="login" class="btn btn-primary" type="button" disabled>Log Out</button> </a>
         		 </div>
      		</nav>
    		</header>  	
  				
  			<h1> Log Out </h1>
  			<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']);?>" method="POST">
					<input type="submit"  class="btn btn-primary" name="submit" value="Log Out" >
					<a href="http://www.ux.uis.no/~sirim/" > <button class="btn btn-secondary" type="button"> Go Back </button> </a>
  			</form>
  			
		<?php
			if ( isset( $_POST['submit'] ) ) {
				session_unset(); 
				session_destroy(); 			
				header("Location: http://www.ux.uis.no/~sirim");	
			}
		?>
	</div> 
</body>
</html>
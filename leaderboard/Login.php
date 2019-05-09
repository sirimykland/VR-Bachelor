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
    <title> VR Bachelor 2019 | Login </title>
    <script>
		function redirectToAdmin(){
			console.log("redirect");
			window.location.replace("http://www.ux.uis.no/~sirim/Admin.php");			
		}
	</script>
</head>
<body>
	<div class="container">
  			<header>
      		<nav class="navbar fixed-top navbar-light bg-light">
          		<div >
          		    <a href="http://www.ux.uis.no/~sirim/" id="home-btn"> <span class="glyphicon glyphicon-home"> </span>  VR Bachelor UiS </a>
         		 </div>
          		<div>
          		  <a href="http://www.ux.uis.no/~sirim/Login.php" > <button id="login" class="btn btn-primary" type="button">Login</button> </a>
         		 </div>
      		</nav>
    		</header>  	
  				
  			<h1> Login </h1>
  			<h3 class="text-muted"> Login to access admin privileges </h3>
  			<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']);?>" method="POST">
  				<div class="form-group">
  					<input type="text" class="form-control" name="username" placeholder="Username" required>
  				</div>
  				<div class="form-group">
  					<input type="password" class="form-control" name="password" placeholder="Password" required>
  				</div>
					<input type="submit"  class="btn btn-primary" name="submit" value="Login" >
					<a href="http://www.ux.uis.no/~sirim/" > <button class="btn btn-secondary" type="button"> Go Back </button> </a>
  			</form>
  			
		<?php
			if ( isset( $_POST['submit'] ) ) {
				$username = $_POST['username']; 
				$pwd = $_POST['password']; 
	
	
				$con = mysqli_connect('mysql2.ux.uis.no','vr2019','au7ahb3k','dbvr2019');
  				if (!$con) {
  	    			die('Could not connect: ' . mysqli_error($con));
  				}

  				mysqli_select_db($con,"dbvr2019");
  				$sql="SELECT * FROM tbl_Admins WHERE Username = '".$username."' AND Password = '". $pwd ."'";
  				$result = mysqli_query($con,$sql);
  				$numRows = mysqli_num_rows($result);
  				if ($numRows > 0) {
  					$_SESSION['user'] = $username;
  					$_SESSION['isAllowed'] = 1;
  					header("Location: http://www.ux.uis.no/~sirim/Admin.php");
				}
				else {
  					echo "<div class='invalidUser'> Username or Password is incorrect </div>";
				}
			} 
		?>
	</div> 
</body>
</html>
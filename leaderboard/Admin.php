<?php

session_start();

if($_SESSION['isAllowed'] == 1) {
	
} else {
    header("Location: http://www.ux.uis.no/~sirim/Login.php");
}
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
    <title> VR Bachelor 2019 | Admin </title>
  </head>
  <body>
  	<div class="container">
		<header>
      <nav class="navbar fixed-top navbar-light bg-light">
          <div >
              <a href="http://www.ux.uis.no/~sirim/" id="home-btn"> <span class="glyphicon glyphicon-home"> </span>  VR Bachelor UiS </a>
          </div>
          
          <?php
          	echo "<div class='user'> Logged in as <strong>" . $_SESSION['user'] . "</strong></div>";
      	?>
          <div>
            <a href="http://www.ux.uis.no/~sirim/Logout.php" > <button id="login" class="btn btn-primary" type="button">Log Out</button> </a>
          </div>
      </nav>
    </header>  	
  	
  	
  		<h1> Admin Page </h1>
  		<h4 class="text-muted"> On this page the admin is allowed to reset the Leaderboards for different games. All data will be deleted. </h4>
  		<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']);?>" method="POST" id="form_reset">
  				<div class="form-group">
  					<label> Atom Crusher </label>
  					<input type="submit"  class="btn btn-danger btn_reset" name="submitCrusher" value="Reset Atom Crusher" >
  				</div>
  				<div class="form-group">
  					<label> Molecular Memory </label>
  					<input type="submit"  class="btn btn-danger btn_reset" name="submitMemory" value="Reset Molecular Memory" >
  				</div>
  				<div class="form-group">
  					<label> Atom Thrower </label>
  					<input type="submit"  class="btn btn-danger btn_reset" name="submitThrower" value="Reset Atom Thrower" >
  				</div>
  		</form>
  		
  		<?php
  			$con = mysqli_connect('mysql2.ux.uis.no','vr2019','au7ahb3k','dbvr2019');
  			if (!$con) {
  	    		die('Could not connect: ' . mysqli_error($con));
  			}

  			mysqli_select_db($con,"dbvr2019");
  			
  			if ( isset( $_POST['submitCrusher'] ) ) {
  				try {
  					$sql="DELETE FROM tbl_Scores WHERE LevelID = '". 201 ."' OR LevelID = '". 202 ."'";
  					$result = mysqli_query($con,$sql);
  					$numRows = mysqli_num_rows($result);
  					echo "<script> alert('Leaderboard for Atom Crusher successfully reset') </script>";
				}

				catch(Exception $e) {
  					echo "<script> alert('Error while resetting Leaderboard for Atom Crusher') </script>";
				}		
			}
			
			if ( isset( $_POST['submitMemory'] ) ) {
  				try {
  				$sql="DELETE FROM tbl_Scores WHERE LevelID = '". 101 ."' OR LevelID = '". 102 ."' OR LevelID = '". 103 ."'";
  				$result = mysqli_query($con,$sql);
  				$numRows = mysqli_num_rows($result);
  				echo "<script> alert('Leaderboard for Molecular Memory successfully reset') </script>";
				}

				catch(Exception $e) {
  					echo "<script> alert('Error while resetting Leaderboard for Molecular Memory') </script>";
				}		
			}
			
			if ( isset( $_POST['submitThrower'] ) ) {
  				try {
  				$sql="DELETE FROM tbl_Scores WHERE LevelID = '". 301 ."'";
  				$result = mysqli_query($con,$sql);
  				$numRows = mysqli_num_rows($result);
  				echo "<script> alert('Leaderboard for Atom Thrower successfully reset') </script>";
				}

				catch(Exception $e) {
  					echo "<script> alert('Error while resetting Leaderboard for Atom Thrower') </script>";
				}		
			}
  		?>
  	</div>
  </body>
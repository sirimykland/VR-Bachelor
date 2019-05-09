<?php
    
	$servername = "mysql2.ux.uis.no";
	$username = "vr2019";
	$password = "au7ahb3k";
	$dbname = "dbvr2019";

// Create connection
	$conn = mysqli_connect($servername, $username, $password, $dbname);

// Check connection
	if (!$conn) {
    	die("Connection failed: " . mysqli_connect_error());
	}	
		echo "Connected successfully\n";
      
        
    $Player_Name = $_POST['Player_Name'];
    $Score = $_POST['Score'];
    $LevelID = $_POST['LevelID'];



	$sql = "INSERT INTO tbl_Scores (LevelID, Player_Name, Score) 
			  VALUES ('$LevelID','$Player_Name', '$Score');";
	if ($conn->query($sql) === TRUE) {
  		echo $Player_Name . " was added as a new record created successfully";
	} else {
	   echo "Error: " . $Player_Name . $sql . "<br>" . $conn->error;
	}

$conn->close();

?>

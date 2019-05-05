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
		//echo "Connected successfully";
		
      
    $LevelID = $_POST['LevelID'];
    $Limit = $_POST['Limit'];
   
    
    $sql = sprintf("SELECT ScoreID, Player_Name, Score FROM tbl_Scores WHERE LevelID=%s ORDER BY Score DESC LIMIT %s;", $LevelID, $Limit);
    // denne funker SELECT Player_Name, Score FROM tbl_Scores WHERE LevelID = 201 ORDER BY Score DESC LIMIT 3;
    
    $results = $conn->query($sql);
    
 
    
		//Initialize array variable
 		$dbdata = array();

	 $i=0;
    if ($results->num_rows > 0) {
    		while($row = $results -> fetch_assoc()){
    				$dbdata[] = $row ;
    		}
	 } 



//Print array in JSON format
 	echo json_encode($dbdata);
 
 
    //And now iterate through our results
    //for($i = 0; $i <=$result_length; $i++)
    
    $conn->close();
?>

<?php
    //Again, fill in your server data here!
    $db = mysql_connect('SQLHOST', 'SQLUSER', 'SQLPASSWORD') or die('Failed to connect: ' . mysql_error());
        mysql_select_db('YOURDATABASE') or die('Failed to access database');

     //This query deletes all entries of the Score table.
    $query = "DELETE * FROM Scores";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
?>

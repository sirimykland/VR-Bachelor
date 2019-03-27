<?php
        //You have to fill in this information to connect to your database!
        $db = mysql_connect('SQLHOST', 'SQLUSER', 'SQLPASSWORD') or die('Failed to connect: ' . mysql_error());
        mysql_select_db('YOURDATABASE') or die('Failed to access database');
        //These are our variables.
        //We use real escape string to stop people from injecting. We handle this in Unity too, but it's important we do it here as well in case people extract our url.
        $username = mysql_real_escape_string($_GET['username'], $db);
        $score = mysql_real_escape_string($_GET['score'], $db);
        $game = mysql_real_escape_string($_GET['game'], $db);
        $hash = $_GET['hash'];

        //This is the polite version of our name
        $formattedname = format_string($username);

        //This is your key. You have to fill this in! Go and generate a strong one.
        $secretKey="ebba3c2d54e68e4bdd33b638d48cb4ab"; //BachelorOppgave2019

        //We md5 hash our results.
        $expected_hash = md5($username . $score . $game . $secretKey);

        //If what we expect is what we have:
        if($expected_hash == $hash) {
            // Here's our query to insert/update scores!
            $query = "INSERT INTO Score
                      SET username = '$formattedname',
                         score = '$score',
                          game = '$game'";
            //And finally we send our query.
            $result = mysql_query($query) or die('Query failed: ' . mysql_error());
        }
/////////////////////////////////////////////////
// string sanitize functionality to avoid
// sql or html injection abuse and bad words
/////////////////////////////////////////////////

function my_utf8($string)
{
    return strtr($string,
      "/<>€µ¿¡¬ˆŸ‰«»Š ÀÃÕ‘¦­‹³²Œ¹÷ÿŽ¤Ððþý·’“”ÂÊÁËÈÍÎÏÌÓÔ•ÒÚÛÙž–¯˜™š¸›",
      "![]YuAAAAAAACEEEEIIIIDNOOOOOOUUUUYsaaaaaaaceeeeiiiionoooooouuuuyy");
}
function safe_typing($string)
{
    return preg_replace("/[^a-zA-Z0-9 \!\@\%\^\&\*\.\*\?\+\[\]\(\)\{\}\^\$\:\;\,\-\_\=]/", "", $string);
}
function format_string($string)
{
    // make sure it isn't waaaaaaaay too long
    $MAX_LENGTH = 30; // bytes per chat or text message - fixme?
    $string = substr($string, 0, $MAX_LENGTH);
    $string = my_utf8($string);
    $string = safe_typing($string);
    return trim($string);
}
?>

<!DOCTYPE html>
<html>
<head>
<style>

</style>
</head>
<body>

  <?php
  $levelID = intval($_GET['levelID']);

  $con = mysqli_connect('mysql2.ux.uis.no','vr2019','au7ahb3k','dbvr2019');
  if (!$con) {
      die('Could not connect: ' . mysqli_error($con));
  }

  mysqli_select_db($con,"dbvr2019");
  $sql="SELECT * FROM tbl_Scores WHERE LevelID = '".$levelID."' ORDER BY Score DESC";
  $result = mysqli_query($con,$sql);

  echo "<table class='table'>
    <thead>
      <tr>
        <th> # </th>
        <th> Name </th>
        <th> Score </th>
      </tr>
    </thead>
    <tbody>";
  while($row = mysqli_fetch_array($result)) {
      $i = 1;
      echo "<tr>";
      echo "<td>" . $i++ . "</td>";
      echo "<td>" . $row['Player_Name'] . "</td>";
      echo "<td>" . $row['Score'] . "</td>";
      echo "</tr>";
  }
  echo "</tbody>
  </table>";
  mysqli_close($con);
  ?>
</body>
</html>

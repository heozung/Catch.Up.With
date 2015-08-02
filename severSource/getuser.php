<?php
require_once('config.php');
$result = mysql_query("SELECT username from ChildrenCode where hwid='".$_GET['hwid']."'");
while($row = mysql_fetch_array($result))
  {
  echo $row['username'];
  }
?> 
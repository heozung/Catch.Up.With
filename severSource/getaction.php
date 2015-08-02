<?php
require_once('config.php');
$result = mysql_query("SELECT action from ChildrenCode where hwid='".$_GET['hwid']."'");
while($row = mysql_fetch_array($result))
  {
  echo $row['action'];
  }
mysql_query("Update ChildrenCode set action='' where hwid='".$_GET['hwid']."'");
?> 
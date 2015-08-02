<title>Children Sec</title>
<?php
require_once('config.php');
$user="";
$hwid="";
$result = mysql_query("SELECT username from ChildrenCode where username='".$_GET['username']."'");
while($row = mysql_fetch_array($result))
  {
  $user=$row['username'];
  }
$result = mysql_query("SELECT hwid from hwid where hwid='".$_GET['hwid']."'");
while($row = mysql_fetch_array($result))
  {
  $hwid=$row['hwid'];
  }
if ($user!="" and $hwid!="")
{
	mysql_query("UPDATE ChildrenCode SET username='".$user."',cpname='".$_GET['cpname']."' WHERE hwid='".$_GET['hwid']."'");
	echo "success";
}
elseif ($user!="" and $hwid=="")
{
	mysql_query("Insert into ChildrenCode(hwid,username,cpname) values('".$_GET['hwid']."','".$user."','".$_GET['cpname']."')");
	echo "success";
}
else
{
	echo "error";
}
?> 
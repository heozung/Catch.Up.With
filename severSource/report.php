<?php
require_once('config.php');
$hwid=$_POST['hwid'];
$thoigian=$_POST['thoigian'];
$content=$_POST['content'];
mysql_query("Insert Into ChildrenCode(hwid,thoigian,content) values('".$hwid."','".$thoigian."','".$content."')");
?>
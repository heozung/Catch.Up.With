<?php
error_reporting(0);
require_once('config.php');
function setaction($action,$hwid,$user)
{
	mysql_query("UPDATE ChildrenCode SET action='".$action."' WHERE username='".$user."' and hwid='".$hwid."'");
	echo "<div class=\"alert alert-success\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Thông báo!</strong>Đã thực hiện lệnh điều khiển. </div>";
}
?>
<?php
error_reporting(0);
$db_host = "localhost"; // Giữ mặc định là localhost
$db_name    = 'vntalkin_testDB';// Can thay doi
$db_username    = 'root'; //Can thay doi
$db_password    =  '';//Can thay doi
mysql_connect($db_host, $db_username, $db_password) or die("Không thể kết nối database");
mysql_select_db($db_name) or die("Không thể chọn database");
?>
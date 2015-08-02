<?php
//HoangXL@hoangxl.co.cc

$xl_title = "Image Log - iKID - 2013 ";
$xl_folder = "photoz/";
$Gallery_Cat = @fopen("databasez/gallery.cat.xl", "r") or die('Khong the ket noi voi co so du lieu');

while (!feof($Gallery_Cat)) {
$Cat_names[] = fgets($Gallery_Cat); 
}
fclose($Gallery_Cat);

?>
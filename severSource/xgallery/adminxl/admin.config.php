<?php
//HoangXL@hoangxl.co.cc
if(!defined('HoangXL')) exit('direct access is not allowed.');

$xl_folder = "../photoz/";
$NumUpload = 5;
$blacklist = array(".php", ".phtml", ".zip", ".rar");

$Gallery_Cats = '../databasez/gallery.cat.xl';
$UserData = '../databasez/user.xl';
$Gallery_Cat = @fopen($Gallery_Cats, "r") or die('Khong the ket noi voi co so du lieu');
while (!feof($Gallery_Cat)) {
$Cat_names[] = fgets($Gallery_Cat); 
}
fclose($Gallery_Cat);

?>
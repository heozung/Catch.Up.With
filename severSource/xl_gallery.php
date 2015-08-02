<meta charset="utf-8" />
<title>Children Security 2014 LNH</title>
<script type="text/javascript" src="imagez/js/prototype.js"></script>
<script type="text/javascript" src="imagez/js/scriptaculous.js?load=effects,builder"></script>
<script type="text/javascript" src="imagez/js/lightbox.js"></script>
<link rel="stylesheet" href="imagez/css/lightbox.css" type="text/css" media="screen" />
<?php

include ('xl_config.php');
include ('xl_funtions.php');
$id = $_GET['ID'];
$config['size'] = 120;
$config['imagequality'] = 70; 
$config['rows'] = 3;
$config['cols'] = 4; 
$config['maxShow'] = 10;
$config['fulls'] = $xl_folder."report/"; 
$config['thumbs'] = $xl_folder."report/thumbs/"; 
$config['start']=0;
$config['max']=0;
$config['page']=isset($_GET['page'])?$_GET['page']:"0";
$link = "?xl=Gallery&ID=$id";
function PrintThumbs(){
	global $config,$title,$i,$id,$xl_title;
	if (!file_exists($config['fulls'])) {
	$msg = "Thư mục chứa dữ liệu của <b>$title</b> chưa được tạo.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;
	}
	if (!file_exists($config['thumbs'])) { 
		if (!@mkdir($config['thumbs'], 0755)) {
	$msg = "Không thể tạo được thư mục Thumbnail cho <b>$title</b>.<br>- Kiểm tra lại quyền truy xuất cho thư mục này.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;
		}
	}
    $imagelist = GetFileList($config['fulls']);
	$config['start'] = ($config['page']*$config['cols']*$config['rows']);
	$config['max'] = ( ($config['page']*$config['cols']*$config['rows']) + ($config['cols']*$config['rows']) );
	if($config['max'] > count($imagelist)){$config['max']=count($imagelist);}
	if($config['start'] > count($imagelist)){$config['start']=0;}
	echo '<table border="0" cellpadding="0" cellspacing="0" align="center" width="95%">';
	echo "<tr>\n<td colspan=\"$config[cols]\" class=\"entries\"></td></tr>";
	echo "<tr><td colspan=\"$config[cols]\" width=\"100%\"><br></td></tr>";
	$column_counter = 1;	
	echo "<tr>\n";
	for($i=$config['start']; $i<$config['max']; $i++){

		$thumb_image = $config['thumbs'].$imagelist[$i];
		$thumb_exists = file_exists($thumb_image);
		if(!$thumb_exists){
			set_time_limit(30);
			if(!($thumb_exists = ResizeImageUsingGD("$config[fulls]$imagelist[$i]", $thumb_image, $config['size']))){
				$msg = "Không thể tạo Thumbnail cho <b>$title</b>.<br>- Kiểm tra lại quyền truy xuất cho thư mục này.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;
			
			}
		}

		$imagelist[$i] = rawurlencode($imagelist[$i]);
		echo '<td>';
			echo '<br><a href="'. $config['fulls'].$imagelist[$i].'" title="'.$xl_title.' -> '.$title.' -> '.$imagelist[$i].'" rel="lightbox[roadtrip]">'; 
			echo '<img src="'. $config['thumbs'].$imagelist[$i] .'" title="[ Xem ảnh ]" style="border: 2px dotted #aebbc7;">';
			echo '</a><br>&nbsp;';
		echo '</td>'."\n";

		if(($column_counter == $config['cols']) && ($i+1 != $config['max'])){
			echo "</tr>\n\n<tr>";
			echo "<tr><td colspan=\"$config[cols]\" width=\"100%\"><hr width=\"90%\"></td></tr>";
			echo "<td colspan=\"$config[cols]\" class=\"spacer\"></td></tr>\n\n<tr>\n";

			$column_counter=0;
		}
		$column_counter++;
	}
	if($config['start'] == $config['max']){
		echo "<td colspan=\"$config[cols]\" class=\"entries\" align=center><br>Chưa có dữ liệu<br><br></td>\n";
	}

	elseif($column_counter != $config['cols']+1){
		echo "<td colspan=\"".($config['cols']-$column_counter+1)."\">&nbsp;</td>\n";
	}

	echo "</tr>\n\n";
	echo "<tr><td colspan=\"$config[cols]\" width=\"100%\"><hr width=\"90%\"></td></tr>";

	echo "<tr>\n<td colspan=\"$config[cols]\" class=\"pagenumbers\">\n";
	echo "</td>\n</tr>\n\n";

	echo "</td></tr></table>\n";
	echo	'<table border="0" cellpadding="0" cellspacing="0">
				<tr><td align=\"left\"><br><b>';
			GetPageNumbers(count($imagelist));	
	echo	'<br><br>	</td></tr>
			</table>';

}
function GetFileList($dirname=".")
{
	global $config;
	$list = array(); 
	$hwid = $_GET['hwid'];
	if ($handle = opendir($dirname)) {
		while (false !== ($file = readdir($handle))) {
			if (preg_match("/(".$hwid.")/i",$file)) 
			{ 
			if (preg_match("/\.(jpe?g|gif|png)$/i",$file)) 
			{ 
				list($filename,$ext) = split('[.]',$file);
				$list[] = $file;
			}
			}
		}
		closedir($handle); 
	}
	$tam  = rsort($list,SORT_NUMERIC);

	return $list;
}

function ResizeImageUsingGD($fullFilename, $thumbFilename, $size) {

	list ($width,$height,$type) = GetImageSize($fullFilename);

	if($im = ReadImageFromFile($fullFilename,$type)){
		if($height <= $size && $width <= $size){
			$newheight=$height;
			$newwidth=$width;
		}
		else if($height > $width){
			$newheight=$size;
			$newwidth=round($width / ($height/$size));
		}
		else{
			$newwidth=$size;
			$newheight=round($height / ($width/$size));
		}

		$im2=ImageCreateTrueColor($newwidth,$newheight);
		ImageCopyResampled($im2,$im,0,0,0,0,$newwidth,$newheight,$width,$height);

		return WriteImageToFile($im2,$thumbFilename,$type);
	}

	return false;
}
function ReadImageFromFile($filename, $type) {
	$imagetypes = ImageTypes();

	switch ($type) {
		case 1 :
			if ($imagetypes & IMG_GIF){
				return ImageCreateFromGIF($filename);
			}
			else{
	$msg = "File type <b>.gif</b> not supported by GD version on server.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;
			}
		break;

		case 2 :
			if ($imagetypes & IMG_JPEG){
				return ImageCreateFromJPEG($filename);
			}
			else{
	$msg = "File type <b>.jpg</b> not supported by GD version on server.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;	
				}
		break;

		case 3 :
			if ($imagetypes & IMG_PNG){
				return ImageCreateFromPNG($filename);
			}
			else{
	$msg = "File type <b>.png</b> not supported by GD version on server.";
	$page = "?xl=Home";
	page_load2($msg,$page);
	return false;
				}
		break;

		default:
			echo("Chỉ hỗ trợ các loại tập tin với định dạng GIF,JPEG,PNG");
		return 0;
	}
}
function WriteImageToFile($im, $filename, $type) {
	global $config;

	switch ($type) {
		case 1 :
			return ImageGIF($im, $filename);
		case 2 :
			return ImageJpeg($im, $filename, $config['imagequality']);
		case 3 :
			return ImagePNG($im, $filename);
		default:
			return false;
	}
}
function GetPageNumbers($entries) {
	global $config;
	global $link;
	$hwid = $_GET['hwid'];
	$prev = "&laquo;Trở lại";
	$next = "Tiếp&raquo;";

	$config['totalPages']=Ceil(($entries)/($config['cols']*$config['rows']));

	$start=0; 
	$end=$config['totalPages']-1;
echo "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trang: ";

	if($config['maxShow'] < $config['page'] || (($config['cols']*$config['rows']*$config['maxShow'])< $entries) ){

		if($config['page'] >= ($config['maxShow']+1) && $config['page'] < $end-$config['maxShow']){ $start = $config['page']-$config['maxShow'];}
		elseif($end < $config['page']+$config['maxShow']+1 && $config['totalPages']-1 >= $config['maxShow']*2+1){$start = $config['totalPages']-1-$config['maxShow']*2;}
		else{$start=0;}

		if( $config['page']+$config['maxShow']+1 > $config['totalPages']-1 ){$end = $entries/($config['cols']*$config['rows']);}
		elseif($start == 0 && $end > $config['maxShow']*2){$end = $config['maxShow']*2;}
		elseif($start == 0 && $config['totalPages'] <= $config['maxShow']*2){$end = $config['totalPages']-1;}
		else{$end = ($config['page']+$config['maxShow']);} //end = page+cutoff+1
	}
	if($start > 0){echo " ... ";}
	else{echo "";}
	for($i=$start; $i<=$end ; $i++){
		if($config['page']==$i){echo "[".($i+1)."] \n";}
		else{echo "<a href=\"$link&hwid=$hwid&page=$i\">".($i+1)."</a>\n";}
	}
	if(Ceil($end) < $config['totalPages']-1){echo " ... ";}
	else{echo "";}

}
PrintThumbs();
?>
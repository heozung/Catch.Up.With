<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');
$sortname = date("Y.m.d_G.i.s");
if(isset($_POST['Submit']))
{	
	if ($_POST['path'] == 'XL_Null'){
	$msg = "<font color=red><b>Lỗi! Bạn chưa chọn thể loại</font>";
	$page = "?xl=Upload";
	page_load($msg,$page);
	return false;
	}
	else
	$GalleryPath= $_POST['path'];
	$fullpath=$xl_folder.$GalleryPath."/";
	if (!is_dir($fullpath)) {
    mkdir($fullpath);
	chmod($fullpath, 0755);
	}
	for($i=1; $i<=$NumUpload; $i++)
		{
			if($_FILES['file_'.$i]['size'] > 0)
				{
					$file_name = $_FILES['file_'.$i]['name'];
					while(file_exists($fullpath.$file_name))
						{
							$file_name = ".xl.".$file_name;
						}
					foreach ($blacklist as $item) 
						{
							if(preg_match("/$item\$/i", $_FILES['file_'.$i]['name'])) 
								{
								$msg = "<font color=red><b>Lỗi! định dạng tập tin bạn upload không được hỗ trợ.</font>";
								$page = "?xl=Upload";
								page_load($msg,$page);
								return false;
								}
						}	
						move_uploaded_file($_FILES['file_'.$i]['tmp_name'], $fullpath.$sortname.$file_name) or die("Không thể upload");
				}
			}
	$msg = "Đã upload <b>".$file_name."</b> thành công.";
	$page = "?xl=Upload";
	page_load($msg,$page);
	return false;
}
?>
<table cellSpacing=0 cellPadding=0 width=100% align=center border=0>
	<tr class=tcat>
		<td width=10 align=center></td>
		<td>.: U p l o a d</td>
	</tr>
</table>
<table border="0" cellspacing="5" cellpadding="5" width="100%">
	<tr>
		<td width="100%" valign="top" align=center>
			<form action="" method="post" enctype="multipart/form-data">
			<table border="0" cellspacing="0" cellpadding="0" width="80%">
				<tr>
					<td align=center><hr><b>Thể loại hình (ảnh) : <?phpGallery_Cat_F();?><hr><br></td>
				</tr>
				<tr>
					<td align=center>
<?php for($i=1; $i<=$NumUpload; $i++): ?>
	Tập tin <?php=$i;?>: <input type="file" name="file_<?php=$i;?>" size="30" /><br /><br />
<?php endfor; ?>
					</td>
				</tr>
				<tr>
					<td align=center>
						<hr><input type="submit" class=butt name="Submit" value="[ Upload ... ]"><hr>
					</td>
				</tr>
			</table>
			</form>
		</td>
	</tr>
</table>
</body>
</html>

	
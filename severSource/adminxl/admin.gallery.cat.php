<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');

if (isset($_POST['Gallery_Cat'])) {
$content = stripslashes($_POST['content']);
$fp = fopen($Gallery_Cats, "w") or die ("Error opening file in write mode!");
fwrite($fp,$content);
fclose($fp) or die ("Error closing file!");
	$msg = "Đã cập nhập xong";
	$page = "?xl=Gallery_Cat";
	page_load($msg,$page);
	return false;
}
?>
<script type="text/javascript" src="../imagez/js/him.js"></script>
<FORM  method="POST" action="<?php echo $_SERVER['PHP_SELF']?>?xl=Gallery_Cat">
<table cellSpacing=0 cellPadding=0 width=100% align=center border=0>
	<tr class=tcat>
		<td width=10 align=center></td>
		<td>.: Quản lý thể loại hình ảnh</td>
	</tr>
</table>
<table cellSpacing=0 cellPadding=0 width=80% border=0 valign=top align=center>
	<tr>
		<td align=center>
			<hr><input type="submit" class=butt value="[ Cập nhật ]"><hr>
			<input TYPE="HIDDEN" name="Gallery_Cat" value="1">
<textarea rows="15" cols="50" name="content">
<?php
echo implode("",file($Gallery_Cats));
?>
</textarea> 
			<hr><input type="submit" class=butt value="[ Cập nhật ]"><hr>
		</td>
	</tr>
</table>
</form>
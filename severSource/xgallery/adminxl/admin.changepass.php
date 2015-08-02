<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');

if (file_exists($UserData))
   $data = parse_ini_file($UserData, true);

if (count($data) > 0) {
             list ( $username, $dataArray) = each($data);
             foreach ($data as $username=>$dataArray) {
                     foreach ($dataArray as $password) {
                          }
                }
        }
if (isset($_POST['userdata'])) {
	if (empty($_POST['passwordnew']) && empty($_POST['passwordnew2']) )
		{
	$msg = "Vui lòng nhập đầy đủ thông tin.";
	$page = "?xl=PassAdmin";
	page_load($msg,$page);
	return false;
		}
	elseif (md5($_POST['passwordold']) !== $password)
		{
	$msg = "Mật mã cũ không đúng";
	$page = "?xl=PassAdmin";
	page_load($msg,$page);
	return false;
		}
	elseif
		($_POST['passwordnew'] !== $_POST['passwordnew2'])
		{
	$msg = "Mật mã mới không giống nhau";
	$page = "?xl=PassAdmin";
	page_load($msg,$page);
	return false;
		}
		else
		{
        $data[$_POST['username']]['password'] = md5($_POST['passwordnew']);
        $changed = true;
		}
}
if ($changed) {
    $fp = fopen($UserData, 'w');

    ksort($data);
    foreach ($data as $key=>$dataArray) {
             fwrite($fp, "[$key]\n");
             foreach ($dataArray as $k => $v) {
                      fwrite($fp, "$k=$v\n");
             }
             fwrite($fp, "\n");
    }
    fclose($fp);
	$msg = "<font color=yellow>Đã thay đổi mật mã thành công</font>";
	$page = "?xl=Home";
	page_load($msg,$page);
	return false;
}
?>

<FORM  method="POST" action="<?php echo $_SERVER['PHP_SELF']?>?xl=PassAdmin">
<input type="HIDDEN"  name="userdata" value="1">
<?php
if (!empty($username))
     echo "<input type=\"HIDDEN\"  name=\"username\" value=\"$username\">";
?>
<table cellSpacing=0 cellPadding=0 width=100% align=center border=0>
	<tr class=tcat>
		<td width=10 align=center></td>
		<td>.: Thay đổi mật mã</td>
	</tr>
</table>
<table cellSpacing=5 cellPadding=5 width=80% border=0 valign=top align=center>
	<tr>
		<td align=right width="40%"><b>Mật mã cũ : 
		</td>
		<td>
			<input type="password"  name="passwordold" size="20" maxlength="20" >
			<input type="hidden"  name="username" size="10" maxlength="10" value='<?php echo $username?>' >
		</td>
	</tr>
	<tr>
		<td align=right width="40%"><b>Mật mã mới : 
		</td>
		<td>
			<input type="password" name="passwordnew" size="20" maxlength="20" >
		</td>
	</tr>
	<tr>
		<td align=right width="40%"><b>Nhập lại mật mã mới : 
		</td>
		<td>
			<input type="password"  name="passwordnew2" size="20" maxlength="20">
		</td>
	</tr>
	<tr>
		<td colspan=2 align=center>
			<hr><input type="submit" class=butt value="[ Thay đổi ]"><hr>
		</td>
	</tr>
</TABLE>
</FORM>
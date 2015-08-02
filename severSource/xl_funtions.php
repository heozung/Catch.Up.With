<?php
function Gallery_Cat_S() {
	global $Gallery_Cat,$Cat_names;
	echo "<form method='GET'>";
	echo '<table border="0" cellspacing="0" cellpadding="0"><input type=hidden name="xl" value="Gallery">';
	echo "<tr><td><b>&nbsp;&nbsp;&nbsp;.: Chọn thể loại </b>:<td>";
	echo "<td><select name='ID' onchange='javascript:this.form.submit();'><option selected>---Chọn---</option>";
	for($i=1; $i < count($Cat_names); $i++) {
$tmp = explode('@', $Cat_names[$i]);
$details[$i]['title'] = $tmp[0];
$details[$i]['path'] = $tmp[1];

echo "<option value=".$i.">". $details[$i]['title'] ."</option>";

}
	echo "</select></td></tr></table></form>";
}
function Gallery_Cat_F() {
	global $Gallery_Cat,$Cat_names;
	echo "<select name='path'>";
	echo "<option value='XL_Null' selected>---Chọn---</option>";
	for($i=1; $i < count($Cat_names); $i++) {
$tmp = explode('@', $Cat_names[$i]);
$details[$i]['title'] = $tmp[0];
$details[$i]['path'] = $tmp[1];
echo "<option value=".$details[$i]['path'].">". $details[$i]['title'] ."</option>";

}
	echo "</select>";
}
function page_load($msg,$page)
{
     $showtext = $msg;
     $page_transfer = $page;
     echo "<meta http-equiv=\"Refresh\" content=\"2; URL=$page_transfer\">";
		echo "<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" height=\"40\">
			<tr class=\"tcat\">
			 <td width=\"100%\" height=\"20\"><font color=white>&nbsp;&nbsp;&nbsp;Xin vui lòng chờ ... </font></td>
			</tr>
		    <tr>
			 <td width=\"100%\" height=\"26\" align=center class=\"row_gris\">$showtext</td></td>
			</tr></TABLE>&nbsp;";
}
function page_load2($msg,$page)
{
     $showtext = $msg;
     $page_transfer = $page;
     echo "<meta http-equiv=\"Refresh\" content=\"2; URL=$page_transfer\">";
		echo "<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" height=\"40\">
			<tr>
			 <td width=\"100%\" height=\"20\"><font color=white>&nbsp;&nbsp;&nbsp;Xin vui lòng chờ ... </font></td>
			</tr>
		    <tr>
			 <td width=\"100%\" height=\"26\" align=center class=\"row_gris\">$showtext</td></td>
			</tr></TABLE>&nbsp;";
}
?>
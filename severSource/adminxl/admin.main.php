<table cellSpacing=0 cellPadding=0 width=100% border=0 valign=top background="../imagez/bg.jpg">
	<tr>
		<td>
<?
if (!defined('HoangXL')) die("direct access is not allowed");
$xl = $_REQUEST['xl'];
switch ($xl ){
	case 'Cat' 	     : include('admin.cat.php');
		break;
	case 'Gallery' 	     : include('admin.gallery.php');
		break;	
	case 'Gallery_Cat' 	     : include('admin.gallery.cat.php');
		break;
	case 'PassAdmin' 	     : include('admin.changepass.php');
		break;
	case 'Upload' 	     : include('admin.upload.php');
		break;
	case 'Home' 	     : include('admin.home.php');
		break;
	default    : include('admin.home.php');
		break;
} 
?>
		</td>
	</tr>
</table>

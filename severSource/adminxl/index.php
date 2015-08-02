<?php
ini_set("display_errors", 1);
session_start();
if(!empty($_GET['logoff'])) { $_SESSION = array(); }
if(empty($_SESSION['exp_user']) || @$_SESSION['exp_user']['expires'] < time()) {
	header("location:login.html");	//@ redirect 
} else {
	$_SESSION['exp_user']['expires'] = time()+(45*60);	//@ renew 45 minutes
}
define('HoangXL',true);
include ('../includez/xl_funtions.php');
include ('admin.config.php');
?>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>.: [ xGallery ] | Admin Control Panel</title>
<link href="../imagez/css/style.css" rel="stylesheet" media="all" />
<script type="text/javascript" src="../imagez/js/prototype.js"></script>
<script type="text/javascript" src="../imagez/js/scriptaculous.js?load=effects,builder"></script>
<script type="text/javascript" src="../imagez/js/lightbox.js"></script>
<link rel="stylesheet" href="../imagez/css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
<center>
<table cellSpacing=0 cellPadding=0 width=700 valign=top>
	<tr height="175" align=center>
	  <td background="../imagez/header_bg.jpg" align=center><font size="5" color=yellow>x G a l l e r y</font><br><font size="3">[ Admin Control Panel ]</font></td>
    </tr>
	<tr>
		<td>
			<table cellSpacing=0 cellPadding=0 width=100% align=center border=0 class=tcat>
				<tr>
					<td><b>&nbsp;&nbsp;&nbsp;.: <a class=a_menu href="?xl=Home">Admin Controls</a> : <a class=a_menu href="?xl=Gallery_Cat">Thể loại hình</a> | <a class=a_menu href="?xl=Gallery&ID=1">Hình ảnh</a> | <a class=a_menu href="?xl=Upload">Upload</a> | <a class=a_menu href="?xl=PassAdmin">Thay đổi mật mã</a> | [ <i><a class=a_menu href="index.php?logoff=1">Thoát</a></i> ]</td>
				</tr>
			</table>		
			<table cellpadding=0 cellspacing=0 width=100% align=center valign=top class=tborder>	
				<tr>
					<td align=center>
<?php include('admin.main.php'); ?>					
					</td>
				</tr>
			</table>								
		</td>
	</tr>
	<tr>
      <td height="78" align=center background="../imagez/footerbg.gif"><br>[ x G a l l e r y ]<br>
      Le Nhat Hung 2014</td>
    </tr>
</table>
</center>	
</body>
</html>

<?php
error_reporting(0);
session_start();
require_once('config.php');
if ( !$_SESSION['user_id'] )
{
    header( 'Location: login.php' );
}
else
{
?>
<!DOCTYPE html>
<!--[if IE 8]>
<html lang="en" class="ie8">
</html>
<![endif]-->
<!--[if IE 9]>
<html lang="en" class="ie9">
</html>
<![endif]-->
<!--[if !IE]>
<!-->
<html lang="en">
<!--<![endif]-->
<head>
<meta charset="utf-8" />
<title>Children Security</title>
<meta content="width=device-width, initial-scale=1.0" name="viewport" />
<meta content="" name="description" />
<meta content="" name="author" />
<link href="./assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="./assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
<link href="./assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
<link href="./css/style.min.css" rel="stylesheet" />
<link href="./css/style_responsive.css" rel="stylesheet" />
<link href="./css/style_gray.css" rel="stylesheet" id="style_color" />
<link href="./assets/fancybox/source/jquery.fancybox.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="./assets/uniform/css/uniform.default.css" />
<link href="./assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css" rel="stylesheet" />
<link href="./assets/jqvmap/jqvmap/jqvmap.css" media="screen" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body class="fixed-top">
<div id="header" class="navbar navbar-inverse navbar-fixed-top">
<div class="navbar-inner">
<div class="container-fluid">
<a class="brand" href="index.php">
<img src="imagez/1403767372_group_half_security.png" />
</a>
<a class="btn btn-navbar collapsed" id="main_menu_trigger" data-toggle="collapse" data-target=".nav-collapse">
<span class="icon-bar">
</span>
<span class="icon-bar">
</span>
<span class="icon-bar">
</span>
<span class="arrow">
</span>
</a>

<div class="top-nav ">
<ul class="nav pull-right top-menu">
<li class="dropdown mtop5">
<a class="dropdown-toggle element" data-placement="bottom" data-toggle="tooltip" href="#" data-original-title="Chat">
<i class="icon-comments-alt">
</i>
</a>
</li>
<li class="dropdown mtop5">
<a class="dropdown-toggle element" data-placement="bottom" data-toggle="tooltip" href="#" data-original-title="Help">
<i class="icon-headphones">
</i>
</a>
</li>
<li class="dropdown">
<a href="#" class="dropdown-toggle" data-toggle="dropdown">
<img src="./img/avatar-mini.png" alt="" />
<span class="username"><?php echo $_SESSION['usernamex']; ?></span>
<b class="caret">
</b>
</a>
<ul class="dropdown-menu">
<li>
<a href="#">
<i class="icon-user">
</i> Chỉnh sửa thông tin</a>
</li>
<li class="divider">
</li>
<li>
<a href="./login.php">
<i class="icon-key">
</i> Đăng xuất</a>
</li>
</ul>
</li>
</ul>
</div>
</div>
</div>
</div>
<div id="container" class="row-fluid">
<div id="sidebar" class="nav-collapse collapse">
<div class="sidebar-toggler hidden-phone">
</div>
<div class="navbar-inverse">
<form class="navbar-search visible-phone" />
<input type="text" class="search-query" placeholder="Search" />
</form>
</div>
<ul class="sidebar-menu">
<li class="has-sub active">
<a href="javascript:;" class="">
<span class="icon-box">
<i class="icon-dashboard">
</i>
</span> Máy tính quản lí <span class="arrow">
</span>
</a>
<ul class="sub">
<?php
$result = mysql_query("SELECT hwid,cpname FROM ChildrenCode where username='".$_SESSION['usernamex']."'");
while($row = mysql_fetch_array($result))
  {
	echo "<li>";
	echo "<a class=\"\" href=\"quanli.php?hwid=".$row['hwid']."\">".$row['cpname']."</a></li>";
  }
?>
</ul>
</li>
<li>
<a class="" href="./login.php">
<span class="icon-box">
<i class="icon-user">
</i>
</span> Đăng xuất</a>
</li>
</ul>
</div>
<div id="main-content">
<div class="container-fluid">
<div class="row-fluid">
<div class="span12">
<div id="theme-change" class="hidden-phone">
<i class="icon-cogs">
</i>
<span class="settings">
<span class="text">Theme:</span>
<span class="colors">
<span class="color-default" data-style="default">
</span>
<span class="color-gray" data-style="gray">
</span>
<span class="color-purple" data-style="purple">
</span>
<span class="color-navy-blue" data-style="navy-blue">
</span>
</span>
</span>
</div>
<h3 class="page-title">Children Security <small> Phần mềm hỗ trợ Phụ Huynh quản lí  và giám sát trẻ em</small>
</h3>
<ul class="breadcrumb">
<li>
<a href="#">
<i class="icon-home">
</i>
</a>
<span class="divider">&nbsp;</span>
</li>
<li>Children Sec<span class="divider">&nbsp;</span>
</li>
<li class="pull-right search-wrap">
<form class="hidden-phone">
<div class="search-input-area">
<input id=" " class="search-query" type="text" placeholder="Tìm kiếm" />
<i class="icon-search">
</i>
</div>
</form>
</li>
</ul>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div id="footer"> 2014 &copy; Children Security Software. 
  <div class="span pull-right">
<span class="go-top">
<i class="icon-arrow-up">
</i>
</span>
</div>
</div>
<script src="./js/jquery-1.8.3.min.js">
</script>
<script src="./assets/jquery-slimscroll/jquery-ui-1.9.2.custom.min.js">
</script>
<script src="./assets/jquery-slimscroll/jquery.slimscroll.min.js">
</script>
<script src="./assets/fullcalendar/fullcalendar/fullcalendar.min.js">
</script>
<script src="./assets/bootstrap/js/bootstrap.min.js">
</script>
<script src="./js/jquery.blockui.js">
</script>
<script src="./js/jquery.cookie.js">
</script>
<!--[if lt IE 9]>
<script src="./js/excanvas.js">
</script>
<script src="./js/respond.js">
</script>
<![endif]-->
<script src="./assets/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript">
</script>
<script src="./assets/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript">
</script>
<script src="./assets/jquery-knob/js/jquery.knob.js">
</script>
<script src="./assets/flot/jquery.flot.js">
</script>
<script src="./assets/flot/jquery.flot.resize.js">
</script>
<script src="./assets/flot/jquery.flot.pie.js">
</script>
<script src="./assets/flot/jquery.flot.stack.js">
</script>
<script src="./assets/flot/jquery.flot.crosshair.js">
</script>
<script src="./js/jquery.peity.min.js">
</script>
<script type="text/javascript" src="./assets/uniform/jquery.uniform.min.js">
</script>
<script src="./js/scripts.js">
</script>
<script>jQuery(document).ready(function(){App.setMainPage(true);App.init()});</script>
</body>
</html>
<?php
}
?>
<!DOCTYPE html><!--[if IE 8]><html lang="en" class="ie8"></html><![endif]--><!--[if IE 9]><html lang="en" class="ie9"></html><![endif]--><!--[if !IE]><!--><html lang="en"><!--<![endif]--><head><meta charset="utf-8" />
<title>Children Login 2014</title><meta content="width=device-width, initial-scale=1.0" name="viewport" />
<meta content="" name="description" />
<meta content="" name="author" />
<link href="./assets/bootstrap/css/bootstrap.css" rel="stylesheet" />
<link href="./assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="./assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
<link href="./css/style.min.css" rel="stylesheet" />
<link href="./css/style_responsive.css" rel="stylesheet" />
<link href="./css/style_default.css" rel="stylesheet" id="style_color" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<?php
session_start();
require_once('config.php');
function check_email($email) {
    if (strlen($email) == 0) return false;
    if (eregi("^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", $email)) return true;
    return false;
}
if ( $_GET['act'] == "do" )
{
    $username = addslashes( $_POST['username'] );
    $password = md5(md5( addslashes( $_POST['password'] ) ));
    $email = addslashes( $_POST['email'] );
	$phone = addslashes( $_POST['phone'] );
    if ( ! $username || ! $_POST['password'] || ! $email || ! $phone )
    {
        print "<div class=\"alert alert-error\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Lỗi!</strong>Xin vui lòng nhập đầy đủ các thông tin. </div>";
    }
	else
	{
    if ( mysql_num_rows(mysql_query("SELECT username FROM ChildrenCode WHERE username='$username'"))>0)
    {
        print "<div class=\"alert alert-error\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Lỗi!</strong>Tài khoản này đã có người sử dụng. </div>";
    }
	else
	{
    if (!check_email($email))
    {
        print "<div class=\"alert alert-error\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Lỗi!</strong>Địa chỉ Email không hợp lệ. </div>";
    }
	else
	{
    if ( mysql_num_rows(mysql_query("SELECT email FROM ChildrenCode WHERE email='$email'"))>0)
    {
		print "<div class=\"alert alert-error\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Lỗi!</strong>Địa chỉ Email đã có người sử dụng. </div>";
    }
	else
	{
    @$a=mysql_query("INSERT INTO ChildrenCode(username, password, email,phone) VALUES ('{$username}', '{$password}', '{$email}','{$phone}')");
    if ($a)
	{
        print "<div class=\"alert alert-success\"><button class=\"close\" data-dismiss=\"alert\">×</button><strong>Thông báo!</strong>Đăng kí thành công, trình duyệt sẽ tự động chuyển về trang Đăng Nhập. </div>";
        print "<meta http-equiv=\"Refresh\" content=\"5; url=login.php\">";
	}
	}
	}
	}
	}
}
session_destroy();
?>
<body id="login-body"><div class="login-header"><div id="logo" class="center"><img src="imagez/1403767372_group_half_security.png" alt="logo" class="center" />
</div></div><div id="login"><form id="loginform" class="form-vertical no-padding no-margin" action="register.php?act=do" method="post">
<div class="lock"><i class="icon-lock"></i></div><div class="control-wrap"><h4>Đăng kí</h4><div class="control-group"><div class="controls"><div class="input-prepend">
<span class="add-on"><i class="icon-user"></i></span><input name = "username" id="username" type="text" placeholder="Tài khoản" />
</div></div></div><div class="control-group"><div class="controls"><div class="input-prepend">
<span class="add-on"><i class="icon-key"></i></span><input name="password" id="password" type="password" placeholder="Mật khẩu" />
</div></div></div>
<div class="control-group"><div class="controls"><div class="input-prepend">
<span class="add-on"><i class="icon-envelope"></i></span><input name = "email" id="email" type="text" placeholder="Email" />
</div></div></div>

<div class="control-group"><div class="controls"><div class="input-prepend">
<span class="add-on"><i class="icon-reply"></i></span><input name = "phone" id="phone" type="text" placeholder="Phone Number" />
</div></div></div>
<div class="clearfix space5"></div></div><input type="submit" id="login-btn" class="btn btn-block login-btn" value="Đăng kí" />
</form></div>

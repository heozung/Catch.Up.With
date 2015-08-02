<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');

$ACL_LANG = array (
		'USERNAME'			=>	'Tên đăng nhập',
		'EMAIL'				=>	'E-mail',
		'PASSWORD'			=>	'Mật khẩu',
		'LOGIN'				=>	'[ Đăng nhập ]',
		'SESSION_ACTIVE'	=>	'Bạn đã đăng nhập rồi, bấm <a href="'.SUCCESS_URL.'">vào đây</a> để tiếp tục.',
		'LOGIN_SUCCESS'		=>	'Đăng nhập thành công, bấm <a href="'.SUCCESS_URL.'">vào đây</a> để tiếp tục.',
		'LOGIN_FAILED'		=>	((LOGIN_METHOD=='user'||LOGIN_METHOD=='both')?'Tên đăng nhập':''). 
								((LOGIN_METHOD=='both')?'/':'').
								((LOGIN_METHOD=='email'||LOGIN_METHOD=='both')?'email':'').
								' hoặc mật khẩu không đúng.',
	);
?>
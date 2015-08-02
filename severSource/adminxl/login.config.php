<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');

define('USEDB',			false);				//@ use database? true:false
define('LOGIN_METHOD',	'user');			//@ 'user':'email','both'
define('SUCCESS_URL',	'index.php');		//@ redirection target on success
include ('admin.config.php');
if (file_exists($UserData))
        $data = parse_ini_file($UserData, true);
	
if (count($data) > 0) {
             list ( $username, $dataArray) = each($data);
             foreach ($data as $username=>$dataArray) {
                     foreach ($dataArray as $password) {
                          }
                }
        }

//@ you could delete one of block below according to the USEDB value
if(USEDB) 
	{
		$db_config = array(
				'server'	=>	'localhost',	//@ server name or ip address along with suffix ':port' if needed (localhost:3306)
				'user'		=>	'xxxx',			//@ mysql username
				'pass'		=>	'xxxx',	//@ mysql password
				'name'		=>	'db_test',		//@ database name
				'tbl_user'	=>	'tbl_user'		//@ user table name
			);
	}
else
	{
		$user_config = array(
			array(
				'username'	=>	$username,
				'userpassword'	=>	$password,
			)
		);
	}
?>
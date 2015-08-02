<?php
if(!defined('HoangXL')) exit('direct access is not allowed.');
ini_set("display_errors", 1);
error_reporting(E_ALL);
session_start();
if(!empty($_GET['logoff'])) { $_SESSION = array(); }
if(empty($_SESSION['exp_user']) || @$_SESSION['exp_user']['expires'] < time()) {
	header("location:login.html");	//@ redirect 
} else {
	$_SESSION['exp_user']['expires'] = time()+(45*60);	//@ renew 45 minutes
}
?>

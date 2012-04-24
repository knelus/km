<?php
	$config['sql']['host']="localhost";
	$config['sql']['user']="root";
	$config['sql']['pass']="";
	$config['sql']['name']="km";
	
	$config['noLogin']['login']=true;
	
	
	include("includes/sql.class.php");
	include("includes/user.class.php");
	include("includes/json.class.php");
	
?>
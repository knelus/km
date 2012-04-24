<?php

	if($_GET['testmode']){
		foreach($_GET as $key=>$val){
			$_POST[$key]=$val;
		}
	}

	include("includes/global.php");
	
	
	if($_POST['script']){
		$script=$_POST['script'];
	}else{
		$script="home";
	}
	$scriptfile="scripts/".$script.".php";
	
	if(file_exists($scriptfile) && $user->mag()){
		include($scriptfile);
	}elseif($_GET['testmode']){
		echo "Kan bestand niet laden";	
	}
	
	echo $json->draw();

	
?>
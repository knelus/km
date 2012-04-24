<?php
	if($_POST['id']){
		$sql->query("delete from documents where user='".$_POST['id']."'");
		$sql->query("delete from interests where user='".$_POST['id']."'");
		$sql->query("delete from user where id='".$_POST['id']."'");
		$json->add("success",1);
	}else{
		$json->add("success",0);
	}
?>
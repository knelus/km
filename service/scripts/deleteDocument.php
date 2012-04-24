<?php
	if($_POST['id']){
		$result=$sql->result("select * from documents where id='".$_POST['id']."'");
		unlink("data/".$result['location']);
		$sql->query("delete from documents where id='".$_POST['id']."'");
		$json->add("success",1);
	}else{
		$json->add("success",0);
	}
?>
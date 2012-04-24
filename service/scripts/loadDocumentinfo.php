<?php
	$result=$sql->result("select * from documents where id='".$_POST['id']."'");
	if(is_array($result)){
		foreach($result as $key=>$val){
			$json->add($key,$val);
		}
		$json->add("succes","1");
	}else{
		$json->add("succes","0");
	}
	
?>
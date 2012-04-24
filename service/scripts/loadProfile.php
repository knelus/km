<?php
	$result=$sql->result("select * from user where id='".$_POST['id']."'");
	
	if(is_array($result)){
		//basis informatie ophalen
		foreach($result as $key=>$val){
			$json->add($key,$val);
		}
		$json->add("lastLoginDate",date("d-m-Y H:i:s",$result['lastLoginDate']));
		$json->add("registrationDate",date("d-m-Y H:i:s",$result['registrationDate']));
		
		

		
		
		$json->add("succes","1");
	}else{
		$json->add("succes","0");
	}
	
?>
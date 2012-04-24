<?php


	
	if($_POST['search']){
		include_once("includes/zoeken.class.php");
		$zoeken=new zoeken;
		$fields['username']=13;
		$fields['fullName']=9;
		$fields['email']=4;
		$fields['profileText']=1;
		$zoeken->zoek("select * from user where [where]",$_POST['search'],$fields);

		if($zoeken->aantal){
			while($result=$zoeken->fetch()){
				$json->add($result['id'],$result);
			}
		}else{
			$json->add("succes","0");
		}
	}else{
		$query=$sql->query("select * from user");
		if($sql->aantal($query)){
			while($result=$sql->fetch($query)){
				$json->add($result['id'],$result);
			}
		}else{
			$json->add("succes","0");
		}
	}

?>
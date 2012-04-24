<?php
	if($_POST['user']){
		$where="where user='".$_POST['user']."'";
	}else{
		$where="where id>0";
	}
	$qstring="select * from documents ".$where;
	
	if($_POST['search']){
		include_once("includes/zoeken.class.php");
		$zoeken=new zoeken;
		$fields['title']=13;
		$fields['tags']=6;
		$fields['description']="1";
		$fields['file']=2;
		$zoeken->zoek($qstring. " and [where]",$_POST['search'],$fields);

		if($zoeken->aantal){
			while($result=$zoeken->fetch()){
				$json->add($result['id'],$result);
			}
		}else{
			$json->add("succes","0");
		}
	}else{
		$query=$sql->query($qstring);
		if($sql->aantal($query)){
			while($result=$sql->fetch($query)){
				$json->add($result['id'],$result);
			}
		}else{
			$json->add("succes","0");
		}
	}

?>
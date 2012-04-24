<?php
$tags=$_POST['tags'];


while($oldTags!=$tags){
	$oldTags=$tags;
	$tags=str_replace("  "," ",$tags);
}



$exp=explode(",",$tags);
foreach($exp as $val){
	$query=$sql->query("select * from interests where user='".$user->userdata['id']."' and tag='".$val."'");
	if($sql->aantal($query)){
		$sql->query("update interests set score=score+1  where user='".$user->userdata['id']."' and tag='".$val."'");
	}else{
		$sql->query("INSERT INTO `interests` (
			`id` ,
			`tag` ,
			`user` ,
			`score` 
			)
			VALUES (
			NULL , '".$val."', '".$user->userdata['id']."', '1'
			)
			
			");
	}
}


$json->add("succes","1");
?>
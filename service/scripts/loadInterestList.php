<?php

	//velden ratem:
		$fields['title']=13;
		$fields['tags']=6;
		$fields['description']="1";
		$fields['file']=2;
		
	//interesses ophalen
	$query=$sql->query("select * from interests where user='".$user->userdata['id']."'");
	while($show=$sql->fetch($query)){
		$interest[]=$show;
	}
	
	//where maken
	$where="where ";
	$i=0;
	foreach($fields as $key=>$val){
		foreach($interest as $vala){
			if($i>0){
				$where.=' or ';
			}
			$where.= "`".$key."` like '%".$vala['tag']."%'";
			$i++;
		}
	}
	
	//opbouen van resultaten
	$query=$sql->query("select * from documents ".$where);
	while($show=$sql->fetch($query)){
		$results[]=$show;
	}
	
	//raten van scores
	foreach($results as $key=>$val){
		foreach($fields as $keya=>$vala){
			foreach($interest as $keyb=>$valb){
				$aant=count(@explode(strtolower($valb['tag']),strtolower($val[$keya])))-1;
				$score=$aant*$vala*$valb['score'];
				$scores[$key]=$score;
			}
		}
	}
	
	
	//scores sorteren
	if(is_array($scores)){
		arsort($scores);
	}
	
	//nieuwe lijst results opbouwen
	foreach($scores as $key=>$val){
		$sortedResults[]=$results[$key];
	}
	
	//outputten
	$i=0;
	foreach($sortedResults as $key=>$val){
		if($i<30){
			$json->add("k".$i,$val);
			$i++;
		}else{
			break;
		}
	}
	
?>
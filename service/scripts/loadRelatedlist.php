<?php

		$zoekstring=str_replace(","," ",$_POST['tags']);
					
		while($oldZoekstring!=$zoekstring){
			$oldZoekstring=$zoekstring;
			$zoekstring=str_replace("  "," ",$zoekstring);
		}
		
	
		
		include_once("includes/zoeken.class.php");
		$zoeken=new zoeken;
		$fields['title']=13;
		$fields['tags']=6;
		$fields['description']="1";
		$fields['file']=2;
		$zoeken->zoek("select * from documents where id!='".$_POST['id']."' and ([where])",$zoekstring,$fields);


		if($zoeken->aantal){
			$i=0;
			while($result=$zoeken->fetch() and $i<10){
				$json->add($result['id'],$result);
				$i++;
			}
		}else{
			$json->add("succes","0");
		}

	

?>
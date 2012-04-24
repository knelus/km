<?php
			//gemeenschappelijke interesses in kaart brengen.
		
		//eigen interesses eerst in array gooien
		$query=$sql->query("select * from interests where user='".$user->userdata['id']."'");
		while($show=$sql->fetch($query)){
			$ownInterest[$show["tag"]]=$show;
			$interestRate+=$show["score"];
		}
		//vergelijken met de andere interesses
		$query=$sql->query("select * from interests where user='".$_POST['id']."'");
		while($show=$sql->fetch($query)){
			if($show['score']>$ownInterest[$show['tag']]['score']){
				$compareRate+=$ownInterest[$show['tag']]['score'];
			}else{
				$compareRate+=$show['score'];
			}
		}
		
		//percentage berkeenen
		if($compareRate>0 && $interestRate>0){
			$commonInterest=$compareRate/$interestRate*100;
		}else{
			$commonInterest=0;
		}
		
		$json->add("commonInterest",round($commonInterest,0));

?>
<?php
	if($_POST['id']){
		$result=$sql->result("select * from documents where id='".$_POST['id']."'");

		$sql->query("
			update documents set
				file='".$_POST['file']."',
				title='".$_POST['title']."',
				description='".$_POST['description']."',
				tags='".$_POST['tags']."'
				where id='".$_POST['id']."'
			");
		
		
		if($_POST['fileData']){
			$filedata=base64_decode(urldecode($_POST['filedata']));
			$handle=fopen("data/".$result['location'],"w+");
			fwrite($handle,$filedata);
			fclose($handle);
		}
		$json->add("success",1);
	}else{
		if($_POST['fileData']&&$_POST['file']){
			$location=base64_encode(time()."_".$_POST['file']."_".$user->userdata['id']);
			$sql->query("
				insert into documents set
				file='".$_POST['file']."',
				title='".$_POST['title']."',
				description='".$_POST['description']."',
				location='".$location."',
				tags='".$_POST['tags']."'
			");
			$filedata=base64_decode($_POST['fileData']);
			$handle=fopen("data/".$location,"w+");
			fwrite($handle,$filedata);
			fclose($handle);
			$json->add("success",1);
		}else{
			$json->add("success",0);
		}
		
	}
?>
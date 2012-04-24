<?php

	foreach($_GET as $key=>$val){
		$_POST[$key]=$val;
	}

	include("includes/global.php");
	$result=$sql->result("select * from documents where id='".$_POST['id']."'");
	$fileUrl="data/".$result['location'];
	$fileData=file_get_contents($fileUrl);
	$fileName=$result['file'];


	header('Content-Description: File Transfer');
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename='.$fileName);
    header('Content-Transfer-Encoding: binary');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize($fileUrl));
    ob_clean();
    flush();
    echo $fileData;

	
	
	
	
?>
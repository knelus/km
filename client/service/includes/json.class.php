<?php
	class json{
		var $data;
		
		function json(){
			$this->getData();	
		}
		
		function add($key,$val){
			$this->data[$key]=$val;
		}
		
		function draw(){
			return json_encode($this->data);
		}
		
		function getData(){
			if($_POST['json']){
				$json=json_decode($_POST['json']);
				foreach($json as $key=>$val){
					$_POST[$key]=$val;
				}
			}
		}
		
		
		
	}
	
	$json=new json();
?>
<?php
	class user{
		
		var $userdata;
		
		function user(){
			global $sql;
			$hash=$_POST['Uhash'];
			$uname=$_POST['Uname'];
			$query=$sql->query("select * from user where hash='".$hash."' && username='".$uname."'");
			if($sql->aantal($query)){
				$this->userdata=$sql->fetch($query);
			}else{
				$this->userdata=false;
			}
		}
		
		function loggedin(){
			return is_array($this->userdata);
		}
		
		function mag(){
			global $config;
			if($this->loggedin()||$config['noLogin'][$_POST['script']]){
				return true;
			}else{
				return false;
			}
		}
		
		function login($username,$password){
			global $sql;
			$query=$sql->query("select * from user where password='".md5($password)."' && username='".$username."'");
			if($sql->aantal($query)){
				$userdata=$sql->fetch($query);
				$hash = $userdata['id']."_".md5(time().$username);
				$sql->query("update user set hash='".$hash."' , lastLoginDate='".time()."' where id='".$userdata['id']."'");
				return $hash;
			}
			return false;
		}
		
		
		
		
		
	}
	
	
	$user=new user();
?>
#pragma strict

var cam1 : Camera;
var cam2 : Camera;
var cam3 : Camera;
var cam4 : Camera;
 
function Start() 
{
	cam1.enabled = true;
	cam2.enabled = false;
	cam3.enabled = false;
	cam4.enabled = false;
}
 
function Update() 
{ 
	if (Input.GetKeyDown(KeyCode.F1)) 
	{
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;
	}
	
	if (Input.GetKeyDown(KeyCode.F2)) 
	{
		cam1.enabled = false;
		cam2.enabled = true;
		cam3.enabled = false;
		cam4.enabled = false;
	}
	
	if (Input.GetKeyDown(KeyCode.F3)) 
	{
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = true;
		cam4.enabled = false;
	}
	
	if (Input.GetKeyDown(KeyCode.F4)) 
	{
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = true;
	}
}
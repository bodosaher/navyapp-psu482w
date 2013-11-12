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

// JavaScript
function OnGUI () {
	// Make a background box
	GUI.Box (Rect (10,10,110,150), "Camera Select");

	// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
	if (GUI.Button (Rect (20,40,90,20), "Main Camera")) {
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;
	}

	// Make the second button.
	if (GUI.Button (Rect (20,70,90,20), "Bow View")) {
		cam1.enabled = false;
		cam2.enabled = true;
		cam3.enabled = false;
		cam4.enabled = false;
	}
	
	// Make the third button.
	if (GUI.Button (Rect (20,100,90,20), "Side View")) {
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = true;
		cam4.enabled = false;
	}
	
	// Make the fourth button.
	if (GUI.Button (Rect (20,130,90,20), "Top View")) {
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = true;
	}
}
/*
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
*/
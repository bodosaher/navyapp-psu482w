#pragma strict

var cam1 : Camera;
var cam2 : Camera;
var cam3 : Camera;
var cam4 : Camera;
var GUIEnabled : boolean = false;
var settingsIcon : Texture2D;
var customGUISkin : GUISkin;
 
function Start() 
{
	cam1.enabled = true;
	cam2.enabled = false;
	cam3.enabled = false;
	cam4.enabled = false;
}

// JavaScript
function OnGUI () {

	GUI.skin = customGUISkin;
	if(GUI.Button(Rect(Screen.width - 50,10,40,40), GUIContent(settingsIcon))) {
		GUIEnabled = !GUIEnabled;
	}
	GUI.skin = null;
	if(GUIEnabled) {
		// Make a background box
		GUI.Box (Rect (10,10,610,50), "");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (Rect (30,15,120,40), "Main Camera")) {
			cam1.enabled = true;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
		}

		// Make the second button.
		if (GUI.Button (Rect (180,15,120,40), "Bow View")) {
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = false;
			cam4.enabled = false;
		}
		
		// Make the third button.
		if (GUI.Button (Rect (330,15,120,40), "Side View")) {
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			cam4.enabled = false;
		}
		
		// Make the fourth button.
		if (GUI.Button (Rect (480,15,120,40), "Top View")) {
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = true;
		}
	}
}
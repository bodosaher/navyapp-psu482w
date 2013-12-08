#pragma strict

var cam1 : Camera;
var cam2 : Camera;
var cam3 : Camera;
var cam4 : Camera;

var settingsGUIEnabled : boolean = false;
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
function OnGUI () 
{

  GUI.skin = customGUISkin;
  if(GUI.Button(Rect(Screen.width - 65,10,40,40), GUIContent(settingsIcon))) 
  {
    settingsGUIEnabled = !settingsGUIEnabled;
  }
	
  GUI.skin = null;
  if(settingsGUIEnabled) 
  {
    // Make a background box
    GUI.Box (Rect (10, 10, 770, 50), "");

    // Side View Button
    if (GUI.Button (Rect(20, 15, 90, 40), "Side View")) 
    {
      cam1.enabled = true;
      cam2.enabled = false;
      cam3.enabled = false;
      cam4.enabled = false;
    }

    // Top View Button
    if (GUI.Button (Rect(130, 15, 90, 40), "Top View")) 
    {
      cam1.enabled = false;
      cam2.enabled = true;
      cam3.enabled = false;
      cam4.enabled = false;
    }
		
    // Island View Button
    if (GUI.Button (Rect(240, 15, 90, 40), "Island View")) 
    {
      cam1.enabled = false;
      cam2.enabled = false;
      cam3.enabled = true;
      cam4.enabled = false;
    }
		
    // Bow View Button
    if (GUI.Button (Rect(350, 15, 90, 40), "Bow View")) 
    {
      cam1.enabled = false;
      cam2.enabled = false;
      cam3.enabled = false;
      cam4.enabled = true;
    }   

    // Begin Recording Button
    if (GUI.Button (Rect(460, 15, 90, 40), "Start Recording")) 
    {

    }

    // Stop Recording Button
    if (GUI.Button (Rect(570, 15, 90, 40), "Stop Recording")) 
    {

    }

    // Video Menu
    if (GUI.Button (Rect(680, 15, 90, 40), "Video Menu")) 
    {

    }    
        
  }
}
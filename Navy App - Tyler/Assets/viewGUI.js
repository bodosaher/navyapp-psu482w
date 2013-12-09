#pragma strict

var cam1 : Camera;
var cam2 : Camera;
var cam3 : Camera;
var cam4 : Camera;

var viewGUIEnabled : boolean = false;
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
  GUI.skin = null;

  // Make a background box
  GUI.Box (Rect (20, Screen.height - 50, 760, 40), "");

  // Side View Button
  if (GUI.Button (Rect(40, Screen.height - 45, 150, 30), "Side View")) 
  {
    cam1.enabled = true;
    cam2.enabled = false;
    cam3.enabled = false;
    cam4.enabled = false;
  }

  // Top View Button
  if (GUI.Button (Rect(230, Screen.height - 45, 150, 30), "Top View")) 
  {
    cam1.enabled = false;
    cam2.enabled = true;
    cam3.enabled = false;
    cam4.enabled = false;
  }
		
  // Island View Button
  if (GUI.Button (Rect(420, Screen.height - 45, 150, 30), "Distant View")) 
  {
    cam1.enabled = false;
    cam2.enabled = false;
    cam3.enabled = true;
    cam4.enabled = false;
  }
		
  // Bow View Button
  if (GUI.Button (Rect(610, Screen.height - 45, 150, 30), "Bow View")) 
  {
    cam1.enabled = false;
    cam2.enabled = false;
    cam3.enabled = false;
    cam4.enabled = true;
  }   
    
}
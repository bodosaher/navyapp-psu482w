#pragma strict

var videoGUIEnabled : boolean = false;
var videoIcon : Texture2D;
var customGUISkin : GUISkin;
var firstVideoRecorded : boolean = false;

// JavaScript
function OnGUI () 
{

  GUI.skin = customGUISkin;
  if(GUI.Button(Rect(Screen.width - 65,10,40,40), GUIContent(videoIcon))) 
  {
    videoGUIEnabled = !videoGUIEnabled;
  }
	
  GUI.skin = null;
  if(videoGUIEnabled) 
  {
    // Make a background box
    GUI.Box (Rect (20, 10, 600, 40), "");

    // Start Recording Button
    if (GUI.Button (Rect(40, 15, 160, 30), "Start Recording")) 
    {
      Kamcord.StartRecording();
    }

    // Stop Recording Button
    if (GUI.Button (Rect(240, 15, 160, 30), "Stop Recording")) 
    {
      Kamcord.StopRecording();
    }
		
    // Share Button
    if (GUI.Button (Rect(440, 15, 160, 30), "Share")) 
    {
      Kamcord.ShowView();
    }    
        
  }
}
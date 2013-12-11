#pragma strict

/*To record, we used the kamcord (more info available at http://kamcord.com/).*/

//Consition which is true when the videoGUI is enabled
var videoGUIEnabled : boolean = false;
// "Play" Icon which opens and closes the video menu
var videoIcon : Texture2D;
//Skin applied to the GUI
var customGUISkin : GUISkin;
var firstVideoRecorded : boolean = false;
var startedRecording: boolean = false;

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
    GUI.Box (Rect (120, 10, 600, 40), "");


	if(!startedRecording)
	{
	    // Start Recording Button
	    if (GUI.Button (Rect(140, 15, 160, 30), "Start Recording")) 
	    {
	      Kamcord.StartRecording();
	      startedRecording = true;
	    }
	}
	if(startedRecording)
	{
	    // Stop Recording Button
	    if (GUI.Button (Rect(340, 15, 160, 30), "Stop Recording")) 
	    {
	      Kamcord.StopRecording();
	      startedRecording = false;
	      firstVideoRecorded = true;
	    }
	}
	if(!startedRecording && firstVideoRecorded)
	{	
	    // Share Button
	    if (GUI.Button (Rect(540, 15, 160, 30), "View/Share Recording")) 
	    {
	      Kamcord.ShowView();
	    }    
    }   
  }
}
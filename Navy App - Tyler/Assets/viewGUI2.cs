using UnityEngine;
using System.Collections;

public class viewGUI2 : MonoBehaviour {

	//This is the ship object itself in game.  Used for measuring the position and rotation of this ship
	public Transform ship;
	//Below are the 4 cameras
	public Camera cam1; //side view
	public Camera cam2 ;//top view
	public Camera cam3; //distant view
	public Camera cam4; //bow view
	public Ocean localOcean;

	//Whether or not GUI is displayed on scrren.  
	public bool GUIEnabled = false;
	//Skin used by GUI
	public GUISkin customGUISkin;
	//Gear icon used for button
	public Texture2D gear;

	//Initial position and rotation values
	float startPitch;
	float startRoll;
	float startYaw;
	float startHeave;
	float startSway;
	float startSurge;

	//Updated position and rotation values
	float currentPitch;
	float currentRoll;
	float currentYaw;
	float currentHeave;
	float currentSway;
	float currentSurge;

	// Use this for initialization
	void Start () {

		//At start, side camera is used
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;

		//These are used so that this script can access the variables from the Ocean script
		//available in (/Buoyancy Toolkit/Examples/Ocean) which is used ot model the Ocean
		GameObject waterObject = GameObject.Find("DaylightSimpleWater");
		localOcean = waterObject.GetComponent<Ocean>();

		startPitch = ship.rotation.z;
		startRoll = ship.rotation.x;
		startYaw = ship.rotation.y;
		startHeave = ship.position.y;
		startSway = ship.position.z;
		startSurge = ship.position.x;
	}

	void OnGUI () {
		GUI.skin = customGUISkin;
		//if(GUI.Button(Rect(Screen.width - 50,10,40,40), GUIContent(settingsIcon))) {
		if(GUI.Button(new Rect(50,10,40,40), gear)) {
			GUIEnabled = !GUIEnabled;
		}


		//Display information about the ship's position
		currentPitch = ship.rotation.z;
		currentRoll = ship.rotation.x;
		currentYaw = ship.rotation.y;
		currentHeave = ship.position.y;
		currentSway = ship.position.z;
		currentSurge = ship.position.x;

		//Information about the ship to display
		GUI.Box(new Rect (Screen.width - 170, 75, 160, 30), "Ship Position Information");
		GUI.Box(new Rect (Screen.width - 160, 110, 150, 30), ("Pitch: " + (currentPitch - startPitch).ToString("F5")));
		GUI.Box(new Rect (Screen.width - 160, 145, 150, 30), ("Roll: " + (currentRoll - startRoll).ToString("F5")));
		GUI.Box(new Rect (Screen.width - 160, 180, 150, 30), ("Yaw: " + (currentYaw - startYaw).ToString("F5")));
		GUI.Box(new Rect (Screen.width - 160, 215, 150, 30), ("Heave: " + (currentHeave - startHeave).ToString("F5")));
		GUI.Box(new Rect (Screen.width - 160, 250, 150, 30), ("Sway: " + (currentSway - startSway).ToString("F5")));
		GUI.Box(new Rect (Screen.width - 160, 285, 150, 30), ("Surge: " + (currentSurge - startSurge).ToString("F5")));

		GUI.skin = null;

		if(GUIEnabled) {
			// Make a background box
			GUI.Box (new Rect (20, Screen.height - 100, 760, 100), "");
			
			// Side View Button
			if (GUI.Button (new Rect(40, Screen.height - 35, 130, 30), "Side View")) 
			{
				cam1.enabled = true;
				cam2.enabled = false;
				cam3.enabled = false;
				cam4.enabled = false;
			}
			
			// Top View Button
			if (GUI.Button (new Rect(185, Screen.height - 35, 130, 30), "Top View")) 
			{
				cam1.enabled = false;
				cam2.enabled = true;
				cam3.enabled = false;
				cam4.enabled = false;
			}
			
			// Island View Button
			if (GUI.Button (new Rect(330, Screen.height - 35, 130, 30), "Distant View")) 
			{
				cam1.enabled = false;
				cam2.enabled = false;
				cam3.enabled = true;
				cam4.enabled = false;
			}
			
			// Bow View Button
			if (GUI.Button (new Rect(475, Screen.height - 35, 130, 30), "Bow View")) 
			{
				cam1.enabled = false;
				cam2.enabled = false;
				cam3.enabled = false;
				cam4.enabled = true;
			}  

			//Reset Button
			if(GUI.Button (new Rect(620, Screen.height - 35, 130, 30), "Reset"))
			{
				Application.LoadLevel(0);
			}

			GUI.Label(new Rect(40, Screen.height - 100, 150, 20), "Intensity in X Direction");
			GUI.Label(new Rect(230, Screen.height - 100, 150, 20), "Intensity in Z Direction");
			GUI.Label(new Rect(420, Screen.height - 100, 150, 20), "Wavelength in X Direction");
			GUI.Label(new Rect(610, Screen.height - 100, 150, 20), "Wavelength in Z Direction");

			//Sliders to control the waves
			localOcean.xDirec = GUI.HorizontalSlider (new Rect (40, Screen.height - 70, 150, 80), localOcean.xDirec, 0.0f, 2.0f);
			localOcean.zDirec = GUI.HorizontalSlider (new Rect (230, Screen.height - 70, 150, 80), localOcean.zDirec, 0.0f, 4.0f);
			localOcean.xFreq = GUI.HorizontalSlider (new Rect (420, Screen.height - 70, 150, 80), localOcean.xFreq, 0.0f, 1.0f);
			localOcean.zFreq = GUI.HorizontalSlider (new Rect (610, Screen.height - 70, 150, 80), localOcean.zFreq, 0.0f, 1.0f);

		}
	}


}
using UnityEngine;
using System.Collections;

public class viewGUI2 : MonoBehaviour {
	
	public Transform ship;
	public Camera cam1;
	public Camera cam2 ;
	public Camera cam3;
	public Camera cam4;
	public Ocean localOcean;

	public bool GUIEnabled = false;
	public GUISkin customGUISkin;
	public Texture2D gear;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;

		GameObject waterObject = GameObject.Find("DaylightSimpleWater");
		localOcean = waterObject.GetComponent<Ocean>();
	}

	void OnGUI () {
		GUI.skin = customGUISkin;
		//if(GUI.Button(Rect(Screen.width - 50,10,40,40), GUIContent(settingsIcon))) {
		if(GUI.Button(new Rect(50,10,40,40), gear)) {
			GUIEnabled = !GUIEnabled;
		}

		GUI.skin = null;

		if(GUIEnabled) {
			// Make a background box
			GUI.Box (new Rect (20, Screen.height - 100, 760, 100), "");
			
			// Side View Button
			if (GUI.Button (new Rect(40, Screen.height - 35, 150, 30), "Side View")) 
			{
				cam1.enabled = true;
				cam2.enabled = false;
				cam3.enabled = false;
				cam4.enabled = false;
			}
			
			// Top View Button
			if (GUI.Button (new Rect(230, Screen.height - 35, 150, 30), "Top View")) 
			{
				cam1.enabled = false;
				cam2.enabled = true;
				cam3.enabled = false;
				cam4.enabled = false;
			}
			
			// Island View Button
			if (GUI.Button (new Rect(420, Screen.height - 35, 150, 30), "Distant View")) 
			{
				cam1.enabled = false;
				cam2.enabled = false;
				cam3.enabled = true;
				cam4.enabled = false;
			}
			
			// Bow View Button
			if (GUI.Button (new Rect(610, Screen.height - 35, 150, 30), "Bow View")) 
			{
				cam1.enabled = false;
				cam2.enabled = false;
				cam3.enabled = false;
				cam4.enabled = true;
			}  

			GUI.Label(new Rect(40, Screen.height - 100, 150, 20), "Intensity in X Direction");
			GUI.Label(new Rect(230, Screen.height - 100, 150, 20), "Intensity in Z Direction");
			GUI.Label(new Rect(420, Screen.height - 100, 150, 20), "Frequency in X Direction");
			GUI.Label(new Rect(610, Screen.height - 100, 150, 20), "Frequency in Z Direction");

			localOcean.xDirec = GUI.HorizontalSlider (new Rect (40, Screen.height - 70, 150, 80), localOcean.xDirec, 0.0f, 2.0f);
			localOcean.zDirec = GUI.HorizontalSlider (new Rect (230, Screen.height - 70, 150, 80), localOcean.zDirec, 0.0f, 2.0f);
			localOcean.xFreq = GUI.HorizontalSlider (new Rect (420, Screen.height - 70, 150, 80), localOcean.xFreq, 0.0f, 1.0f);
			localOcean.zFreq = GUI.HorizontalSlider (new Rect (610, Screen.height - 70, 150, 80), localOcean.zFreq, 0.0f, 1.0f);

		}
	}


}
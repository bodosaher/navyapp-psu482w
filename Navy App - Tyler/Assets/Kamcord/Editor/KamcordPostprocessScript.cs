

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using System;
using System.Diagnostics;

public class KamcordPostprocessScript : MonoBehaviour
{
#if UNITY_IPHONE
	// Replaces PostprocessBuildPlayer functionality
	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuildProject)
	{
		UnityEngine.Debug.Log ("--- Kamcord --- Executing post process build phase.");
		
		string kamcordUnityVersion = "";
		
		Process p = new Process();
        p.StartInfo.FileName = "perl";
#if UNITY_3_5
		kamcordUnityVersion = "350";
#elif (UNITY_4_0 || UNITY_4_0_1)
		kamcordUnityVersion = "400";
#elif UNITY_4_1
		kamcordUnityVersion = "410";
#endif
		p.StartInfo.Arguments = string.Format("Assets/Kamcord/Editor/KamcordPostprocessbuildPlayer1 \"{0}\" \"{1}\"", pathToBuildProject, kamcordUnityVersion);
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
		p.OutputDataReceived += (sender, args) => Console.WriteLine("--- Kamcord output: {0}", args.Data);
        p.Start();
		p.BeginOutputReadLine();
		
        p.WaitForExit();
		
		UnityEngine.Debug.Log("--- Kamcord --- Finished executing post process build phase."); 
	}
#endif
}



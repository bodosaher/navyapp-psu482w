using UnityEngine;
using System.Collections;

public class CaptureFrame : MonoBehaviour {
    
#if UNITY_IPHONE
	// Attach this script onto your HUD camera to enable HUD-less recording.
	void OnPreRender()
	{
        Kamcord.CaptureFrame();    
    }
#endif
	
}

using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////
/// Version: 1.6.0 (2013-10-04)
//////////////////////////////////////////////////////////////////

public class KamcordCustomUI
{
#if UNITY_IPHONE
	//////////////////////////////////////////////////////////////////
	/// Native method implementations
	/// 
	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIStartNewRecording();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIPauseRecording();

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIResumeRecording();

	[DllImport ("__Internal")]
	private static extern uint Kamcord_CustomUIStopRecordingAndGetLocalVideoID();

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIShowVideoFullScreenForLocalVideoID(uint localVideoID);

	[DllImport ("__Internal")]
	private static extern bool Kamcord_CustomUIUploadVideoForLocalVideoID(uint localVideoID);

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIClearAllVideos();

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIClearContentForVideosWithLocalVideoID(uint localVideoID);

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUIRetrieveTicketForVideoWithID(string videoID);

	[DllImport ("__Internal")]
	private static extern void Kamcord_CustomUISubscribeToCallbacks(bool subscribe);
#endif

	// Methods to take care of subscribing and unsubscribing to callbacks
	public static List<KamcordCustomUICallbackInterface> listeners = new List<KamcordCustomUICallbackInterface>();
	  
	// Call this static method to have your object receive all of the
	// KamcordCustomUICallbackInterface callbacks.
	public static void AddListener(KamcordCustomUICallbackInterface listener)
	{
#if UNITY_IPHONE
		if (!listeners.Contains(listener))
		{
			listeners.Add(listener);
		}
#endif
	}
	
	public static void RemoveListener(KamcordCustomUICallbackInterface listener)
	{
#if UNITY_IPHONE
		listeners.Remove(listener);
#endif
	}

	//////////////////////////////////////////////////////////////////
	/// Subscribe to Custom UI callbacks from Kamcord
	/// 
	public static void SubscribeToCallbacks(bool subscribe)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUISubscribeToCallbacks(subscribe);
		}
#endif
	}

	public static void StartNewRecording()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIStartNewRecording();
		}
#endif
	}

	public static void PauseRecording()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIPauseRecording();
		}
#endif
	}

	public static void ResumeRecording()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIResumeRecording();
		}
#endif
	}

	public static string StopRecordingAndGetLocalVideoID()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_CustomUIStopRecordingAndGetLocalVideoID().ToString();
		}
#endif
		return null;
	}

	public static void ShowVideoFullScreenForLocalVideoID(string localVideoID)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIShowVideoFullScreenForLocalVideoID(Convert.ToUInt32(localVideoID));
		}
#endif
	}

	public static bool UploadVideoForLocalVideoID(string localVideoID)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_CustomUIUploadVideoForLocalVideoID(Convert.ToUInt32(localVideoID));
		}
#endif
		return false;
	}

	public static void ClearAllVideos()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIClearAllVideos();
		}
#endif
	}
	
	public static void ClearContentForVideosWithLocalVideoID(string localVideoID)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CustomUIClearContentForVideosWithLocalVideoID(Convert.ToUInt32(localVideoID));
		}
#endif
	}

	public static void RetrieveTicketForVideoWithID(string videoID)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
    	{
			Kamcord_CustomUIRetrieveTicketForVideoWithID(videoID);
		}
#endif
	}
}

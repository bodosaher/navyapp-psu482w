using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using KamcordJSON;

//////////////////////////////////////////////////////////////////
/// iOS Version: 1.6.3 (2013-11-13)
//////////////////////////////////////////////////////////////////

public class Kamcord : MonoBehaviour
{	
#pragma warning disable 
	/*
	 * 
	 * Kamcord callbacks.
	 * To subscribe to these, in any C# class do:
	 * 
	 *     Kamcord.kamcordViewDidAppear += myKamcordViewDidAppearFunction;
	 * 
	 * where myKamcordViewDidAppearFunction exists in your C# class like so:
	 * 
	 *     void myKamcordViewDidAppearFunction() {
	 *         // ...
	 *     }
	 * 
	 */
	
	/*
	 * The Kamcord share view appeared and disappeared
	 */
	public delegate void KamcordViewDidAppear ();

	public delegate void KamcordViewWillDisappear ();

	public delegate void KamcordViewDidDisappear ();
	
	// Corresponding events
	public static event KamcordViewDidAppear 		kamcordViewDidAppear;
	public static event KamcordViewWillDisappear 	kamcordViewWillDisappear;
	public static event KamcordViewDidDisappear 	kamcordViewDidDisappear;
	
	
	/*
	 * The Kamcord watch view appeared and disappeared
	 */
	public delegate void KamcordWatchViewDidAppear ();

	public delegate void KamcordWatchViewWillDisappear ();

	public delegate void KamcordWatchViewDidDisappear ();
	
	// Corresponding events
	public static event KamcordWatchViewDidAppear 		kamcordWatchViewDidAppear;
	public static event KamcordWatchViewWillDisappear 	kamcordWatchViewWillDisappear;
	public static event KamcordWatchViewDidDisappear 	kamcordWatchViewDidDisappear;
	
	
	/*
	 * The thumbnail for the latest video is ready at this absolute filepath.
	 */
	public delegate void VideoThumbnailReadyAtFilePath (string filepath);
	
	// Corresponding event
	public static event VideoThumbnailReadyAtFilePath videoThumbnailReadyAtFilePath;
	
	
	/*
	 * The user pressed the share button
	 */
	public delegate void ShareButtonPressed ();
	
	// Corresponding event
	public static event ShareButtonPressed shareButtonPressed;
	
	
	/*
	 * When the video begins and finishes uploading
	 */ 
	public delegate void VideoWillBeginUploading (string videoID,string URL);

	public delegate void VideoUploadProgressed (string videoID,float progress);

	public delegate void VideoFinishedUploading (string videoID,bool success);
	
	// Corresponding events
	public static event VideoWillBeginUploading 	videoWillBeginUploading;
	public static event VideoUploadProgressed		videoUploadProgressed;
	public static event VideoFinishedUploading 		videoFinishedUploading;
	
	
	/*
	 * When the video has finished sharing to Facebook and/or Twitter
	 */
	public delegate void VideoSharedToFacebook (string kamcordVideoID,bool success);

	public delegate void VideoSharedToTwitter (string kamcordVideoID,bool success);
	
	// Corresponding events
	public static event VideoSharedToFacebook 	videoSharedToFacebook;
	public static event VideoSharedToTwitter 	videoSharedToTwitter;
	/*
	 * When the snapshot you requested is ready
	 */ 
	public delegate void SnapshotReadyAtFilePath (string filepath);
	
	// Corresponding event
	public static event SnapshotReadyAtFilePath snapshotReadyAtFilePath;
	
	/*
	 * When the call to action button on the push notification view was pressed
	 */
	public delegate void PushNotifCallToActionButtonPressed ();
	
	// Corresponding event
	public static event PushNotifCallToActionButtonPressed pushNotifCallToActionButtonPressed;
	
	// Useful for unsubscribing from everything
	public static void UnsubscribeFromAllCallbacks ()
	{
#if UNITY_IPHONE
		kamcordViewDidAppear 			= null;
		kamcordViewWillDisappear 		= null;
		kamcordViewDidDisappear 		= null;
		
		kamcordWatchViewDidAppear		= null;
		kamcordWatchViewWillDisappear	= null;
		kamcordWatchViewDidDisappear	= null;
		
		videoThumbnailReadyAtFilePath	= null;
		
		videoWillBeginUploading			= null;
		videoUploadProgressed			= null;
		videoFinishedUploading			= null;
		
		videoSharedToFacebook			= null;
		videoSharedToTwitter			= null;
		
		snapshotReadyAtFilePath			= null;
		
		pushNotifCallToActionButtonPressed	= null;
		
		listeners.Clear();
#endif
	}
	
	//////////////////////////////////////////////////////////////////
	/// Implementations
	//////////////////////////////////////////////////////////////////
	
	/* Public interface for use inside C# / JS code */
	public static bool IsEnabled ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_IsEnabled();
		}
#endif
		return false;
	}

	//////////////////////////////////////////////////////////////////
	/// Share settings
	///
	
	public static void SetVideoTitle (string title)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetVideoTitle(title);
		}
#endif
	}

	public static void SetYouTubeSettings (string description,
                                          string tags)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetYouTubeSettings(description, tags);
		}
#endif
	}

	public static void SetFacebookAppID (string facebookAppID)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetFacebookAppID(facebookAppID);
		}
#endif
	}

	public static void SetFacebookDescription (string facebookDescription)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetFacebookDescription(facebookDescription);
		}
#endif
	}
	
	public static void SetDefaultTweet (string tweet)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetDefaultTweet(tweet);
		}
#endif
	}
	
	public static void SetTwitterDescription (string twitterDescription)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetTwitterDescription(twitterDescription);
		}
#endif
	}
	
	public static void SetDefaultEmailSubject (string subject)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetDefaultEmailSubject(subject);
		}
#endif
	}
	
	public static void SetDefaultEmailBody (string body)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetDefaultEmailBody(body);
		}
#endif
	}
	
	public static void SetVideoMetadata (Dictionary <string, object> metadata)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			if (metadata != null && metadata.Count > 0)
			{
				 _KamcordSetVideoMetadata(Json.Serialize(metadata));
			}	
		}
#endif
	}
	
	// Constrain how much of the remaining free disk space your app will use.
	// For instance, if you'd like to use up to 90% of the remaining free disk space,
	// call this method with a value of 0.9. Values must be in the range (0, 1). 
	// 
	// By default, a percentage is not used. Instead, if free space drops below 50 MB,
	// Kamcord still stop recording.
	public static void SetMaxFreeDiskSpacePercentageUsage (double percentage)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_KamcordSetMaxFreeDiskSpacePercentageUsage(percentage);
		}
#endif
	}
	
	public static string Version()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_Version();
		}
#endif
		
		return "";
	}
	
	public static void SetLevelAndScore (string level,
                                        double score)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetLevelAndScore(level, score);
		}
#endif
	}
	
	//////////////////////////////////////////////////////////////////
	/// Video Recording
	///
	
	// Start recording
	public static void StartRecording ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_StartRecording();
		}
#endif
	}
	
	// Stop recording
	public static void StopRecording ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_StopRecording();
		}
#endif
	}
	
	// Pause recording
	public static void Pause ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_Pause();
		}
#endif
	}
	
	// Resume recording
	public static void Resume ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_Resume();
		}
#endif
	}
	
	// Are we currently recording?
	public static bool IsRecording ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_IsRecording();
		}
#endif
		return false;
	}

	// Are we currently paused?
	public static bool IsPaused ()
	{
		#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_IsPaused();
		}
		#endif
		return false;
	}
	
	// Request a snapshot to be saved with the given filename
	public static void Snapshot (string filename)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_KamcordSnapshot(Application.persistentDataPath + "/" + filename);
		}
#endif
	}
	
	// Set the video quality
	public static void SetVideoQuality (VideoQuality quality)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetVideoQuality(quality);
		}
#endif
	}
	
	// Enable or disable live voice overlay
	public static void SetVoiceOverlayEnabled (bool enabled)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetVoiceOverlayEnabled(enabled);
		}
#endif
	}
	
	// Check is voice overlay enabled
	public static bool VoiceOverlayEnabled ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_VoiceOverlayEnabled();
		}
		else
#endif
		{
			return false;
		}
	}
	
	// Activate voice overlay (must be enabled first)
	public static void ActivateVoiceOverlay (bool activate)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_ActivateVoiceOverlay(activate);
		}
#endif
	}
	
	// Check is voice overlay is activated (i.e. actually set to record)
	public static bool VoiceOverlayActivated ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_VoiceOverlayActivated();
		}
		else
#endif
		{
			return false;
		}
	}
	
	// HUD-less recording
	public static void CaptureFrame ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_CaptureFrame();
		}
#endif
	}

	// Enable notifications from Kamcord.
	// By default, we schedule 4 "Gameplay of the Week" notifications every week for 4 weeks.
	public static void SetNotificationsEnabled (bool notificationsEnabled)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetNotificationsEnabled(notificationsEnabled);
		}
#endif
	}

	// Fire a test notification
	public static void FireTestNotification ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_FireTestNotification();
		}
#endif
	}

	//////////////////////////////////////////////////////////////////
	/// Subscribe to KamcordCallbackInterface callback
	///	
	
	// Methods to take care of subscribing and unsubscribing to callbacks
	public static List<KamcordCallbackInterface> listeners = new List<KamcordCallbackInterface> ();
	
	// Call this static method to have your object receive all of the
	// KamcordCallbackInterface callbacks.
	public static void AddListener (KamcordCallbackInterface listener)
	{
#if UNITY_IPHONE
		if (!listeners.Contains(listener))
		{
			listeners.Add(listener);
		}
#endif
	}
	
	public static void RemoveListener (KamcordCallbackInterface listener)
	{
#if UNITY_IPHONE
		listeners.Remove(listener);
#endif
	}
	
	//////////////////////////////////////////////////////////////////
	/// UI 
	///	
	
	// Show Kamcord view.
	public static void ShowView ()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_ShowView();
		}
#endif
	}
	
	public static void ShowWatchView ()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_ShowWatchView();
		}
#endif
	}

	public static void handleKamcordNotification (LocalNotification notification)
	{
		#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			if (notification.userInfo.Contains("Kamcord"))
			{
				Kamcord_ShowPushNotifView();
			}
		}
		#endif
	}
	
	//////////////////////////////////////////////////////////////////
	/// Sundry Methods
	///
		
	public static void SetMaximumVideoLength (uint seconds)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetMaximumVideoLength(seconds);
		}
#endif
	}
	
	public static uint MaximumVideoLength ()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_MaximumVideoLength();
		}
		else
#endif
		{
			return 0;
		}
	}
	
	public static void SetVideoFPS (uint videoFPS)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetVideoFPS(videoFPS);
		}
#endif
	}
	
	public static uint VideoFPS ()
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return Kamcord_VideoFPS();
		}
		else
#endif
		{
			return 0;
		}
	}
	
	public static void Disable ()
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_KamcordDisable();
		}
#endif
	}

	//////////////////////////////////////////////////////////////////
	/// Audio Overlay APIs - only useful in some pretty rare scenarios
	/// where you want to turn off the automatic recording of game audio
	/// and add your own background track to the recorded video.
	///
	public static void TurnOffAutomaticAudioRecording (bool state)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_KamcordTurnOffAutomaticAudioRecording(state);
		}
#endif
	}

	public static void PlayBackgroundSound (string fileName, bool loop)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
			_KamcordPlayBackgroundSound(filePath, loop);
		}
#endif
	}
	
	// Used inside KamcordInitializer
	public static void Init (string devKey,
						    string devSecret,
						    string appName,
						    VideoQuality videoQuality)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_KamcordInit(devKey, devSecret, appName, videoQuality.ToString());
		}
#endif
	}
	
	// This method is used inside KamcordInitializer.cs
	public static void SetDeviceBlacklist (bool disableiPod4G,
										  bool disableiPod5G,
										  bool disableiPhone3GS,
										  bool disableiPhone4,
										  bool disableiPad1,
										  bool disableiPad2,
										  bool disableiPadMini)
	{
#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetDeviceBlacklist(disableiPod4G,
									   disableiPod5G,
									   disableiPhone3GS,
									   disableiPhone4,
									   disableiPad1,
									   disableiPad2,
									   disableiPadMini);
		}
#endif
	}
    
	//////////////////////////////////////////////////////////////////
	/// Deprecated share methods.
	/// Will be removed in August 2013.
	///
	public static void SetDefaultTitle (string title)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetVideoTitle(title);
		}
#endif
	}
	
	public static void SetFacebookSettings (string title,
                                           string caption,
                                           string description)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetFacebookDescription(description);
		}
#endif
	}
	
	public static void SetDefaultEmailSubjectAndBody (string subject,
                                                     string body)
	{
#if UNITY_IPHONE
		// Call plugin only when running on real device
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Kamcord_SetDefaultEmailSubject(subject);
			Kamcord_SetDefaultEmailBody(body);
		}
#endif
	}
	
	///
	/// End of deprecated share methods
	//////////////////////////////////////////////////////////////////
	
	#if UNITY_IPHONE
	//////////////////////////////////////////////////////////////////
	/// Method declarations
	//////////////////////////////////////////////////////////////////
	
	/* Interface to native implementation */
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_SetDeviceBlacklist(bool disableiPod4G,
														  bool disableiPod5G,
														  bool disableiPhone3GS,
														  bool disableiPhone4,
														  bool disableiPad1,
														  bool disableiPad2,
														  bool disableiPadMini);
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_IsEnabled();
	
	[DllImport ("__Internal")]
	private static extern string Kamcord_Version();
	
	[DllImport ("__Internal")]
	private static extern void _KamcordInit(string devKey,
											string devSecret,
											string appName,
											string videoQuality);

	//////////////////////////////////////////////////////////////////
    /// Share settings
    ///
	[DllImport ("__Internal")]
	private static extern void Kamcord_SetVideoTitle(string title);
	
	[DllImport ("__Internal")]
    private static extern void Kamcord_SetYouTubeSettings(string description,
                                                          string tags);
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_SetFacebookAppID(string facebookAppID);

	[DllImport ("__Internal")]
	private static extern void Kamcord_SetFacebookDescription(string description);

	[DllImport ("__Internal")]
    private static extern void Kamcord_SetDefaultTweet(string tweet);
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_SetTwitterDescription(string twitterDescription);
	
	[DllImport ("__Internal")]
    private static extern void Kamcord_SetDefaultEmailSubject(string subject);
	
	[DllImport ("__Internal")]
    private static extern void Kamcord_SetDefaultEmailBody(string body);

	[DllImport ("__Internal")]
    private static extern void Kamcord_SetLevelAndScore(string level,
                                                        double score);

	//////////////////////////////////////////////////////////////////
    /// Video recording 
    ///
	[DllImport ("__Internal")]
	private static extern void Kamcord_StartRecording();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_StopRecording();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_Pause();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_Resume();
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_IsRecording();

	[DllImport ("__Internal")]
	private static extern bool Kamcord_IsPaused();
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_SetVoiceOverlayEnabled(bool enabled);
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_VoiceOverlayEnabled();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_ActivateVoiceOverlay(bool activate);
	
	[DllImport ("__Internal")]
	private static extern bool Kamcord_VoiceOverlayActivated();

	[DllImport ("__Internal")]
	private static extern void Kamcord_CaptureFrame();
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_SetVideoQuality(VideoQuality quality);
	
	[DllImport ("__Internal")]
	private static extern void _KamcordSnapshot(string filepath);
	
	[DllImport ("__Internal")]
	private static extern void _KamcordSetVideoMetadata(string jsonMetadata);
	
	[DllImport ("__Internal")]
	private static extern void _KamcordSetMaxFreeDiskSpacePercentageUsage(double percentage);
	
	//////////////////////////////////////////////////////////////////
    /// UI 
    ///
    [DllImport ("__Internal")]
    private static extern void Kamcord_ShowView();
	
	[DllImport ("__Internal")]
    private static extern void Kamcord_ShowWatchView();

	[DllImport ("__Internal")]
	private static extern void Kamcord_ShowPushNotifView();
    
	//////////////////////////////////////////////////////////////////
    /// Notifications
    ///
	[DllImport ("__Internal")]
	private static extern void Kamcord_SetNotificationsEnabled(bool notificationsEnabled);
	
	[DllImport ("__Internal")]
	private static extern void Kamcord_FireTestNotification();

	//////////////////////////////////////////////////////////////////
    /// Sundry Methods
    ///    
	[DllImport ("__Internal")]
    private static extern void Kamcord_SetMaximumVideoLength(uint seconds);
    
	[DllImport ("__Internal")]
    private static extern uint Kamcord_MaximumVideoLength();

	[DllImport ("__Internal")]
    private static extern void Kamcord_SetVideoFPS(uint seconds);
    
	[DllImport ("__Internal")]
    private static extern uint Kamcord_VideoFPS();
	
    //////////////////////////////////////////////////////////////////
    /// Audio Overlay APIs - only useful in some pretty rare situations
    ///
	[DllImport ("__Internal")]
	private static extern void _KamcordTurnOffAutomaticAudioRecording(bool state);

	[DllImport ("__Internal")]
	private static extern void _KamcordPlayBackgroundSound(string filePath, bool loop);
	
	// Other Kamcord methods
	[DllImport ("__Internal")]
	private static extern bool _KamcordDisable();
	
#endif
	
	// Possible values of videoQuality
	public enum VideoQuality
	{
		Standard = 0,
		Trailer	// Do not release your game with this setting!
	};


	// Public properties	
	public string developerKey = "Kamcord developer key";
	public string developerSecret = "Kamcord developer secret";
	public string appName = "Application name";
	public Kamcord.VideoQuality videoQuality = Kamcord.VideoQuality.Standard;

	// Enable voice overlay
	public bool enableVoiceOverlay = true;
	
	// Can be used to disable Kamcord on certain devices
	[System.Serializable]
	public class KamcordBlacklist
	{
		public bool ipod4Gen = false;
		public bool ipad1 = false;
		public bool iphone3gs = false;
		public bool iphone4 = false;
		public bool ipod5Gen = false;
		public bool ipad2 = false;
		public bool ipadMini = false;
	}
	
	public KamcordBlacklist deviceBlacklist;
	
	// Public methods
	void Awake()
	{
#if UNITY_IPHONE
		// Ensure this object's name
		this.gameObject.name = "KamcordPrefab";
		
		// Never destroy
		DontDestroyOnLoad(this);
		
		// Set device blacklist
		Kamcord.SetDeviceBlacklist(deviceBlacklist.ipod4Gen,
								   deviceBlacklist.ipod5Gen,
								   deviceBlacklist.iphone3gs,
								   deviceBlacklist.iphone4,
								   deviceBlacklist.ipad1,
								   deviceBlacklist.ipad2,
								   deviceBlacklist.ipadMini);

		
		// Init
		Kamcord.Init(developerKey, developerSecret, appName, videoQuality);
		KamcordCustomUI.SubscribeToCallbacks(true);
		Kamcord.SetVoiceOverlayEnabled(enableVoiceOverlay);
#endif
	}

	void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Kamcord.Pause();
		}
		
		/*!
		 * 
		 * Your game may not want to resume as soon as the application resumes!
		 * If, for instance, you have a pause menu, you'll want to call Kamcord.Resume()
		 * when the user resume the game from that pause menu. In that case, comment out
		 * this else case below.
		 * 
		 */
		else
		{
			Kamcord.Resume();
		}
	}
	
#if UNITY_IPHONE
	
	//////////////////////////////////////////////////////////////////
    /// Handling callbacks from Objective-C
    /// 

	// The Kamcord share view appeared
	private void _KamcordViewDidAppear(string empty)
	{
		if (kamcordViewDidAppear != null)
		{
			kamcordViewDidAppear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordViewDidAppear();
		}
	}
	
	private void _KamcordViewWillDisappear(string empty)
	{
		if (Kamcord.kamcordViewWillDisappear != null)
		{
			Kamcord.kamcordViewWillDisappear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordViewWillDisappear();
		}
	}
	
	// The Kamcord share view disappeared
	private void _KamcordViewDidDisappear(string empty)
	{
		if (Kamcord.kamcordViewDidDisappear != null)
		{
			Kamcord.kamcordViewDidDisappear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordViewDidDisappear();
		}
	}
	
	// The Kamcord watch view appeared
	private void _KamcordWatchViewDidAppear(string empty)
	{
		if (Kamcord.kamcordWatchViewDidAppear != null)
		{
			Kamcord.kamcordWatchViewDidAppear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordWatchViewDidAppear();
		}
	}
	
	private void _KamcordWatchViewWillDisappear(string empty)
	{
		if (Kamcord.kamcordWatchViewWillDisappear != null)
		{
			Kamcord.kamcordWatchViewWillDisappear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordWatchViewWillDisappear();
		}
	}
	
	// The Kamcord watch view disappeared
	private void _KamcordWatchViewDidDisappear(string empty)
	{
		if (Kamcord.kamcordWatchViewDidDisappear != null)
		{
			Kamcord.kamcordWatchViewDidDisappear();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.KamcordWatchViewDidDisappear();
		}
	}
	
	// The share button was pressed
	private void _ShareButtonPressed(string empty)
	{
		if (Kamcord.shareButtonPressed != null)
		{
			Kamcord.shareButtonPressed();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.ShareButtonPressed();
		}
	}
	
	// The thumbnail for the latest video is ready at this
	// absolute file path
	private void _VideoThumbnailReadyAtFilePath(string filepath)
	{
		if (Kamcord.videoThumbnailReadyAtFilePath != null)
		{
			Kamcord.videoThumbnailReadyAtFilePath(filepath);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoThumbnailReadyAtFilePath(filepath);
		}
	}
	
	// When the video begins and finishes uploading
	private void _VideoWillUploadToURL(string serializedString)
	{
		string[] stringDelimiters = new string[] { "??" };
		string[] values = serializedString.Split(stringDelimiters, StringSplitOptions.None);
		
		string videoID = values[0];
		string url = values[1];
		
		if (Kamcord.videoWillBeginUploading != null)
		{
			Kamcord.videoWillBeginUploading(videoID, url);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoWillBeginUploading(videoID, url);
		}
	}
	
	private void _VideoUploadProgressed(string serializedString)
	{
		string[] stringDelimiters = new string[] { ":" };
		string[] values = serializedString.Split(stringDelimiters, StringSplitOptions.None);
		
		string videoID = values[0];
		float progress = float.Parse(values[1]);
		
		if (Kamcord.videoUploadProgressed != null)
		{
			Kamcord.videoUploadProgressed(videoID, progress);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoUploadProgressed(videoID, progress);
		}
	}
	
	private void _VideoUploadedWithSuccess(string serializedString)
	{
		string[] stringDelimiters = new string[] { ":" };
		string[] values = serializedString.Split(stringDelimiters, StringSplitOptions.None);
		
		string videoID = values[0];
		bool truthValue = (values[1] == "true" ? true : false);
		
		if (Kamcord.videoFinishedUploading != null)
		{
			Kamcord.videoFinishedUploading(videoID, truthValue);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoFinishedUploading(videoID, truthValue);
		}
	}
	
	private void _VideoSharedToFacebook(string serializedString)
	{
		string[] stringDelimiters = new string[] { ":" };
		string[] values = serializedString.Split(stringDelimiters, StringSplitOptions.None);
		bool truthValue = (values[1] == "true" ? true : false);
		
		if (Kamcord.videoSharedToFacebook != null)
		{
			Kamcord.videoSharedToFacebook(values[0], truthValue);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoSharedToFacebook(values[0], truthValue);
		}
	}
	
	private void _VideoSharedToTwitter(string serializedString)
	{
		string[] stringDelimiters = new string[] { ":" };
		string[] values = serializedString.Split(stringDelimiters, StringSplitOptions.None);
		bool truthValue = (values[1] == "true" ? true : false);
		
		if (Kamcord.videoSharedToTwitter != null)
		{
			Kamcord.videoSharedToTwitter(values[0], truthValue);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.VideoSharedToTwitter(values[0], truthValue);
		}
	}
	
	// When the call to action button on the notification view was pressed
	private void _PushNotifCallToActionButtonPressed()
	{
		if (Kamcord.pushNotifCallToActionButtonPressed != null)
		{
			Kamcord.pushNotifCallToActionButtonPressed();
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.PushNotifCallToActionButtonPressed();
		}
	}
	
	// When the snapshot you requested is ready
	private void _SnapshotReadyAtFilePath(string filepath)
	{
		if (Kamcord.snapshotReadyAtFilePath != null)
		{
			Kamcord.snapshotReadyAtFilePath(filepath);
		}
		
		foreach (KamcordCallbackInterface listener in Kamcord.listeners)
		{
			listener.SnapshotReadyAtFilePath(filepath);
		}
	}
	
	// Called when the video with the specified localVideoID has finished its local processing and is ready to be replayed and uploaded
	private void KamcordCustomUIVideoFinishedProcessing(string localVideoID)
	{
		foreach (KamcordCustomUICallbackInterface listener in KamcordCustomUI.listeners)
		{
			listener.VideoFinishedProcessing(localVideoID);
		}
	}
	
	// Called when the video with the specified localVideoID has finished uploading
	private void KamcordCustomUIVideoFinishedUploading(string localVideoID)
	{
		foreach (KamcordCustomUICallbackInterface listener in KamcordCustomUI.listeners)
		{
			listener.VideoFinishedUploading(localVideoID);
		}
	}
	
	// Called when the upload for a video with the specified localVideoID failed
	private void KamcordCustomUIVideoUploadFailed(string localVideoID)
	{
		foreach (KamcordCustomUICallbackInterface listener in KamcordCustomUI.listeners)
		{
			listener.VideoUploadFailed(localVideoID);
		}
	}
	
	// Called when retrieval of metadata properties for a specified videoID failed for some reason
	private void KamcordCustomUIVideoRetrievalFailed(string videoID)
	{
		foreach (KamcordCustomUICallbackInterface listener in KamcordCustomUI.listeners)
		{
			listener.VideoRetrievalFailed(videoID);
		}
	}
	
	// Called when retrieval of metadata properties for a specified videoID succeeded
	private void KamcordCustomUIVideoFinishedMetadataRetrieval(string metadata)
	{
		string pattern = @"VideoID:(.*),VideoURL:(.*),ThumbnailURL:(.*),Title:(.*),Message:(.*),Level:(.*),Score:(.*)";
		Regex regex = new Regex(pattern, RegexOptions.None);
		Match match = regex.Match(metadata);
		while (match.Success) 
		{
			string videoID = match.Groups[1].Value;
			string videoURL = match.Groups[2].Value;
			string thumbnailURL = match.Groups[3].Value;
			string title = match.Groups[4].Value;
			string message = match.Groups[5].Value;
			string level = match.Groups[6].Value;
			string score = match.Groups[7].Value;
			foreach (KamcordCustomUICallbackInterface listener in KamcordCustomUI.listeners)
			{
				listener.VideoFinishedMetadataRetrieval(videoID, videoURL, thumbnailURL, title, message, level, score);
			}
			break;
		}
	}
	
#endif
}

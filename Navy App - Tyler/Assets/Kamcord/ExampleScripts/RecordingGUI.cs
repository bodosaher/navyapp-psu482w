using UnityEngine;
using System.Collections.Generic;

public class RecordingGUI : MonoBehaviour
{	
#if UNITY_IPHONE
	
	public Font buttonFont;

	private bool firstVideoRecorded;
	private Rect recordingButtonRect;
	private Rect showViewButtonRect;
	private Rect showWatchViewButtonRect;
	private System.DateTime recordingStartedAt;
	
	private bool isPaused;
	
	void Start()
	{
		firstVideoRecorded = false;
		recordingButtonRect = new Rect(20, 20, 200, 60);
		showViewButtonRect = new Rect(recordingButtonRect.x,
									  (2*recordingButtonRect.y) + recordingButtonRect.height,
									  recordingButtonRect.width,
									  recordingButtonRect.height);
		showWatchViewButtonRect = new Rect((2*recordingButtonRect.x) + recordingButtonRect.width,
									 	   recordingButtonRect.y,
									  	   recordingButtonRect.width,
									  	   recordingButtonRect.height);
		
		Kamcord.snapshotReadyAtFilePath 		+= SnapshotReadyAtFilePath;
		
		Kamcord.kamcordViewDidAppear 			+= KamcordViewDidAppear;
		Kamcord.kamcordViewWillDisappear 		+= KamcordViewWillDisappear;
		Kamcord.kamcordViewDidDisappear 		+= KamcordViewDidDisappear;
	
		Kamcord.kamcordWatchViewDidAppear 		+= KamcordWatchViewDidAppear;
		Kamcord.kamcordWatchViewWillDisappear  	+= KamcordWatchViewWillDisappear;
		Kamcord.kamcordWatchViewDidDisappear 	+= KamcordWatchViewDidDisappear;
		
		Kamcord.videoThumbnailReadyAtFilePath	+= VideoThumbnailReadyAtFilePath;
		
		Kamcord.shareButtonPressed				+= ShareButtonPressed;
		
		Kamcord.videoWillBeginUploading			+= VideoWillBeginUploading;
		Kamcord.videoUploadProgressed			+= VideoUploadProgressed;
		Kamcord.videoFinishedUploading			+= VideoFinishedUploading;
		
		Kamcord.videoSharedToFacebook			+= VideoSharedToFacebook;
		Kamcord.videoSharedToTwitter			+= VideoSharedToTwitter;
		
		Kamcord.snapshotReadyAtFilePath			+= SnapshotReadyAtFilePath;
		
		Kamcord.pushNotifCallToActionButtonPressed	+= PushNotifCallToActionButtonPressed;
	}
	
	void OnDestroy()
	{
		Kamcord.snapshotReadyAtFilePath 		-= SnapshotReadyAtFilePath;
	
		Kamcord.kamcordViewDidAppear 			-= KamcordViewDidAppear;
		Kamcord.kamcordViewWillDisappear 		-= KamcordViewWillDisappear;
		Kamcord.kamcordViewDidDisappear 		-= KamcordViewDidDisappear;

		Kamcord.kamcordWatchViewDidAppear 		-= KamcordWatchViewDidAppear;
		Kamcord.kamcordWatchViewWillDisappear  	-= KamcordWatchViewWillDisappear;
		Kamcord.kamcordWatchViewDidDisappear 	-= KamcordWatchViewDidDisappear;
		
		Kamcord.videoThumbnailReadyAtFilePath	-= VideoThumbnailReadyAtFilePath;
		
		Kamcord.shareButtonPressed				-= ShareButtonPressed;
		
		Kamcord.videoWillBeginUploading			-= VideoWillBeginUploading;
		Kamcord.videoUploadProgressed			-= VideoUploadProgressed;
		Kamcord.videoFinishedUploading			-= VideoFinishedUploading;
		
		Kamcord.videoSharedToFacebook			-= VideoSharedToFacebook;
		Kamcord.videoSharedToTwitter			-= VideoSharedToTwitter;
		
		Kamcord.snapshotReadyAtFilePath			-= SnapshotReadyAtFilePath;
		
		Kamcord.pushNotifCallToActionButtonPressed	-= PushNotifCallToActionButtonPressed;
	}
	
	void OnGUI()
	{
		GUI.skin.button.font = this.buttonFont;
		
		if ((Application.platform == RuntimePlatform.IPhonePlayer) && GUI.Button(showWatchViewButtonRect, "Show Watch View"))
		{
			Kamcord.ShowWatchView();
		}

		if (Kamcord.IsRecording())
		{
			firstVideoRecorded = true;
			if (GUI.Button(recordingButtonRect, "Stop Recording"))
			{
				Kamcord.StopRecording();
				// It is very important to set a descriptive video title for each video.
				// In addition to the video title, setting the level and score also makes
				// the watch experience significantly better.
				double gameplayDuration = (System.DateTime.Now - recordingStartedAt).TotalSeconds;
				Kamcord.SetVideoTitle("AngryBots Gameplay - " + gameplayDuration.ToString("F2") + " sec");
				Kamcord.SetLevelAndScore("Level 1", gameplayDuration);
				
				Dictionary <string, object> metadata = new Dictionary<string, object>();
				metadata.Add("key1", 1);
				metadata.Add("key2", 2);
				metadata.Add("level", "Super Saiyan");
				metadata.Add("score", 9000);
				
				Kamcord.SetVideoMetadata(metadata);
			}
		} else if (Kamcord.IsEnabled()) {
			if (GUI.Button(recordingButtonRect, "Start Recording"))
			{
				Kamcord.StartRecording();
				recordingStartedAt = System.DateTime.Now;
			}

			if (firstVideoRecorded)
			{
				if (GUI.Button(showViewButtonRect, "Show Last Video"))
				{
					Kamcord.ShowView();
				}
			}
		}
	}

	void Update()
	{
		foreach(LocalNotification notif in NotificationServices.localNotifications)
		{
			if (notif.userInfo.Contains("Kamcord")) {
				Kamcord.handleKamcordNotification(notif);
			}
		}
		NotificationServices.ClearLocalNotifications();
	}
	
	
	// The Kamcord share view appeared and disappeared
	public void KamcordViewDidAppear()				{ Debug.Log("KamcordViewDidAppear"); }
	public void KamcordViewWillDisappear()			{ Debug.Log("KamcordViewWillDisappear"); }
	public void KamcordViewDidDisappear()			{ Debug.Log("KamcordViewDidDisappear"); }
	
	// The Kamcord watch view appeared and disappeared
	public void KamcordWatchViewDidAppear()			{ Debug.Log("KamcordWatchViewDidAppear"); }
	public void KamcordWatchViewWillDisappear()		{ Debug.Log("KamcordWatchViewWillDisappear"); }
	public void KamcordWatchViewDidDisappear()		{ Debug.Log("KamcordWatchViewDidDisappear"); }
	
	// The thumbnail for the latest video is ready at
	// this absolute filepath.
	void VideoThumbnailReadyAtFilePath(string filepath)	{ Debug.Log("Thumbnail ready at: " + filepath); }
	
	// The user pressed the share button
	void ShareButtonPressed()	{ Debug.Log("ShareButtonPressed."); }
	
	// When the video begins and finishes uploading
	void VideoWillBeginUploading(string videoID, string url)
	{
		Debug.Log("Video " + videoID + " will begin uploading: " + url);
	}
	
	void VideoUploadProgressed(string videoID, float progress)
	{
		Debug.Log("Video " + videoID + " upload progressed: " + progress);
	}
	
	void VideoFinishedUploading(string videoID, bool success)
	{
		Debug.Log("Video " + videoID + " finished uploading: " + success);
	}
	
	// When the video has finished sharing to Facebook and/or Twitter
	void VideoSharedToFacebook(string videoID, bool success)
	{
		Debug.Log("VideoSharedToFacebook: " + videoID);
	}
	
	void VideoSharedToTwitter(string videoID, bool success)
	{
		Debug.Log("VideoSharedToTwitter: " + videoID);
	}
	
	// When the snapshot you requested via Kamcord.Snapshot(...) is ready
	public void SnapshotReadyAtFilePath(string filepath)
	{
		Debug.Log("Snapshot ready at filepath: " + filepath);
	}
	
	// When the call to action button on the push notification view was pressed
	void PushNotifCallToActionButtonPressed() 	{ Debug.Log("PushNotifCallToActionButtonPressed"); }
#endif
}

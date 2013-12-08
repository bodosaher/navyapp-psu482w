using UnityEngine;
using System.Collections;

public class CustomUIRecordingGUI : MonoBehaviour, KamcordCustomUICallbackInterface
{  
#if UNITY_IPHONE
	public Font buttonFont;

	private bool isRecording;
	private string localVideoIDForLastVideo;
	private Rect recordingButtonRect;
	private Rect showReplayButtonRect;
	private Rect uploadVideoButtonRect;

	void Start()
	{
		isRecording = false;
		localVideoIDForLastVideo = null;
		recordingButtonRect  = new Rect(20, 20, 200, 60);
		showReplayButtonRect = new Rect(recordingButtonRect.x,
		  							    (2*recordingButtonRect.y) + recordingButtonRect.height,
									    recordingButtonRect.width,
									    recordingButtonRect.height);
		uploadVideoButtonRect = new Rect(recordingButtonRect.x,
		       							 (3*recordingButtonRect.y) + (2*recordingButtonRect.height),
										 recordingButtonRect.width,
										 recordingButtonRect.height);
		KamcordCustomUI.AddListener(this);
	}

	void OnGUI()
	{
		GUI.skin.button.font = this.buttonFont;
		if (isRecording)
		{
			if (GUI.Button(recordingButtonRect, "Stop Recording"))
			{
				isRecording = false;
				localVideoIDForLastVideo = KamcordCustomUI.StopRecordingAndGetLocalVideoID();
			}
		} else if (localVideoIDForLastVideo == null) {
			if (GUI.Button(recordingButtonRect, "Start Recording"))
			{
				isRecording = true;
				KamcordCustomUI.StartNewRecording();
			}
		} else {
			if (GUI.Button(recordingButtonRect, "Start Recording"))
			{	
				isRecording = true;
				KamcordCustomUI.ClearContentForVideosWithLocalVideoID(localVideoIDForLastVideo);
				KamcordCustomUI.StartNewRecording();
			}
			if (GUI.Button(showReplayButtonRect, "Show Last Video"))
			{
				KamcordCustomUI.ShowVideoFullScreenForLocalVideoID(localVideoIDForLastVideo);
			}
			if (GUI.Button(uploadVideoButtonRect, "Upload Last Video"))
			{
				KamcordCustomUI.UploadVideoForLocalVideoID(localVideoIDForLastVideo);
			}
		}
	}
	
	// Called when the video with the specified localVideoID has finished its local processing and is ready to be replayed and uploaded
	public void VideoFinishedProcessing(string localVideoID)
	{
		Debug.Log ("Video finished processing for local video ID: " + localVideoID);
	}
	
	// Called when the video with the specified localVideoID has finished uploading
	public void VideoFinishedUploading(string localVideoID)
	{
		Debug.Log ("Video finished uploading for local video ID: " + localVideoID);
	}

	// Called when the upload for a video with the specified localVideoID failed
	public void VideoUploadFailed(string localVideoID)
	{
		Debug.Log ("Video upload failed for local video ID: " + localVideoID);
	}
	
	// Called when retrieval of metadata properties for a specified videoID finished successfully
	public void VideoFinishedMetadataRetrieval(string videoID,
		string videoURL,
		string thumbnailURL,
		string title,
		string message,
        string level,
        string score)
	{
		Debug.Log ("Video metadata retrieval finished: VideoID: " + videoID + "; VideoURL: " + videoURL + "; ThumbnailURL: " + thumbnailURL
			+ "; Title: " + title + "; Message: " + message + "; Level: " + level + "; Score: " + score);
	}
	
	// Called when retrieval of metadata properties for a specified videoID failed for some reason
	public void VideoRetrievalFailed(string videoID)
	{
		Debug.Log ("Video retrieval failed for video ID: " + videoID);
	}
#endif
}

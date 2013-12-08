// ---------------------------------------------------------------------------
// This is the interface that KamcordCustomUICallbackInterface implements. These
// are all the possible callbacks that the KamcordCustomUI implementation
// will make back into Unity.
// ---------------------------------------------------------------------------

public interface KamcordCustomUICallbackInterface
{
#if UNITY_IPHONE  
	// Called when the video with the specified localVideoID has finished its local processing and is ready to be replayed and uploaded
	void VideoFinishedProcessing(string localVideoID);
	
	// Called when the video with the specified localVideoID has finished uploading
	void VideoFinishedUploading(string localVideoID);

	// Called when the upload for a video with the specified localVideoID failed
	void VideoUploadFailed(string localVideoID);

	// Called when the video data has been retrieved from the Kamcord servers
  	void VideoFinishedMetadataRetrieval(string videoID,
										string videoURL,
										string thumbnailURL,
										string title,
										string message,
        								string level,
        								string score);

	// Called when retrieval of metadata properties for a specified videoID failed for some reason
	void VideoRetrievalFailed(string videoID);
#endif
}

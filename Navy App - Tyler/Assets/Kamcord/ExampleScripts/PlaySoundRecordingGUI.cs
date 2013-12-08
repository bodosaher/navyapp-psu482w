using UnityEngine;
using System.Collections;

public class PlaySoundRecordingGUI : MonoBehaviour
{       
#if UNITY_IPHONE
	public Font buttonFont;

	private bool firstVideoRecorded;
	private Rect recordingButtonRect;
	private Rect showViewButtonRect;
	private Rect playSoundRect;

	void Start()
	{
		firstVideoRecorded = false;
		recordingButtonRect = new Rect(20, 20, 250, 60);
		showViewButtonRect = new Rect(recordingButtonRect.x,
									  (2*recordingButtonRect.y) + recordingButtonRect.height,
									  recordingButtonRect.width,
									  recordingButtonRect.height);
        playSoundRect = new Rect(recordingButtonRect.x,
                                 (3*recordingButtonRect.y) + 2*recordingButtonRect.height,
                                 recordingButtonRect.width,
                                 recordingButtonRect.height);

		Kamcord.TurnOffAutomaticAudioRecording(true);
	}

	void OnGUI()
	{
		GUI.skin.button.font = this.buttonFont;

		if (Kamcord.IsRecording())
		{
			firstVideoRecorded = true;
			if (GUI.Button(recordingButtonRect, "Stop Recording"))
			{
				Kamcord.StopRecording();
			}
            if (GUI.Button(playSoundRect, "Play Sound"))
            {
                Kamcord.PlayBackgroundSound("kamcord_test.mp3", false);
            }
        }  else if (Kamcord.IsEnabled()) {
            if (GUI.Button(recordingButtonRect, "Start Recording"))
            {
                Kamcord.StartRecording();
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
#endif
}

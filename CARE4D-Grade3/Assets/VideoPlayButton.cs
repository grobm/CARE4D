using UnityEngine;
using System.Collections;

public class VideoPlayButton : MonoBehaviour {

	public string URL;

	VideoPlaybackBehaviour video;

	// Use this for initialization
	void Start () {
		//video = gameObject.GetComponent<VideoPlaybackBehaviour>();
	}


	public void PlayAttachedVideo() {
		//if(!video)
		//	video = gameObject.GetComponent<VideoPlaybackBehaviour>();

		Handheld.PlayFullScreenMovie (URL, Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
}

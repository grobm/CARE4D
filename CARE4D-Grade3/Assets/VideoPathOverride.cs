using UnityEngine;
using System.Collections;

public class VideoPathOverride : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Transform myparent = transform.parent;
		VideoPlaybackBehaviour myBehavior = GetComponent<VideoPlaybackBehaviour> ();
		myBehavior.m_path = myparent.name + ".mp4";

	}

//	HingeJoint hinge = GetComponent<HingeJoint>();
//	hinge.useSpring = false;

}

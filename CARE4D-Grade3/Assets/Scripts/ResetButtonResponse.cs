using UnityEngine;
using System.Collections;

public class ResetButtonResponse : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void OnMouseUp () 
	{
		GameObject.FindObjectOfType<ObjectiveTracker> ().Reset ();
		//GameObject.FindObjectsOfType<ObjectiveResponse> ();
	}
}

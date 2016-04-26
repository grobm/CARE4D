using UnityEngine;
using System.Collections;

public class SelectOnClick : Objective {

	// Use this for initialization
	void Start () 
	{
	
	}

	
	public override void Reset()
	{

	}

	// Update is called once per frame
	void OnMouseUp () 
	{
		ButtonSelector selector = GameObject.FindObjectOfType<ButtonSelector> ();
		selector.SetSelected (gameObject);
		complete = true;
        Reset();

	}
}

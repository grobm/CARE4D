using UnityEngine;
using System.Collections;

public abstract class ObjectiveResponse : MonoBehaviour {
	
	public long objective;
	
	protected ObjectiveTracker tracker;

	// Use this for initialization
	void Start () {
		tracker = GameObject.FindObjectOfType<ObjectiveTracker> ();
		gameObject.GetComponent<Renderer>().enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!tracker) {
			tracker = GameObject.FindObjectOfType<ObjectiveTracker> ();
		}
		if ((objective & tracker.completedObjectiveFlags) == objective) 
			Respond ();
	
	}

	protected abstract void Respond ();
	public abstract void Reset ();
}

using UnityEngine;

// The parent class for objectives.
// Requires an ObjectiveTracker to be in the scene.
// This will only work for one objective tracker per scene.
public abstract class Objective : MonoBehaviour {

	public bool destroyOnComplete = false;
	public long prereqMask;
	public long uniqueFlag;
	public bool complete;
	public bool resetOnFailure;

	private ObjectiveTracker tracker;

	void Start () {
		complete = false;
		resetOnFailure = true;

		foreach (Objective o in GameObject.FindObjectsOfType<Objective>()) {
			if(uniqueFlag == o.uniqueFlag)
			{
				Debug.Log ("Unique ID is not unique, dummy.");
				Debug.Break();
			}
		}
	}

	void Update () 
	{
		if (complete) {
			TriggerComplete (true);
		} else
			TriggerComplete (false);
	}

	void TriggerComplete(bool completed)
	{
		if (!tracker)
			tracker = GameObject.FindObjectOfType<ObjectiveTracker> ();

		if (completed) {
			if (!tracker.ObjectiveCompleted (uniqueFlag, prereqMask)) {
				complete = false;
				if (resetOnFailure)
					Reset ();
				return;
			}

			if (destroyOnComplete)
				Destroy (gameObject);
		} else
			tracker.ObjectiveUncompleted (uniqueFlag);
	}

	public abstract void Reset();
}

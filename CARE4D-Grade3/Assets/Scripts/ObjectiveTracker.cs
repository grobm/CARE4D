using UnityEngine;
using System.Collections.Generic;

// This is used to track any number of objectives up to 64
// Currently only works with one ObjectiveTracker per scene.
public class ObjectiveTracker : MonoBehaviour {

	public long completedObjectiveFlags;

	private long goalObjectiveFlags;
	private bool completed;

	void Start () 
	{
		completedObjectiveFlags = 0;
		foreach (Objective o in GameObject.FindObjectsOfType<Objective>()) {
			goalObjectiveFlags |= o.uniqueFlag;
		}
		completed = false;
	}

	public bool ObjectiveCompleted(long flag, long prereqs)
	{
		if (prereqs == (prereqs & completedObjectiveFlags) ) {
			completedObjectiveFlags |= flag;
			return true;
		}
		return false;
	}

	public void ObjectiveUncompleted(long flag)
	{
		completedObjectiveFlags &= (flag ^ 0xFFFFFFFF);
	}

	void Update () 
	{
		if (completedObjectiveFlags != goalObjectiveFlags) {
			//Debug.Log(completedObjectiveFlags + " " +goalObjectiveFlags);
			return;
		}

		if (!completed) {
			completed = true;
			//Debug.Log ("You did it!");
			//throw a party;
		}
	}

	public void Reset()
	{
		
		Objective[] objectives = GameObject.FindObjectsOfType<Objective> ();
		foreach (Objective objective in objectives) {
			ObjectiveUncompleted(objective.uniqueFlag);
			objective.Reset();
		}
		ObjectiveResponse[] responses = GameObject.FindObjectsOfType<ObjectiveResponse> ();
		foreach (ObjectiveResponse response in responses) {
			response.Reset();
		}
	}
}

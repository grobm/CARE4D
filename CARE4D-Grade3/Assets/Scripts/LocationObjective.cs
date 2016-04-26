using UnityEngine;
using System.Collections;

/***************************************
 * This is a simple instance of an objective.
 * It is triggered when an object is placed in the correct position.
 * 
 * Place on an object you want to move to a location. 
 * When it gets there, alert completion.
 */
public class LocationObjective : Objective {

	public Vector3 targetPosition;
	public float minDistance; 

	protected bool onTarget;
	private Vector3 startPosition; 

	void Start () 
	{
		startPosition = transform.position;
	}

	void OnMouseUp () 
	{
		if (Vector3.Distance(transform.position,targetPosition) <= minDistance)
			complete = true;
		else
			complete = false;
	}

	void OnTriggerEnter()
	{
		if (Vector3.Distance(transform.position,targetPosition) <= minDistance)
			complete = true;
		else
			complete = false;
	}

	public override void Reset()
	{
		transform.position = startPosition;
		complete = false;
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.DrawSphere(targetPosition, minDistance);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZoomViewer : MonoBehaviour {

//	public Transform lookPosition;
	public Vector3 lookPosition;
	public Slider zoomSlider;
	public int maxDistance;
	public int minDistance;

	float targetDistance;
	bool valueChanged = false;

	// Use this for initialization
	void Start () 
	{
		//zoomSlider.enabled = false;
		transform.LookAt(lookPosition);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance(transform.position, lookPosition);
		//float targetDistance = maxDistance * zoomSlider.value;
		
		targetDistance = maxDistance * zoomSlider.normalizedValue;
		if(targetDistance < minDistance)
			targetDistance = minDistance;
		else if (targetDistance > maxDistance)
			targetDistance = maxDistance;

		if(Mathf.Abs(distance - targetDistance) < 10f)
			return; // close enough.
			
		if(distance > targetDistance)
			transform.position = (transform.position + transform.forward * 3f);
		if(distance < targetDistance)
			transform.position = (transform.position - transform.forward * 3f);

		while(distance > maxDistance) {
			transform.position = transform.position + transform.forward * 3f;
			distance = Vector3.Distance(transform.position, lookPosition);
			if(distance > 100000f)
				return;
		}

		while(distance < minDistance) {
			transform.position = transform.position - transform.forward * 1f;
			distance = Vector3.Distance(transform.position, lookPosition);
			if(distance > 100000f)
				return;
		}

		//transform.position
	}

	public void SetTargetDistance() {
		valueChanged = true;
	}
}

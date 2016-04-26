using UnityEngine;
using System.Collections;

public class GrabAugmentedObject : MonoBehaviour
{

	GameObject target;
	Vector2 reticlePosition;
	GameObject highlightedTarget;
	GameObject highlightedTargetLastFrame;
	Color startingColor;

	float holdTime1 = 0.1f;
	float touchTime;
	bool touchStarted;

	// Use this for initialization
	void Start ()
	{
		reticlePosition = new Vector2 (Screen.width / 2, Screen.height / 2);
		touchStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target == null) {
			Ray ray = Camera.main.ScreenPointToRay (reticlePosition);
			RaycastHit hit; 

			highlightedTargetLastFrame = highlightedTarget;

			//Check to see if anything is under the reticle:
			if (Physics.Raycast (ray, out hit, 1000)) {
				highlightedTarget = hit.transform.gameObject;

			} else
				highlightedTarget = null;

			// New selectable object detected 
			// or reticle moved off of current object:
			if (highlightedTargetLastFrame != highlightedTarget) {
				SetColors ();
			}

			if (Input.GetMouseButtonDown (0)) {
				if(!touchStarted){
					touchTime = Time.time;
					touchStarted = true;
				}
				if (highlightedTarget && touchTime + holdTime1 < Time.time) {
					target = highlightedTarget;
					Renderer r = highlightedTargetLastFrame.GetComponent<Renderer> ();
					r.material.color = startingColor;
				}
			} else touchStarted = false;
		} else {
			target.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 250;
			if (Input.GetMouseButtonDown (0)) {
				DropObject();
			}
		}
	}

	void SetColors ()
	{
		if (highlightedTarget) {
			//Color it green to show it's selectable:
			Renderer r = highlightedTarget.GetComponent<Renderer> ();
			startingColor = r.material.color;
			r.material.color = Color.green;
		}
		
		if (highlightedTargetLastFrame) {
			//Set the color back to normal:
			Renderer r = highlightedTargetLastFrame.GetComponent<Renderer> ();
			r.material.color = startingColor;
		}
	}

	void DropObject ()
	{
		target = null;
	}

	void Remove()
	{
		Destroy (target);
	}

	void Duplicate ()
	{
		GameObject newObject = Instantiate (target);
		newObject.transform.SetParent(target.transform.parent);
		newObject.transform.localScale = target.transform.localScale;
		newObject.transform.position = target.transform.position;
	}

	void OnGUI ()
	{
		if (target) {
			if (GUI.Button (new Rect (10, 10, 300, 200), "Drop"))
				Remove ();
			if (GUI.Button (new Rect (10, 325, 300, 200), "Duplicate"))
				Duplicate ();
		}
	}
}

using UnityEngine;
using System.Collections;

public class TapToPlunge : MonoBehaviour {
	
	public Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		Rigidbody r = gameObject.GetComponent<Rigidbody>();
		//r.useGravity = false;
		r.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		transform.position = targetPosition;
		Rigidbody r = gameObject.GetComponent<Rigidbody>();
		r.useGravity = true;
		r.isKinematic = false;
	}
}
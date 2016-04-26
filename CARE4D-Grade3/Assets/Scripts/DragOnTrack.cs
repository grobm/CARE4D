using UnityEngine;
using System.Collections;

public class DragOnTrack : MonoBehaviour {

	Vector3 pointA;
	public Vector3 pointB;
	public bool snapToEnds;
	public float snapDistance = 1f;
	public bool curved = true;

	private Ray trackRay;
	private bool selected;

	private Vector3 debugPointA;
	private Vector3 debugPointB;

	void Start () 
	{
		// Use this to ignore the z component to make it easier to line up mouse clicks
		pointA = transform.position;
		Vector3 tempVector = pointA;
		//tempVector.z = pointB.z;

		//transform.position = pointA;

		// This ray is used to keep the object along a track:
		trackRay.origin = tempVector;
		trackRay.direction = pointB - tempVector;

		selected = false;
		debugPointA = new Vector3 ();
		debugPointB = new Vector3 ();

		Rigidbody r = gameObject.GetComponent<Rigidbody>();
		r.Sleep();
	}

	void OnMouseDown()
	{
		selected = true;
		Rigidbody r = gameObject.GetComponent<Rigidbody>();
		r.detectCollisions = false;
	}

	void OnMouseUp()
	{
		selected = false;
		Rigidbody r = gameObject.GetComponent<Rigidbody>();
		r.detectCollisions = true;
		r.velocity = Vector3.zero;
	}

	void Update () 
	{
		if (selected) {

			// Find where in the world the user touched.
			Vector3 touchWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Vector3.Distance(transform.position, Camera.main.transform.position)));
			debugPointB = touchWorldPoint;

			// Get the closest point on the track where a user touches:
			Vector3 newPosition = trackRay.origin + trackRay.direction * Vector3.Dot (trackRay.direction, touchWorldPoint - trackRay.origin);
			debugPointA = newPosition;

			if(curved) {
				float distanceX = Vector2.Distance(new Vector2(newPosition.x, newPosition.z), new Vector2(pointA.x, pointA.z));
				float ratio = distanceX / Vector2.Distance(new Vector2(pointB.x, pointB.z), new Vector2(pointA.x,pointA.z));
				if(distanceX > 0 && ratio < 1){
					float yPos = newPosition.y;
					float deltaY = pointB.y - pointA.y;

					yPos = yPos + (distanceX * Mathf.PI) *Mathf.Pow(ratio* Mathf.PI,0.25f) * Mathf.Pow (Mathf.Sin (ratio * Mathf.PI),0.5f);;
					Vector3 curvedPosition = new Vector3(newPosition.x, yPos, newPosition.z);
					newPosition = curvedPosition;
				}
			}

			transform.position = newPosition;

			//Clamp to the endpoints:
			Vector3 midPoint = (pointA + pointB)*0.5f;
			transform.position = midPoint + Vector3.ClampMagnitude(newPosition-midPoint, Vector3.Distance(midPoint,pointA));

			if(snapToEnds)
				SnapToEnds();
		}
	}

	private void SnapToEnds()
	{
		if (Vector3.Distance (transform.position, pointA) <= snapDistance)
			transform.position = pointA;
		else if (Vector3.Distance (transform.position, pointB) <= snapDistance)
			transform.position = pointB;
	}

	// debug drawing:
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		
		//Draw two spheres at the end points
		Gizmos.DrawSphere(pointA, 1f);
		Gizmos.DrawSphere(pointB, 1f);
		Gizmos.DrawLine(pointA, pointB);
				
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(debugPointA, 2f);
		
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(debugPointB, 2f);
		Gizmos.DrawSphere(transform.position, 1f);
	}
}
/*
[CustomEditor(typeof(DragOnTrack))]
public class DragScriptEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DragOnTrack myTarget = (DragOnTrack)target;
		
		DrawDefaultInspector();
		
		if (myTarget.snapToEnds) {
			EditorGUILayout.FloatField("Snap Distance", 1);
		}
		
		//if(myScript.flag)
		//	myScript.i = EditorGUILayout.IntSlider("I field:", myScript.i , 1 , 100);
		
	}
}
*/
using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public const int REVOLVE_SPEED = 20000;

	public GameObject objectToOrbit;
	public float periodOfRevolution;

	float deltaAngle;

	Vector3 axis; 

	void Start () 
	{
		//axis = objectToOrbit.transform.position - transform.position;
		//axis = new Vector3(-axis.z, axis.y, axis.x);

		deltaAngle = (1/periodOfRevolution) * Time.timeScale * REVOLVE_SPEED;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.RotateAround(objectToOrbit.transform.position, objectToOrbit.transform.up, deltaAngle * Time.deltaTime);
	}
}

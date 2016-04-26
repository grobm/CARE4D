using UnityEngine;
using System.Collections;

public class ChangeColorOnObjective : ObjectiveResponse {

	public Color targetColor;
	public float timeOfChange = 100;

	Color startColor;
	Color colorPerFrame ;
	int count = 0;

	// Use this for initialization
	void Start () {
		Renderer r = gameObject.GetComponent<Renderer> ();
		startColor = r.material.color;
		Color colorDelta = startColor - targetColor;
		colorPerFrame = colorDelta / (timeOfChange );
	}
	
	protected override void Respond ()
	{
		if (count < timeOfChange) {
			Renderer r = this.gameObject.GetComponent<Renderer> ();
			r.material.color = r.material.color - colorPerFrame;
			count++;
		}
	}
	
	public override void Reset ()
	{
		Renderer r = gameObject.GetComponent<Renderer> ();
		r.material.color = startColor;
		count = 0;
	}
	
}

using UnityEngine;
using System.Collections;

public class AnimateOnObjective : ObjectiveResponse {

	// Use this for initialization
	void Start () {
	
	}

	protected override void Respond ()
	{
		Animation animation = gameObject.GetComponent<Animation> ();
		animation.clip.wrapMode = WrapMode.Once;
		animation.Play ();
	}
	
	public override void Reset ()
	{
		Animation animation = gameObject.GetComponent<Animation> ();
		animation.clip.wrapMode = WrapMode.Once;
		animation.Stop ();
	}
}

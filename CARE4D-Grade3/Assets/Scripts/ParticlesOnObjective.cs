using UnityEngine;
using System.Collections;

public class ParticlesOnObjective : ObjectiveResponse {

	// Use this for initialization
	void Start () {
	
	}
	
	protected override void Respond ()
	{
		ParticleSystem particles = gameObject.GetComponent<ParticleSystem> ();
		if (!particles.isPlaying) {
			particles.Play ();

		}
	}
	
	public override void Reset ()
	{
		
		ParticleSystem particles = gameObject.GetComponent<ParticleSystem> ();
		particles.Stop ();
	}
}

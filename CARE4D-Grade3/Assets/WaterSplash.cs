using UnityEngine;
using System.Collections;

public class WaterSplash : MonoBehaviour {
	
	public ParticleSystem splashParticles;
	public ParticleSystem rippleParticles;

	public MeshCollider waterCollider;

	// Use this for initialization
//	void Start () {
//		waterCollider = gameObject.AddComponent<MeshCollider>();
//		waterCollider.convex = true;
//		waterCollider.isTrigger = true;
//	}
	
	void OnTriggerEnter(Collider other) {
			splashParticles.transform.position = other.transform.position;
			splashParticles.Clear();
			splashParticles.Play ();
			rippleParticles.transform.position = other.transform.position;
			rippleParticles.Clear();
			rippleParticles.Play ();
	}
}

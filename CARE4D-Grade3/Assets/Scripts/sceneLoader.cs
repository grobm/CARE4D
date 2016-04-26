using UnityEngine;
using System.Collections;

public class sceneLoader : MonoBehaviour {
	public string Sceneloading;

	void Start() {
//		print("Starting " + Time.time);
		StartCoroutine(WaitAndLoad(2.0F));
	}

	IEnumerator WaitAndLoad(float waitTime) {
		Debug.Log ("Loading: " + Sceneloading);
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevelAdditiveAsync (Sceneloading);
		print("WaitAndLoad " + Time.time);
		Destroy (gameObject);
	}
}

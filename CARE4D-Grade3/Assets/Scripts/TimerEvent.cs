using UnityEngine;
using System.Collections;

public class TimerEvent : MonoBehaviour {
	public float timerduration = 0.0f;
//	public string PublicFunctionCall = "";
//	public GameObject LoadScreen;
//	public GameObject LoginScreen;

	public void Start(){
		StartCoroutine(timer());//timer ();
	}

		public IEnumerator timer() {
//		print(Time.time);
		yield return new WaitForSeconds(timerduration);
		Application.LoadLevel("LoginScreenActive");
//		LoginScreen.SetActive (true);
//		LoadScreen.SetActive (false);

//		BroadcastMessage (PublicFunctionCall);
//		print(Time.time);
	}
		
}

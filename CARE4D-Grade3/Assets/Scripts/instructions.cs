using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {
	public GameObject Slide1;
	public GameObject Slide2;
	public GameObject Slide3;
	public GameObject Slide4;
	public int InstructionsDone;
	public float Slidenum = 0.00f;
	public float sensitivity = 0.10f;
	float prevTouchTime = 0f;
	
	void Start(){
		InstructionsDone = (PlayerPrefs.GetInt("viewinstructions"));
		
		//if (InstructionsDone == 1) {
		//	Destroy (gameObject);
		//} 
		//else {
			Slidenum = 0;
			Slide1.SetActive (true);
			Slide2.SetActive (false);
			Slide3.SetActive (false);
			Slide4.SetActive (false);
		//}
	}
	
	void OnTap(){
		Slidenum = Slidenum +sensitivity;
	}
	
	void Update(){

		if(Input.GetMouseButton(0)) {
			if(Time.time > prevTouchTime + sensitivity) 
			{
				prevTouchTime = Time.time;
				Slidenum++;
			}
		}

		//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
		//	OnTap ();
		//}
		
		
		if (Slidenum > 0) {
			Slide1.SetActive(false);
			Slide2.SetActive(true);
			Slide3.SetActive(false);
			Slide4.SetActive(false);
		} 
		
		if (Slidenum > 1) {
			Slide1.SetActive(false);
			Slide2.SetActive(false);
			Slide3.SetActive(true);
			Slide4.SetActive(false);
		} 
		if (Slidenum > 2) {
			Slide1.SetActive(false);
			Slide2.SetActive(false);
			Slide3.SetActive(false);
			Slide4.SetActive(true);
		} 
		if (Slidenum > 3){
			PlayerPrefs.SetInt("viewinstructions",InstructionsDone);
			Slidenum = 0;
			Slide1.SetActive (true);
			Slide4.SetActive(false);
			this.gameObject.SetActive(false);
		}
	}
	
	
}
using UnityEngine;
using System.Collections;

public class Aerodrome : MonoBehaviour {
	public int index = 0;
	public GameObject[] aircraft;
//	public GUISkin mySkin2;
//	public int Mode;
//	public GUISkin skin;
//	public Texture2D Logo;

	// Use this for initialization
	void Start () {
//		index = PlayerPrefs.GetInt("myAircraft");
		if (index == null){
			index = 0;
			aircraft[index].SetActive(true);
		}
		if (index <= 1) {
			index = 0;
			aircraft[index].SetActive(true);
		}

	}

	public void SwitchAircraft(){
		index = index + 1;
		if (index > 1) {
			index = 0;
			//			aircraft[index].SetActive(true);
		}
	}

	public void ExitMenu(){
		Application.LoadLevel ("menu");
	}

	public void FixedUpdate(){

		aircraft [0].SetActive (false);
		aircraft [1].SetActive (false);
		//			aircraft[12].SetActive(false);
		aircraft [index].SetActive (true);
	}
	
//	public void OnGUI ()
//	{
//		if(skin)
//			GUI.skin = skin;
//		
//		if (GUI.Button(new Rect(10,100,120,30),"Switch Aircraft"))
//		{
//			index = index+1;
//			if(index >= 1){
//				index = 0;
//			}
//			if(index == 0){
//				index = 1;
//			}
//			aircraft[0].SetActive(false);
//			aircraft[1].SetActive(false);
////			aircraft[12].SetActive(false);
//			aircraft[index].SetActive(true);
//
//		}
//		if (GUI.Button (new Rect(10,10,60,40),"Back"))
//		{
////			PlayerPrefs.SetInt("myAircraft",index);
//			Application.LoadLevel("menu");
//		}
//		
//	}
}




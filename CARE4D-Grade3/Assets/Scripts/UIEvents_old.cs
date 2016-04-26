using UnityEngine;
using System.Collections;

public class UIEvents_old : MonoBehaviour {
	public string Level1;
	public string Level2;
	public string Level3;
	public string Level4;
	public string Level5;
	public string Level6;
	public string Level7;
	public string Level8;
	public string path = "";
	// Use this for initialization
	void Start () {
//		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ARBase(){
//		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Application.LoadLevel("ARBase");
	}

	public void GoObject(){
//		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel("ObjectViewer");
	}

	public void Home(){
//		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel("Main");
	}

	void LoadScreen(){
//		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel("ARBase");
	}


	void GoAbout(){
//		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel(Level4);
	}
	void GoSettings(){
//		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel(Level5);
	}
	void GoVR(){
//		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Application.LoadLevel("basic_vr");
	}
	void GoVRMenu(){
//		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Application.LoadLevel(Level7);
	}
	void GoAR_VR(){
//		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Application.LoadLevel(Level8);
	}

	void About_Facebook(){
		Application.OpenURL("https://www.facebook.com/coreared");
	}
	void About_Linkedin(){
		Application.OpenURL("https://www.linkedin.com/company/5231015?trk=tyah&trkInfo=tarId%3A1415828624318%2Ctas%3Acore%20augment%2Cidx%3A1-1-1");
	}
	void About_Twitter(){
		Application.OpenURL("https://twitter.com/coreARed_org");
	}

	void Snapshot(){
		string cliplabel;	
		cliplabel = "CARE4D.png";// LocationInfo.timestamp + ".png";  <--- add timestamp here later
		//Application.CaptureScreenshot("Assets/savedmeshes/assets/ " + "Screenshot2.png");
//		path = Application.persistentDataPath + "/Snapshots/" + cliplabel;
//		print (path);

		Application.CaptureScreenshot(cliplabel);

		// Encode texture into PNG
//		byte[] bytes = imageOverview.EncodeToPNG();
		
		// save in memory
		//string filename = fileName(Convert.ToInt32(imageOverview.width), Convert.ToInt32(imageOverview.height));
//		path = Application.persistentDataPath + "/Snapshots/" + filename;
		
//		System.IO.File.WriteAllBytes(path, bytes);

	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovieLauncher : MonoBehaviour {

	public Text ProgressIcon;
	public string clipName  = "5M-018";
	public string textprogress = "";
	public string serverUrl  = "http://markgrob.com/CARE/streamedmedia/lite/ARL";
//	public GameObject Loadicon;

	void Start(){
		clipName = this.name;
	}
//
	IEnumerator UpdateTextAfterLoad() {
		yield return new WaitForSeconds(1);
		ProgressIcon.text = textprogress;
	}

	public void MovieLaunch(){
//		clipName = this.name;
//		ProgressIcon = GetComponent<Text>(); 
		textprogress = ProgressIcon.text;
		ProgressIcon.text = "Loading...";
		Handheld.PlayFullScreenMovie (serverUrl+clipName+".mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
//		ProgressIcon.text = textString;
		StartCoroutine("UpdateTextAfterLoad");
	}


}

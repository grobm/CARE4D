using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadPDF : MonoBehaviour {
	public Text ProgressPDFIcon;
//	public string clipName  = "5M-018";
	public string textString = "";
	public string serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvbkYwbmp3eDZXZUE";


	IEnumerator UpdateTextAfterLoad() {
		yield return new WaitForSeconds(1);
		ProgressPDFIcon.text = textString;
	}

	public void PDFLaunch(){
		textString = ProgressPDFIcon.text;
		ProgressPDFIcon.text = "Loading...";
		Application.OpenURL(serverUrl);
//		ProgressIcon.text = textString;
		StartCoroutine("UpdateTextAfterLoad");
	}
}

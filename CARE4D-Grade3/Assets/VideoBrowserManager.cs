using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoBrowserManager : MonoBehaviour {
	public GameObject Browser;
	public GameObject mYViewer;
	public GameObject videoBack;
	public string CurentClip;
	public Text ClipSubject;
	public Text ClipTitle;
	public Text GradeTitle;
	public string mySubject = ""; //Mathematics... 
	public string gradeValue = ""; //k,1,2 3,4,5,6,7,8,9...
	public string subjectVale = ""; //m = math, e= english... 

	// Use this for initialization
	void OnEnable () {
//		mySubject = PlayerPrefs.GetString ("Subject");
		gradeValue = PlayerPrefs.GetString ("MyGradeValue");
		subjectVale = PlayerPrefs.GetString ("SubjectVale");
		CurentClip = PlayerPrefs.GetString ("myClip");
		ClipSubject.text = PlayerPrefs.GetString ("Subject");
		ClipTitle.text = PlayerPrefs.GetString ("LessonTitle");
		GradeTitle.text = PlayerPrefs.GetString ("GradeTitle");

		//		gradeValue = PlayerPrefs.GetString ("MyGradeValue");
	}

	public void BacktoCatalog(){
		mYViewer.SetActive(false);
		Browser.SetActive(true);
		videoBack.SetActive(false);
		return;
	}


}

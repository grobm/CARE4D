using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatalogScript : MonoBehaviour {
	public GameObject IconELA;
	public GameObject IconMath;
	public GameObject IconScience;
	public GameObject IconHistory;
	public GameObject Browser;
	public GameObject mYViewer;
	public GameObject videoBack;
	public string mySubject = ""; //Mathematics... 
	public string gradeValue = ""; //k,1,2 3,4,5,6,7,8,9...
	public string subjectVale = ""; //m = math, e= english... 
	public Text ProgressPDFIcon;

	//	public string clipName  = "5M-018";
	public string textString = "";
	public string serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvbkYwbmp3eDZXZUE";




	// Use this for initialization
	void Start () {
		mySubject = PlayerPrefs.GetString ("Subject");
		gradeValue = PlayerPrefs.GetString ("MyGradeValue");
		subjectVale = PlayerPrefs.GetString ("SubjectVale");
		gradeValue = PlayerPrefs.GetString ("MyGradeValue");
		if (mySubject == "English"){
			IconELA.SetActive(true);
			IconMath.SetActive(false);
			IconScience.SetActive(false);
			IconHistory.SetActive(false);
			subjectVale = "e";
			PlayerPrefs.SetString ("SubjectVale", subjectVale);

			return;
		}
		if (mySubject == "Mathematics"){
			IconELA.SetActive(false);
			IconMath.SetActive(true);
			IconScience.SetActive(false);
			IconHistory.SetActive(false);
			subjectVale = "m";
			PlayerPrefs.SetString ("SubjectVale", subjectVale);
			return;
		}
		if (mySubject == "Science"){
			IconELA.SetActive(false);
			IconMath.SetActive(false);
			IconScience.SetActive(true);
			IconHistory.SetActive(false);
			subjectVale = "s";
			PlayerPrefs.SetString ("SubjectVale", subjectVale);
			return;
		}
		if (mySubject == "History"){
			IconELA.SetActive(false);
			IconMath.SetActive(false);
			IconScience.SetActive(false);
			IconHistory.SetActive(true);
			subjectVale = "h";
			PlayerPrefs.SetString ("SubjectVale", subjectVale);
			return;
		}
	}

	public void SelectedK(){
		gradeValue = "k";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "Kindergarden");
//		KM-015.mp4 is the k math clip
//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
//			PlayerPrefs.GetString ("myURL");
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/KM-015.mp4");
			PlayerPrefs.SetString ("LessonTitle","Identifying Shapes");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvSDdXdFB2ZmtXNUE";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/KE-001.mp4");
			PlayerPrefs.SetString ("LessonTitle","Asking and Answering Questions");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvbkYwbmp3eDZXZUE";
		}
		videoBack.SetActive(true);
		mYViewer.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected1(){
		gradeValue = "1";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "1st Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/1M-002.mp4");
			PlayerPrefs.SetString ("LessonTitle","Word Problems with Addition");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvdmVtWERqdldOdkE";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/1E-016.mp4");
			PlayerPrefs.SetString ("LessonTitle","Fluency and Understanding");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvZzE5ODk2RC1hZ1E";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected2(){
		gradeValue = "2";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "2nd Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/2M-015.mp4");
			PlayerPrefs.SetString ("LessonTitle","Money");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvMWNoTmtqTWZQbUU";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/2E-003.mp4");
			PlayerPrefs.SetString ("LessonTitle","Characters");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvOE5GUW92X0ZFaTA";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected3(){
		gradeValue = "3";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "3rd Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/3M-012.mp4");
			PlayerPrefs.SetString ("LessonTitle","Fractions");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvSjNyVDlBelJQQXM";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/3E-011.mp4");
			PlayerPrefs.SetString ("LessonTitle","Compare and Contrast");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvNlEydUVtOG1jZW8";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected4(){
		gradeValue = "4";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "4th Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/4M-025.mp4");
			PlayerPrefs.SetString ("LessonTitle","Angle Measurement");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvRWZsUUhPbENjWG8";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/4E-002.mp4");
			PlayerPrefs.SetString ("LessonTitle","Summarizing Text and Theme");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvYTFobTgtVXVrQjQ";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected5(){
		gradeValue = "5";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "5th Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/5M-018.mp4");
			PlayerPrefs.SetString ("LessonTitle","Volume");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvbER4RHVZQ2FoTVU";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/5E-030.mp4");
			PlayerPrefs.SetString ("LessonTitle","Multiple Meaning Words");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvb3pYUlJTYmdiSFE";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected6(){
		gradeValue = "6";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "6th Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/6M-021.mp4");
			PlayerPrefs.SetString ("LessonTitle","Coordinate Geometry");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvTHMycFVxZ1phUEU";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/6E-003.mp4");
			PlayerPrefs.SetString ("LessonTitle","Theme and Summary");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvQjQybnNieEpJbXc";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected7(){
		gradeValue = "7";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "7th Grade");

		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/7M-005.mp4");
			PlayerPrefs.SetString ("LessonTitle","Properties of Addition and Subtraction");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvdGZLQ2R0aG1zU0k";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/7E-003.mp4");
			PlayerPrefs.SetString ("LessonTitle","Characterization,Development of Plot and Setting");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvV1NVNFFPUUJCUUk";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
	public void Selected8(){
		gradeValue = "8";
		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
		PlayerPrefs.SetString ("GradeTitle", "8th Grade");
		//		KM-015.mp4 is the k math clip
		//		KE-001.mp4 is the K Ela clip
		if (mySubject == "Mathematics") {
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/8M-007.mp4");
			PlayerPrefs.SetString ("LessonTitle","Solving Linear Equations");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvR09ySTVxQXYyOUU";
		}
		if (mySubject == "English"){
			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/8E-005.mp4");
			PlayerPrefs.SetString ("LessonTitle","Comparison and Contrast");
			serverUrl  = "https://drive.google.com/open?id=0B3XuftRGDxOvWjMzZ1BGN3c4U2M";
		}
		mYViewer.SetActive(true);
		videoBack.SetActive(true);
		Browser.SetActive(false);
		return;
	}
//	public void Selected9(){
//		gradeValue = "9";
//		PlayerPrefs.SetString ("MyGradeValue",gradeValue);
//		//		KM-015.mp4 is the k math clip
//		//		KE-001.mp4 is the K Ela clip
//		if (mySubject == "Mathematics") {
//			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/KM-015.mp4");
//		}
//		if (mySubject == "English"){
//			PlayerPrefs.SetString ("myURL", "http://markgrob.com/CARE/streamedmedia/lite/KE-001.mp4");
//		}
//		mYViewer.SetActive(true);
//		Browser.SetActive(false);
//		return;
//	}

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

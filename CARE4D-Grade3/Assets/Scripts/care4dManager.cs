using UnityEngine;
using System.Collections;

public class care4dManager : MonoBehaviour {
	public void LoginScreenActive(){
		Application.LoadLevel("LoginScreenActive");
	}
	public void Content_menu1Active(){
		Application.LoadLevel("Content_menu1Active");
	}
	public void WorksheeScannerActive(){
		Application.LoadLevel("WorksheeScannerActive");
	}
	public void CurriculumSamplesActive(){
		Application.LoadLevel("CurriculumSamplesActive");
	}
	public void CurriculumTopicBrowserActive(){
		Application.LoadLevel("CurriculumTopicBrowserActive");
	}
	public void VideoBrowserActive(){
		Application.LoadLevel("videobrowserActive");
	}
	public void ScienceLabActive(){
		Application.LoadLevel("ScienceLabActive");
	}
	public void SolarSystemActive(){
		Application.LoadLevel("SolarSystemActive");
	}
	public void SubjectEnglish(){
		PlayerPrefs.SetString ("Subject", "English");
	}
	public void SubjectMath(){
		PlayerPrefs.SetString ("Subject", "Mathematics");
	}
	public void SubjectScience(){
		PlayerPrefs.SetString ("Subject", "Science");
	}
	public void SubjectHistory(){
		PlayerPrefs.SetString ("Subject", "History");
	}

	public void DemoCurriculumTopicBrowserActive(){
		Application.LoadLevel("DemoCurriculumTopicBrowserActive");
	}
	public void DemoScienceLabActive(){
		Application.LoadLevel("DemoScienceLabActive");
	}
	public void DemoSolarSystemActive(){
		Application.LoadLevel ("DemoSolarSystemActive");
	}
	public void DemoCurriculumSamplesActive(){
			Application.LoadLevel("DemoCurriculumSamplesActive");
	}
	public void DemoWorksheeScannerActive(){
		Application.LoadLevel("DemoWorksheeScannerActive");
	}

	public void DemoContentMenu(){
		Application.LoadLevel("ContentMenuDemo");
	}
}
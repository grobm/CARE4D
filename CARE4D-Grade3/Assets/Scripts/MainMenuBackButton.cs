using UnityEngine;
using System.Collections;

public class MainMenuBackButton : MonoBehaviour {
	public GameObject MainMenu;
	public GameObject ARMenu;
	public GameObject Top;
	public GameObject GetTargets;
	public GameObject Instructions;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetTargets.activeSelf) {
			if (Input.GetKeyDown ("escape")) {
				MainMenu.gameObject.SetActive (true);
				ARMenu.gameObject.SetActive (false);
				Top.gameObject.SetActive (true);
				GetTargets.gameObject.SetActive (false);
			}
		}else if (Instructions.activeSelf) {
			if (Input.GetKeyDown ("escape")) {
				MainMenu.gameObject.SetActive (true);
				ARMenu.gameObject.SetActive (false);
				Top.gameObject.SetActive (true);
				GetTargets.gameObject.SetActive (false);
				Instructions.gameObject.SetActive (false);
			}
		}else if (ARMenu.activeSelf) {
			if (Input.GetKeyDown ("escape")) {
				MainMenu.gameObject.SetActive (true);
				ARMenu.gameObject.SetActive (false);
				Top.gameObject.SetActive (true);
				GetTargets.gameObject.SetActive (false);
				Instructions.gameObject.SetActive (false);
			}
		}
	}
}

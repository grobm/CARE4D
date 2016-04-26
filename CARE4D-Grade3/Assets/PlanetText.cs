using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetText : MonoBehaviour {
	Text score;
	public GameObject Panel;
	// Update is called once per frame
	void Update () {
		score = GetComponent<Text>();
		score.text =PlayerPrefs.GetString ("PlanetText");
		if (score.text == "") {
			Panel.SetActive (false);
		} else {
			Panel.SetActive (true);
		}
	}
}

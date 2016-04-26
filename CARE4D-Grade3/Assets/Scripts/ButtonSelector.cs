using UnityEngine;
using System.Collections;

public class ButtonSelector : MonoBehaviour {

	GameObject[] buttons;
	GameObject selectedButton;

	void Start () 
	{
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		ClearColors ();
		selectedButton = null;
		Renderer r = selectedButton.GetComponent<Renderer> ();
		Renderer q = buttons[0].GetComponent<Renderer> ();
		q.material.color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
		//r.material.color = new Color (0.1f, 0.95f, 0.2f, 0.8f);
	}

	void ClearColors()
	{
		for (int i = 0; i < buttons.Length; i++) {
			Renderer r = buttons[i].GetComponent<Renderer> ();
			r.material.color = new Color (0.05f, 0.05f, 0.5f, 0.75f);
			buttons[i].GetComponent<SelectOnClick>().complete = false;
		}
	}

	public void SetSelected(GameObject button)
	{
		selectedButton = button;
		ClearColors ();
		
		Renderer r = selectedButton.GetComponent<Renderer> ();
		r.material.color = new Color (0.5f, 0.5f, 0.5f, 0.75f);
	}
}
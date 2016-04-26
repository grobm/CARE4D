using UnityEngine;
using System.Collections;

public class ZoomOnClick : MonoBehaviour {
	public string text;
	public float zoomSpeed = 1000f;
	public float zoomIn = 50;
	public GameObject PlanetsPanel;

	SphereCollider cldr;

//	GameObject textObj/;
//	TextMesh textMesh;
//	GameObject textPlane;
	
	Camera arCam;
	Camera zoomCam;

	bool startZoom;
	bool following;

	float timeScale = 1f;
	float panvalue = 1f;
	//The sun is a star, a hot ball of glowing gases at the heart of our solar system.
	//The sun is a star, a hot ball of glowing gases at the heart of our solar system.
	//Neptune is the eight|h| planet from the Sun| |and has 14 known moons.

	// Use this for initialization
	void Start () 
	{
		arCam = Camera.main;
		zoomCam = GameObject.Find("ZoomCam").GetComponent<Camera>();

		cldr = gameObject.AddComponent<SphereCollider>();
		cldr.radius = 0.0025f * gameObject.GetComponent<MeshRenderer>().bounds.size.x;
		
		PlayerPrefs.SetString ("PlanetText", "");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(following) {
			PlayerPrefs.SetString ("PlanetText", text);
			zoomCam.transform.LookAt(transform);
			if(zoomCam.transform.localPosition.z <= 0.1f) {
				zoomCam.transform.position += transform.forward;
			
			}

			if(Input.GetMouseButtonDown(0) ) {
				PlayerPrefs.SetString ("PlanetText", "");

				following = false;
				startZoom = false;
				arCam.enabled = true;
				zoomCam.enabled = false;
				PlanetsPanel.hideFlags = HideFlags.None;
//				PlanetName.render (false);
//				PlanetDescription.render (false);
//				textObj.SetActive(false);
				Time.timeScale = 1f;
			}
		}
		if(startZoom) {
			if(Vector3.Distance(zoomCam.transform.position, transform.position) >= zoomIn)
			{
				zoomCam.transform.LookAt(transform);
				zoomCam.transform.position += zoomCam.transform.forward * Time.deltaTime * zoomSpeed;
			}
			else { 
				zoomCam.transform.SetParent(transform); 
				startZoom = false;
				following = true;
				Time.timeScale = 0.4f;
				panvalue= Input.acceleration.x;
//				zoomCam.transform.localEulerAngles.x = panvalue;
			}
		}
	}

	void OnMouseDown() {
		if(following) {
			following = false;
			arCam.enabled = true;
			zoomCam.enabled = false;
			PlanetsPanel.hideFlags = HideFlags.HideInHierarchy;
//			textObj.SetActive(false);
			Time.timeScale = 1f;
		}

		else if(!startZoom) {
			zoomCam.transform.position = arCam.transform.position;
//			arCam.enabled = true;
//			zoomCam.enabled = true;
//			textObj.SetActive(true);
			arCam.enabled = false;
			zoomCam.enabled = true;
			startZoom = true;
//			PlanetsPanel.render (true);
//			PlanetName.render (true);
//			PlanetDescription.render (true);

		}
	}

}

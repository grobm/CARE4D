// This example loads an OBJ file from the WWW, including the MTL file and any textures that might be referenced

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjLoader : MonoBehaviour {
	
	string objDir = "http://24.185.63.184:7777/objs/";
	public Material standardMaterial;	// Used if the OBJ file has no MTL file
	ObjReader.ObjData objData;
	string loadingText = "";
	public bool loading = false;
	string[] objList;

	public GameObject[] GetObj() {
		return objData.gameObjects;
	}

	void Init() {
		objList = new string[255];
		StartCoroutine(LoadList ());
	}

	public void LoadObject(string objName) {
	}

	public IEnumerator Load (string objName) {
		loading = true;
		if (objData != null && objData.gameObjects != null) {
			for (var i = 1; i < objData.gameObjects.Length; i++) {
				Destroy (objData.gameObjects[i]);
			}
		}

		string objFileName = objDir + "/" + objName + ".obj";
		objData = ObjReader.use.ConvertFileAsync (objFileName, true, standardMaterial);

		while (!objData.isDone) {
			loadingText = "Loading... " + (objData.progress*100).ToString("f0") + "%";
			if (Input.GetKeyDown (KeyCode.Escape)) {
				objData.Cancel();
				loadingText = "Cancelled download";
				loading = false;
				yield break;
			}
			yield return null;
		}
		loading = false;
		if (objData == null || objData.gameObjects == null) {
			loadingText = "Error loading file";
			yield return null;
			yield break;
		}
		
		loadingText = "Import completed";
		//AlignToCamera();
	}

	IEnumerator LoadList() {
		
		string host = "http://24.185.63.184:7777";
		WWW www = new WWW(System.Uri.EscapeUriString(host + "/objs/objlist"));
		yield return www;
		string linkTable = www.text;
		objList = linkTable.Split ("\n"[0]);
		Debug.Log (" LOADED LIST: " + objList[0]);
	}

	/*
	void FocusOnObjects () {
		var cam = Camera.main;
		var bounds = new Bounds(objData.gameObjects[0].transform.position, Vector3.zero);
		for (var i = 0; i < objData.gameObjects.Length; i++) {
			bounds.Encapsulate (objData.gameObjects[i].GetComponent<Renderer>().bounds);
		}
		
		var maxSize = bounds.size;
		var radius = maxSize.magnitude / 2.0f;
		var horizontalFOV = 2.0f * Mathf.Atan (Mathf.Tan (cam.fieldOfView * Mathf.Deg2Rad / 2.0f) * cam.aspect) * Mathf.Rad2Deg;
		var fov = Mathf.Min (cam.fieldOfView, horizontalFOV);
		var distance = radius / Mathf.Sin (fov * Mathf.Deg2Rad / 2.0f);
		
		cam.transform.position = bounds.center;
		cam.transform.Translate (-Vector3.forward * distance);
		cam.transform.LookAt (bounds.center);
	}*/

	public string[] GetList() {
		if (objList == null)
			StartCoroutine (LoadList ());
		return objList;
	}

}
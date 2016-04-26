using UnityEngine;
using System.Collections;

public class ModifyTexture : MonoBehaviour {

    private Material newMaterial;
	// Use this for initialization
	void Start ()
    {
        newMaterial = new Material(gameObject.GetComponent<Renderer>().material);
        newMaterial.mainTexture = Resources.Load<Texture>("CAREVideoThumbs/Evan");
        Debug.Log(Resources.Load<Texture>("CAREVideoThumbs/Evan"));
        gameObject.GetComponent<Renderer>().material = newMaterial;
    }

}

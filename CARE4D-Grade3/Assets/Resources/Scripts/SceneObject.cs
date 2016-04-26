using UnityEngine;
using System.Collections;

public class SceneObject : MonoBehaviour
{
    public bool initialScene;
	// Use this for initialization
	void Awake()
    {
        SceneManager.RegisterIngameScene(this);
	}
	
}

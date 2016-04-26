using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
    public GameObject[] sceneObjects;
		
	void Start()
    {
        DisableAllScenes();
    }

    void DisableAllScenes()
    {
        foreach (GameObject gScene in sceneObjects)
        {
            gScene.SetActive(false);
        }
    }   

    public void ActivateScene(string name)
    {
        bool didSceneActivate = false;
        foreach (GameObject scene in sceneObjects)
            if (scene.name == name && !didSceneActivate)
            {
                scene.SetActive(true);
                didSceneActivate = true;
            }
            else if (scene.name == name && didSceneActivate)
            {
                Debug.Log("There is a duplicate Scene active - setting recurring scene to false. " + scene.name);
                scene.SetActive(false);
            }
            else
                scene.SetActive(false);
    }

    public void ActivateScene(GameObject sceneObject)
    {
        ActivateScene(sceneObject.name);
    }
}

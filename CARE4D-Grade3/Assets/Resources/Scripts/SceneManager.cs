using UnityEngine;
using System.Collections.Generic;

public static class SceneManager{

    public static Dictionary<string,SceneObject> InGameScenes
    {
        get
        {
            if (_inGameScenes == null)
                _inGameScenes = new Dictionary<string, SceneObject>();
            return _inGameScenes;
        }
    }
    private static Dictionary<string, SceneObject> _inGameScenes;

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void RegisterIngameScene(SceneObject scene)
    {
        InGameScenes[scene.name] = scene;
    }

    public static void LoadIngameScene(string sceneName)
    {
        if (InGameScenes.ContainsKey(sceneName))
        {
            DisableAllScenes();
            SetSceneState(sceneName, true);
        }
        else
        {
            Debug.Log("Scene Does not contain " + sceneName);
        }
        
    }

    static void SetSceneState(string scene, bool sceneState)
    {
        InGameScenes[scene].gameObject.SetActive(sceneState);
    }

    static void DisableAllScenes()
    {
        foreach(string s in InGameScenes.Keys)
        {
            SetSceneState(s,false);
        }
    }

    public static void InitializeDefaultScene()
    {
        bool defaultSceneSet = false;
        if (InGameScenes.Count > 0)
        {
            foreach (string s in InGameScenes.Keys)
            {
                if (InGameScenes[s].initialScene && !defaultSceneSet)
                {
                    SetSceneState(s, true);
                    defaultSceneSet = true;
                }
                else
                    SetSceneState(s, false);
            }
        }
    }

}

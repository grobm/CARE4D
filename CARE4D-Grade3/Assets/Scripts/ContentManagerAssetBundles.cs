/*==============================================================================
Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
==============================================================================*/
using UnityEngine;
using System.Collections;
using Vuforia;
using AssetBundles;

/// <summary>
/// This class manages the content displayed on top of cloud reco targets in this sample
/// </summary>
public class ContentManagerAssetBundles : MonoBehaviour, ITrackableEventHandler
{
    #region PUBLIC_MEMBERS
    /// <summary>
    /// The root gameobject that serves as an augmentation for the image targets created by search results
    /// </summary>
    public TrackableBehaviour TrackableTarget;
    //public LoadVuphoriaScene loadSceneBundleManager;
    public GameObject AugmentationObject;
    public string sceneAssetBundle;
    public string sceneName;
    public int Version;
    public string bundleURL = "http://augmentourworld.org/care4d/AssetBundles/Android/";
    private GameObject mBundleInstance = null;
    private bool mAttached = false;

    #endregion //PUBLIC_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    IEnumerator Start ()
    {
        TrackableBehaviour trackableBehaviour = TrackableTarget;//AugmentationObject.transform.parent.GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
        yield return StartCoroutine(Initialize());
        yield return StartCoroutine(InitializeLevelAsync(sceneAssetBundle, sceneName, true));
        //ShowObject(false);
    }

    #endregion MONOBEHAVIOUR_METHODS
       
    #region PUBLIC_METHODS
    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            
            //ShowObject(true);
        }
        else
        {
            //ShowObject(false);
        }
        //StartCoroutine(AttachObject());
        
    }
   
    public void ShowObject(bool tf)
    {
        Renderer[] rendererComponents = AugmentationObject.GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = AugmentationObject.GetComponentsInChildren<Collider>();

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = tf;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = tf;
        }
    }
    #endregion //PUBLIC_METHODS

    #region IEnumerators
    // Update is called once per frame
    IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;
        // example URL of file on PC filesystem (Windows)
        // string bundleURL = "file:///D:/Unity/AssetBundles/MyAssetBundle.unity3d";
        // example URL of file on Android device SD-card
        //string bundleURL = "file:///mnt/sdcard/AndroidCube.unity3d";

        using (WWW www = WWW.LoadFromCacheOrDownload(bundleURL, Version))
        {
            yield return www;
            if (www.error != null)
                throw new UnityException("WWW Download had an error: " + www.error);
            AssetBundle bundle = www.assetBundle;
            if (sceneName == "")
            {
                //mBundleInstance = Instantiate(bundle.mainAsset) as GameObject;
            }
            else {
                //mBundleInstance = Instantiate(bundle.Load(AssetName)) as GameObject;
            }
        }
    }

    IEnumerator AttachObject()
    {
        yield return StartCoroutine(DownloadAndCache());
        if (!mAttached && mBundleInstance)
        {
            // if bundle has been loaded, let's attach it to this trackable
            mBundleInstance.transform.parent = this.transform;
            mBundleInstance.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            mBundleInstance.transform.localPosition = new Vector3(0.0f, 0.15f, 0.0f);
            mBundleInstance.transform.gameObject.SetActive(true);
            mAttached = true;
        }
    }


    public IEnumerator LoadScene(string sceneAssetBundle, string sceneName)
    {
        yield return StartCoroutine(InitializeLevelAsync(sceneAssetBundle, sceneName, true));
    }

    // Initialize the downloading url and AssetBundleManifest object.
    protected IEnumerator Initialize()
    {
        // Don't destroy this gameObject as we depend on it to run the loading script.
        DontDestroyOnLoad(gameObject);

        // With this code, when in-editor or using a development builds: Always use the AssetBundle Server
        // (This is very dependent on the production workflow of the project. 
        // 	Another approach would be to make this configurable in the standalone player.)
#if DEVELOPMENT_BUILD || UNITY_EDITOR
        AssetBundleManager.SetDevelopmentAssetBundleServer();
#else
		// Use the following code if AssetBundles are embedded in the project for example via StreamingAssets folder etc:
		//AssetBundleManager.SetSourceAssetBundleURL(Application.dataPath + "/");
		// Or customize the URL based on your deployment or configuration
		AssetBundleManager.SetSourceAssetBundleURL("bundleURL");
#endif

        // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
        var request = AssetBundleManager.Initialize();

        if (request != null)
            yield return StartCoroutine(request);
    }

    protected IEnumerator InitializeLevelAsync(string sceneAssetBundle, string levelName, bool isAdditive)
    {
        // This is simply to get the elapsed time for this phase of AssetLoading.
        float startTime = Time.realtimeSinceStartup;

        // Load level from assetBundle.
        AssetBundleLoadOperation request = AssetBundleManager.LoadLevelAsync(sceneAssetBundle, levelName, isAdditive);
        if (request == null)
            yield break;
        yield return StartCoroutine(request);

        // Calculate and display the elapsed time.
        float elapsedTime = Time.realtimeSinceStartup - startTime;
        Debug.Log("Finished loading scene " + levelName + " in " + elapsedTime + " seconds");
    }
    #endregion //IEnumerators
}

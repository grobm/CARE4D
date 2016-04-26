using UnityEngine;
using System.Collections;
using Vuforia;

public class AssetBundleAugmenter : MonoBehaviour, ITrackableEventHandler
{
    public string AssetName;
    public int Version;
    public string bundleURL = "http://augmentourworld.org/care4d/AssetBundles/Android/";
    private GameObject mBundleInstance = null;
    private TrackableBehaviour mTrackableBehaviour;
    private bool mAttached = false;
    void Start()
    {
        StartCoroutine(DownloadAndCache());
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
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
            if (AssetName == "")
            {
                //mBundleInstance = Instantiate(bundle.mainAsset) as GameObject;
            }
            else {
                //mBundleInstance = Instantiate(bundle.Load(AssetName)) as GameObject;
            }
        }
    }
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
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
    }
}

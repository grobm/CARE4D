/*==============================================================================
Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
==============================================================================*/
using UnityEngine;
using System.Collections;
using Vuforia;

/// <summary>
/// This class manages the content displayed on top of cloud reco targets in this sample
/// </summary>
public class ContentManager : MonoBehaviour, ITrackableEventHandler
{
    #region PUBLIC_MEMBERS
    /// <summary>
    /// The root gameobject that serves as an augmentation for the image targets created by search results
    /// </summary>
    public GameObject AugmentationObject;
//	public GameObject ScanUI;
	public UnityEngine.UI.Text errorText;
//	public VideoPlaybackBehaviour VideoPlayback;
	public MediaPlayerCtrl Video;
    #endregion //PUBLIC_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start ()
    {
        TrackableBehaviour trackableBehaviour = AugmentationObject.transform.parent.GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
        
        ShowObject(false);
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
            ShowObject(true);
        }
        else
        {
            ShowObject(false);
        }
    }

    public void ShowObject(bool tf)
    {
		Canvas[] canvasComponents = AugmentationObject.GetComponentsInChildren<Canvas>();
//		Canvas[] ScanUIComponents = ScanUI.GetComponentsInChildren<Canvas>();
		Renderer[] rendererComponents = AugmentationObject.GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = AugmentationObject.GetComponentsInChildren<Collider>();
		MediaPlayerCtrl[] videoplayerComponents = AugmentationObject.GetComponentsInChildren<MediaPlayerCtrl>();

//		PlayerPrefs.GetString ("myURL");
		Debug.Log("myURL dump in CM: "+ PlayerPrefs.GetString ("myURL"));
		errorText.text = "myURL dump in CM: " + PlayerPrefs.GetString ("myURL");
		Video.m_strFileName = PlayerPrefs.GetString ("myURL");
		if (Video.m_strFileName == null) {
			Video.m_strFileName = "http://markgrob.com/CARE/streamedmedia/lite/1E-001.mp4";
		}



//		canvasComponents
		// Enable canvas:
		foreach (Canvas component in canvasComponents)
		{
			component.enabled = tf;
		}
//		foreach (Canvas component in ScanUIComponents)
//		{
//			component.enabled = tf;
//		}
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
		// Enable colliders:
		foreach (MediaPlayerCtrl component in videoplayerComponents)
		{
			component.enabled = tf;
		}
    }
    #endregion //PUBLIC_METHODS
}

/*===============================================================================
Copyright (c) 2015-2016 PTC Inc. All Rights Reserved.
 
Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;

/// <summary>
/// The VideoPlaybackBehaviour manages the appearance of a video that can be superimposed on a target.
/// Playback controls are shown on top of it to control the video. 
/// </summary>
public class VideoPlaybackIcon : MonoBehaviour
{
    #region PUBLIC_MEMBER_VARIABLES

    /// <summary>
    /// URL of the video, either a path to a local file or a remote address
    /// </summary>
    public string m_path = null;

    /// <summary>
    /// Texture for the play icon
    /// </summary>
    public Texture m_playTexture = null;

    /// <summary>
    /// Texture for the busy icon
    /// </summary>
    public Texture m_busyTexture = null;

    /// <summary>
    /// Texture for the error icon
    /// </summary>
    public Texture m_errorTexture = null;

    /// <summary>
    /// Prefab for the Fullscreen Video
    /// </summary>
    public CameraManager cameraManager = null;

    #endregion // PUBLIC_MEMBER_VARIABLES



    #region PRIVATE_MEMBER_VARIABLES
    [SerializeField]
    [HideInInspector]
    private Texture mKeyframeTexture = null;
    private Material mKeyframeMaterial = null;
    public GameObject mIconPlane = null;
    private bool mIconPlaneActive = false;

    #endregion // PRIVATE_MEMBER_VARIABLES



    #region PROPERTIES
    /// <summary>
    /// Texture displayed before video playback begins
    /// </summary>
    public Texture KeyframeTexture
    {
        get { return mKeyframeTexture; }
        set { mKeyframeTexture = value; }
    }
    #endregion // PROPERTIES



    #region UNITY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        InitializeState();
    }

    void InitializeState()
    {
        // Find the icon plane (child of this object)
        //mIconPlane = transform.Find("Icon").gameObject;
        mKeyframeMaterial = gameObject.GetComponent<Renderer>().material;
        // Flip the plane as the video texture is mirrored on the horizontal
        //transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x),
                //transform.localScale.y, transform.localScale.z);

        // Scale the icon
        //ScaleIcon();
    }


    void CheckPlaneVisibillty()
    {
        CheckIconPlaneVisibility();
    }
    #endregion // UNITY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS
    public void InitializeVideoThumbnail(Texture texture)
    {        
        if (texture != null)
        {
            SetKeyframeTexture(texture);
        }
        else
        {
            ErrorText.instance.AddErrorText("No valid texture data available");
        }
    }

    public void PlayVideo()
    {
		m_path = PlayerPrefs.GetString ("myURL");
		Debug.Log("Playing Video");
//		Handheld.PlayFullScreenMovie (m_path);
	//	Handheld.PlayFullScreenMovie (m_path, FullScreenMovieControlMode.Full);
		Handheld.PlayFullScreenMovie (m_path, Color.black, FullScreenMovieControlMode.Full);
//		Screen.autorotateToLandscapeLeft = true;
//        cameraManager.ActivateFullscreenVideo();
//		cameraManager.scrMedia.Load(m_path);
//        cameraManager.scrMedia.Play();
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    /// <summary>
    /// Displays the busy icon on top of the video
    /// </summary>
    private void ShowBusyIcon()
    {
        mIconPlane.GetComponent<Renderer>().material.mainTexture = m_busyTexture;
    }

    private void ShowPlayIcon()
    {
        mIconPlane.GetComponent<Renderer>().material.mainTexture = m_playTexture;
    }

    private void SetKeyframeTexture(Texture keyframe)
    {
        KeyframeTexture = keyframe;
    }

    private void ShowKeyframeTexture()
    {
        if (KeyframeTexture != null)
            mKeyframeMaterial.mainTexture = KeyframeTexture;
        else
            ErrorText.instance.AddErrorText("No keyframe Texture has been set");
    }

    private IEnumerator ResetToPortraitSmoothly()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;

        // We need to reset screen orientation to portrait, 
        // so, first we set it temporarily to landscape
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        // we wait for end of frame
        yield return new WaitForEndOfFrame();

        // we wait for about half a second to be sure the 
        // screen orientation has switched from portrait to landscape
        yield return new WaitForSeconds(0.8f);

        // then finally we reset to Portrait
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void ScaleIcon()
    {
        // Icon should fill 50% of the narrowest side of the video

        float videoWidth = Mathf.Abs(transform.localScale.x);
        float videoHeight = Mathf.Abs(transform.localScale.z);
        float iconWidth, iconHeight;

        if (videoWidth > videoHeight)
        {
            iconWidth = 0.5f * videoHeight / videoWidth;
            iconHeight = 0.5f;
        }
        else
        {
            iconWidth = 0.5f;
            iconHeight = 0.5f * videoWidth / videoHeight;
        }

        mIconPlane.transform.localScale = new Vector3(-iconWidth, 1.0f, iconHeight);
    }


    private void CheckIconPlaneVisibility()
    {
        // If the video object renderer is currently enabled, we might need to toggle the icon plane visibility
        if (GetComponent<Renderer>().enabled)
        {
            // Check if the icon plane renderer has to be disabled explicitly in case it was enabled by another script (e.g. TrackableEventHandler)
            Renderer rendererComp = mIconPlane.GetComponent<Renderer>();
            if (rendererComp.enabled != mIconPlaneActive)
                rendererComp.enabled = mIconPlaneActive;
        }
    }

    #endregion // PRIVATE_METHODS

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayVideo();
        }
    }
}

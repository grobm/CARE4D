using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject VideoPlayer;
	public GameObject ScanUI;
    public GameObject StartingActiveObject;

    public MediaPlayerCtrl scrMedia;

    void Start()
    {
        if (StartingActiveObject != null)
            if (StartingActiveObject == arCamera)
                ActivateARCamera();
            else
                ActivateFullscreenVideo();
    }

	public void ActivateARCamera()
    {
        VideoPlayer.SetActive(false);
        arCamera.SetActive(true);
		ScanUI.SetActive(true);

    }

    public void ActivateFullscreenVideo()
    {
        VideoPlayer.SetActive(true);
        arCamera.SetActive(false);
		ScanUI.SetActive(false);
    }
}

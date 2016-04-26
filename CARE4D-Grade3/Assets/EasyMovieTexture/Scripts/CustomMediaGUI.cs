using UnityEngine;
using System.Collections;

public class CustomMediaGUI : MonoBehaviour
{
    public MediaPlayerCtrl scrMedia;
    public CameraManager cameraManager;

    public bool m_bFinish = false;
    // Use this for initialization
    void Start()
    {
        scrMedia.OnEnd += OnEnd;
    }

    public void Load(string url)
    {
		scrMedia.Load(url);
        m_bFinish = false;
    }

    public void Stop()
    {
        scrMedia.Stop();
    }

    public void Pause()
    {
        scrMedia.Pause();
    }
    
    public void Unload()
    { 
        scrMedia.UnLoad();
    }

    public void SeekTo(int iPosition)
    { 
        scrMedia.SeekTo(iPosition);
    }

    public void Exit()
    {
        Stop();
        Unload();
        cameraManager.ActivateARCamera();
    }

    void OnEnd()
    {
        m_bFinish = true;
        Exit();
    }
}
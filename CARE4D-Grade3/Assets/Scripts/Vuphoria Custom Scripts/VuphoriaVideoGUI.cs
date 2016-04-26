using UnityEngine;
using System.Collections;

public class VuphoriaVideoGUI : MonoBehaviour {

    public MediaPlayerCtrl scrMedia;
    public string videoURL;
    public bool m_bFinish = false;

    // Use this for initialization
    void Start()
    {
        scrMedia.OnEnd += OnEnd;
    }

    public void Load()
    {
        scrMedia.Load(videoURL);
        m_bFinish = false;
    }

    public void Play()
    {
        scrMedia.Play();
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

    public void UnLoad()
    {
        scrMedia.UnLoad();
    }

    void OnGUI()
    {
        /*
        if (scrMedia.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
        {
            if (GUI.Button(new Rect(200, 200, 100, 100), scrMedia.GetSeekPosition().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 350, 100, 100), scrMedia.GetDuration().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 450, 100, 100), scrMedia.GetVideoWidth().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 550, 100, 100), scrMedia.GetVideoHeight().ToString()))
            {

            }
        }

        if (GUI.Button(new Rect(200, 650, 100, 100), scrMedia.GetCurrentSeekPercent().ToString()))
        {

        }
        */

    }



    void OnEnd()
    {
        m_bFinish = true;
    }
}

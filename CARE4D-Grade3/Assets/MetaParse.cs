using UnityEngine;
using System.Collections;

public class MetaParse : MonoBehaviour {
    public MediaPlayerCtrl mediaController;

	public void ParseMeta(string metaData)
    {
        string[] keyValue = metaData.Split(':');
        if (keyValue.Length < 2) Debug.Log("There was an issue parsing the meta data. no ':' found to split. ParseMeta(string "+metaData+")");
        else
        {
            switch (keyValue[0])
            {
                case "url":
                    PlayURLVideo(keyValue[1]);
                break;
            }
        }
    }

    public void PlayURLVideo(string url)
    {
        mediaController.Load(url);
    }
}

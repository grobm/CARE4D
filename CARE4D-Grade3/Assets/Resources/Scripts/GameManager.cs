using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public void LoadScene(GameObject objectName)
    {
        SceneManager.LoadScene(objectName.name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}

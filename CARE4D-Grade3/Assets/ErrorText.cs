using UnityEngine;
using System.Collections;

public class ErrorText : MonoBehaviour {

    public static ErrorText instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<ErrorText>();
            }
            return _instance;
        }
    }
    private static ErrorText _instance;
    public UnityEngine.UI.Text errorText;

    public void ClearErrorText()
    {
        errorText.text = "";
    }

    public void AddErrorText(string text)
    {
        errorText.text += text + "\n";
    }
}

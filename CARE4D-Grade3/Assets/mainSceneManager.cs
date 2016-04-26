using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class mainSceneManager : MonoBehaviour
{
//    public String[] gradelevels;
//    public UnityEngine.UI.Dropdown gradeDropdown;
    public UnityEngine.UI.InputField usernameField;
    public UnityEngine.UI.InputField passwordField;

    void Start ()
    {
        SetPasswordField();
        SceneManager.InitializeDefaultScene();
        StartCoroutine(CheckDeviceRegistered());
    }

    void SetPasswordField()
    {
        passwordField.inputType = UnityEngine.UI.InputField.InputType.Password;
        passwordField.asteriskChar = '*';
    }

    private bool touchEnabled = true;
    void ToggleTouch(bool btouch)
    {
        touchEnabled = btouch;
    }

//    void ApplyGradeToDropdownList()
//    {
//        gradeDropdown.ClearOptions();
//        List<string> options = new List<string>();
//        foreach (string grade in gradelevels)
//            options.Add(grade);
//        gradeDropdown.AddOptions(options);
//    }

    String[] ParseGradeResults(string rawData)
    {
        return rawData.Split(',');
    }

    //In-Game UI Functions main scene
    public void CheckLoginDetails()
    {
        if (usernameField.text != "" && passwordField.text != "")
            StartCoroutine(CheckLogin(usernameField.text, passwordField.text));
        else
            ColorRequiredFields();
    }

    void ColorRequiredFields()
    {
        if (usernameField.text == "")
            usernameField.placeholder.GetComponent<UnityEngine.UI.Text>().text = "Please fill this in";
        if (passwordField.text == "")
            passwordField.placeholder.GetComponent<UnityEngine.UI.Text>().text = "Please fill this in";
    }

    public void ContinueBTN()
    {
        if (touchEnabled)
            Continue();
    }

    public void Continue()
    {
        StartCoroutine(LoadGradeLevels());
    }

    public void RegisterDevice()
    {
        StartCoroutine(RegisterDeviceToUsername());
    }

    IEnumerator RegisterDeviceToUsername()
    {
        if (touchEnabled)
        {
            ToggleTouch(false);
            CoroutineWithData registerDevice = new CoroutineWithData(this, ServerAccessCalls.RegisterDevice(SystemInfo.deviceUniqueIdentifier, ServerAccessCalls.Username));
            yield return registerDevice.coroutine;
            if ((bool)registerDevice.result)
            {
                Debug.Log("Registering Device Complete - Results From Server = " + registerDevice.result);
                Continue();
            }
            else
            {
                Debug.Log("Error Registering Device - Loading Grade Scenes");
                Continue();
            }
            ToggleTouch(true);
        }
    }

    IEnumerator CheckDeviceRegistered()
    {
        if (touchEnabled)
        {
            ToggleTouch(false);
            CoroutineWithData checkDeviceRegistered = new CoroutineWithData(this, ServerAccessCalls.CheckDeviceRegistered(SystemInfo.deviceUniqueIdentifier));
            yield return checkDeviceRegistered.coroutine;
            Debug.Log("Deviceid = " + SystemInfo.deviceUniqueIdentifier + " The result from checking deviceRegistered " + ServerAccessCalls.deviceRegistered);
            if (!ServerAccessCalls.deviceRegistered)
            {
                SceneManager.LoadIngameScene("Login_screen");
            }
            else
            {
                CoroutineWithData username = new CoroutineWithData(this, ServerAccessCalls.GetUserName(SystemInfo.deviceUniqueIdentifier));
                yield return username.coroutine;

                //Load Grade Data from server via device ID
                Application.LoadLevel("Content_menu1Active");
                //StartCoroutine(LoadGradeLevels());
            }
            ToggleTouch(true);
        }
    }

    IEnumerator LoadGradeLevels()
    {
        CoroutineWithData gradeLevelInformation = new CoroutineWithData(this, ServerAccessCalls.GetGradeInfo());//SystemInfo.deviceUniqueIdentifier));
        yield return gradeLevelInformation.coroutine;
//        gradelevels = ParseGradeResults(gradeLevelInformation.result.ToString());
//        ApplyGradeToDropdownList();
		Application.LoadLevel("Content_menu1Active");
    }

    IEnumerator CheckLogin(string username, string password)
    {
        if (touchEnabled)
        {
            ToggleTouch(false);
            CoroutineWithData checkUsername = new CoroutineWithData(this, ServerAccessCalls.CheckUserDetails(username, password));
            yield return checkUsername.coroutine;
            if ((string)checkUsername.result == "true")
            {
                SceneManager.LoadIngameScene("RegisterDevice");
            }
            ToggleTouch(true);
        }
    }

    public void LoadVuphoriaLevel()
    {
        ToggleTouch(false);
//        ServerAccessCalls.selectedGradeLevel = gradeDropdown.options[gradeDropdown.value].text;
        SceneManager.LoadScene("gradeloader");
    }

}

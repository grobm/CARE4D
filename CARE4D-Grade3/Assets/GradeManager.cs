using UnityEngine;
using System;
using System.Collections.Generic;

public class GradeManager : MonoBehaviour {
    public Vuforia.VuforiaBehaviour mainBehavior;
    public Vuforia.CloudRecoBehaviour cloudBehavior;

    Dictionary<int,String[]> accessKeys = new Dictionary<int, String[]>();

    // Use this for initialization
    void Awake()
    {
        BuildAcessKeys();
        int gradeselected = Convert.ToInt16(ServerAccessCalls.selectedGradeLevel);
        mainBehavior.SetAppLicenseKey(accessKeys[gradeselected][0]);
        cloudBehavior.SecretKey = accessKeys[gradeselected][1];
        cloudBehavior.AccessKey = accessKeys[gradeselected][2];
	}

    void BuildAcessKeys()
    {
        accessKeys[5] = new String[3] {
            "AaMq76//////AAAAAQuPCLeLIkAdggSnvIc8SmZNBusMuR7VMH+6WKL2MPNE6GBWRqDstOOwwiuLrO+Xx8zdkwPOU+eSyYkegIu3fs8mWwFWSj9LdVvoqQIoRcH/KHQuN3VFXjrFYqj1QSpjstNf3i5Zz69PJ140ben2labRxQan6a2BdEgjZN60YkGl4CLlmmu1jb5pzhJdxjZY0+QadkVHGKw7odeI7CpKAqav3tZeO5dAq5UZasqrwTcUXMNRzZyr86bZcGrQ4TD+zpdnwFpWuDFNnei5w4oRMVGChbmC8EJ9lLsD1PvntO1JQqD5uYu90BWtyvyhc5NX6CR3U7qK2YaDiZbLByoki5F114ZyQAsfNegocVql2dgR",
            "9f01c369cc35eae7fb6d57773e0ac382ec29a6cb",
            "8238c2f3ab1eac816a84a616887e6d1e685dd409"
        };
    }

    public void Exit()
    {
        SceneManager.LoadScene("main");
    }
}

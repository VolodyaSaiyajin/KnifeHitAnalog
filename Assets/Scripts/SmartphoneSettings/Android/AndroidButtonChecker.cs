using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidButtonChecker : MonoBehaviour
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

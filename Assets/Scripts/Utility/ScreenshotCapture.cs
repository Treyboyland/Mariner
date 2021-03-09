using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ScreenshotCapture : MonoBehaviour
{
    string screenshotLocation;

    private void Start()
    {
        screenshotLocation = Application.dataPath + "../Logs";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TakeScreenshot"))
        {
            TakeScreenshot();
        }
    }

    void TakeScreenshot()
    {
        if (!Directory.Exists(screenshotLocation))
        {
            Directory.CreateDirectory(screenshotLocation);
        }

        string filePath = screenshotLocation + "/" + GetFilename();
        ScreenCapture.CaptureScreenshot(filePath);

        Debug.Log("Screenshot saved to \"" + filePath + "\"");
    }

    string GetFilename()
    {
        return "Screenshot " + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".png";
    }
}

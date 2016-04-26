using UnityEngine;
using System.Collections;

public class TakeScreenshot : MonoBehaviour
{ 
	private int screenshotCount = 0;
	private string screenshotFilepath = "";
	// Check for screenshot key each frame
	void Update()
	{
		// take screenshot on touch
		
		if (Input.touches.Length > 1)
		{ 
			string screenshotFilename;
			do
			{
				screenshotCount++;
				screenshotFilename = "screenshot" + screenshotCount + ".png";
				screenshotFilepath = Application.persistentDataPath + "/" + screenshotFilename;
				
			} while (System.IO.File.Exists(screenshotFilename));
			
			// audio.Play();
			
			Application.CaptureScreenshot(screenshotFilename);


		}
	}
}
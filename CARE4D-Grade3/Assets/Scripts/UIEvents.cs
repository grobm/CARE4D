using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class UIEvents : MonoBehaviour {

	public bool hideGUI = false;
	public Texture2D texture;
	public Text console;
	public CanvasGroup ui;
	public Image screenshot;
	public GameObject infopanel;
//	public GameObject PlanetsPanel;
//	public GameObject PlanetName;
//	public GameObject PlanetDescription;


	public void Refresh (){
		//Application.LoadLevel ("Main");
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void Info(){
		if (infopanel.gameObject.activeInHierarchy) {
			infopanel.gameObject.SetActive (false);
		} else {
			infopanel.gameObject.SetActive (true);
		}
		//Application.LoadLevel ("info");
	}

	void RefreshUI(){
		//Application.Quit();
		Application.LoadLevel ("ARBase");
	}

	void launchwebsite(){
		Application.OpenURL ("http://www.afterschoolallstars.org");
	}


	public void CloseApp(){
		Application.Quit();
//		Application.LoadLevel ("Main");
	}
	
	void OnEnable ()
	{
		// call backs
		ScreenshotManager.OnScreenshotTaken += ScreenshotTaken;
		ScreenshotManager.OnScreenshotSaved += ScreenshotSaved;	
		ScreenshotManager.OnImageSaved += ImageSaved;
	}
	
	void OnDisable ()
	{
		ScreenshotManager.OnScreenshotTaken -= ScreenshotTaken;
		ScreenshotManager.OnScreenshotSaved -= ScreenshotSaved;	
		ScreenshotManager.OnImageSaved -= ImageSaved;
	}
	
	public void OnSaveScreenshotPress()
	{
		ScreenshotManager.SaveScreenshot("AR Snapshoots", "CARE 4D", "jpeg");
		if(hideGUI) ui.alpha = 0;
		OnSaveImagePress ();
		
	}
	
	public void OnSaveImagePress()
	{
		ScreenshotManager.SaveImage(texture, "MyImage", "png");
	}
	
	void ScreenshotTaken(Texture2D image)
	{
		console.text += "\nScreenshot has been taken and is now saving...";
		screenshot.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(10.5f, 10.5f));
		screenshot.color = Color.white;	
		ui.alpha = 1;
		OnSaveImagePress ();
	}
	
	void ScreenshotSaved(string path)
	{
		console.text += "\nScreenshot finished saving to " + path;
	}
	
	void ImageSaved(string path)
	{
		console.text += "\n" + texture.name + " finished saving to " + path;
	}

	void Snapshot(){
		Application.CaptureScreenshot("CARE4D.png"); 
		ScreenshotManager.SaveScreenshot ( "ScreenshotName", "CARE4D");
//		string cliplabel;
//		ui.alpha = 1;
//		cliplabel = "CARE4D.png";// LocationInfo.timestamp + ".png";  <--- add timestamp here later
//		Application.CaptureScreenshot("Assets/savedmeshes/assets/ " + "Screenshot2.png");
//		//		path = Application.persistentDataPath + "/Snapshots/" + cliplabel;
//		//		print (path);
//		
//		Application.CaptureScreenshot(cliplabel);
//		ui.alpha = 0;
		// Encode texture into PNGq
		//byte[] bytes = .EncodeToPNG();
//		
//		// save in memory
//		string filename = fileName(Convert.ToInt32(imageOverview.width), Convert.ToInt32(imageOverview.height));
//		Application.persistentDataPath + "/Snapshots/" + "CARE4D.png";
//		
//		System.IO.File.WriteAllBytes(Application.persistentDataPath+"CARE4D.png", bytes);
//		if (System.IO.File.Exists(Application.persistentDataPath+"/"+"CARE4D.png")){ Debug.Log("File Saved to Gallery"); }
		
	}

	public static Texture2D TakeScreenshot(int width, int height, 
	                                       Camera screenshotCamera) {
		if(width<=0 || height<=0) return null;
		if(screenshotCamera == null) screenshotCamera = Camera.main;
		
		Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
		RenderTexture renderTex = new RenderTexture(width, height, 24);
		screenshotCamera.targetTexture = renderTex;
		screenshotCamera.Render();
		RenderTexture.active = renderTex;
		screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		screenshot.Apply(false);
		screenshotCamera.targetTexture = null;
		RenderTexture.active = null;
		Destroy(renderTex);
		return screenshot;
	}

	public static Texture2D TakeScreenshot(int width, int height, 
	                                       Camera screenshotCamera, string saveToFileName) {
		Texture2D screenshot = TakeScreenshot(width, height, screenshotCamera);
		if(screenshot != null && saveToFileName!=null) {
			if(Application.platform==RuntimePlatform.OSXPlayer || 
			   Application.platform==RuntimePlatform.WindowsPlayer && 
			   Application.platform!=RuntimePlatform.LinuxPlayer 
			   || Application.isEditor) {
				byte[] bytes;
				if(saveToFileName.ToLower().EndsWith(".jpg"))
					bytes = screenshot.EncodeToJPG();
				else bytes = screenshot.EncodeToPNG();
				FileStream fs = new FileStream(saveToFileName, FileMode.OpenOrCreate);
				BinaryWriter w = new BinaryWriter(fs);
				w.Write(bytes);
				w.Close();
				fs.Close();
			}
		}
		return screenshot;
	}

}

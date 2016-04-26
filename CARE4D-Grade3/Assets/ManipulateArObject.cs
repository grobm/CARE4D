using UnityEngine;
using System.Collections;

public class ManipulateArObject : MonoBehaviour
{
	
	private enum GuiState
	{
		standard,
		objLoading,
		settings
	};

	private enum TouchState
	{
		none,
		started,
		tap,
		hold,
		endHold}
	;

	GuiState guiState;
	TouchState touchState;
	GameObject target;
	Vector2 reticlePosition;
	GameObject highlightedTarget;
	GameObject highlightedTargetLastFrame;
	Color startingColor;
	float holdTime1 = 0.1f;
	float touchTime;
	bool touchHandled;
	ObjLoader objLoader;
	string objToLoad = "";

	private Vector2 scrollViewVector = Vector2.zero;
	Rect dropDownRect = new Rect(160,50,300,300);
	public static string[] list = {"Drop_Down_Menu"};
	
	int indexNumber;
	bool show = false;


	// Use this for initialization
	void Start ()
	{
		reticlePosition = new Vector2 (Screen.width / 2, Screen.height / 2);
		touchState = TouchState.none;
		guiState = GuiState.standard;
		touchHandled = false;
		objLoader = GameObject.FindObjectOfType<ObjLoader> ();
	
		Debug.Log ("List: "+list);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		HighlightTarget ();
		DetectTouch ();
		HandleTouch ();

		if(target)
			target.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 250;

		// if tapped - grab then offer button for other manipulation options
		// After another tap, drop the object.
		// if held - pick up the object and display menu around the touch. 
		// 	Other options can be selected by dragging thumb and lifting.
		//	Lifting in the middle drops the object 
	
	}

	void HighlightTarget ()
	{
		
		if (target == null) {
			Ray ray = Camera.main.ScreenPointToRay (reticlePosition);
			RaycastHit hit; 
			
			highlightedTargetLastFrame = highlightedTarget;
			
			//Check to see if anything is under the reticle: 
			var layerMask = (1 << 9);
			if (Physics.Raycast (ray, out hit, 1000f, layerMask)) {
				highlightedTarget = hit.transform.gameObject;
				
			} else
				highlightedTarget = null;
		}
		// New selectable object detected 
		// or reticle moved off of current object:
		if (highlightedTargetLastFrame != highlightedTarget) {
			ApplyEffectToTarget ();
		}
	}

	void HandleTouch()
	{
		if(target) {
			if (touchState == TouchState.tap) {
				DropObject ();
				touchHandled = true;
			} else if (touchState == TouchState.endHold) {
				DropObject ();
				touchHandled = true;
			}
		} else if(highlightedTarget) {
			if(touchState == TouchState.tap) {
				LiftTarget();
				touchHandled = true;
			}
			else if (touchState == TouchState.hold){
				LiftTarget();
			}
		}
	}


	void ApplyEffectToTarget ()
	{
		Material mat;
		if (highlightedTargetLastFrame) {
			mat = highlightedTargetLastFrame.GetComponent<Renderer> ().material;
			mat.color = startingColor;
		}

		if (highlightedTarget) {
			mat = highlightedTarget.GetComponent<Renderer> ().material;
			startingColor = mat.color;
			mat.color = Color.green;
		}
	}

	void DetectTouch ()
	{

		bool touching = Input.GetMouseButton (0);
		if(touching && TouchingUI())
			return;
		switch (touchState) {
		case TouchState.none:
			if (touching) {
				touchState = TouchState.started;
				touchTime = Time.time;
				touchHandled = false;
			}
			break;

		case TouchState.started:
			if (!touching) {
				touchState = TouchState.tap;
				break;
			}
			if (touchTime + holdTime1 < Time.time)
				touchState = TouchState.hold;
			break;

		case TouchState.tap:
			if (touchHandled) {
				Debug.Log ("Tap " +touchTime);
				touchState = TouchState.none;
			}
			break;

		case TouchState.hold:
			if (!touching)
				touchState = TouchState.endHold;
			break;

		case TouchState.endHold:
			if (touchHandled) {
				touchState = TouchState.none;
				
				Debug.Log ("Hold "+touchTime);
			}
			break;

		default:
			Debug.LogError ("Invalid touch state");
			break;
		}


	}

	bool TouchingUI() 
	{
		if(Input.mousePosition.y > 900)
			return true;
		return false;
	}

	void LiftTarget()
	{
		target = highlightedTarget;
		Debug.Log(target);
		Rigidbody r = target.GetComponent<Rigidbody>();
		Material mat;
		mat = highlightedTarget.GetComponent<Renderer> ().material;
		mat.color = startingColor;
		r.detectCollisions = false;
	}
	
	void DropObject ()
	{
		Rigidbody r = target.GetComponent<Rigidbody>();
		r.detectCollisions = true;
		target = null;
	}
	
	void Remove ()
	{
		Destroy (target);
	}
	
	void Duplicate ()
	{
		GameObject newObject = Instantiate (target);
		newObject.transform.SetParent (target.transform.parent);
		newObject.transform.localScale = target.transform.localScale;
		newObject.transform.position = target.transform.position;
		newObject.transform.rotation = target.transform.rotation;
	}
	
	
	void OnGUI ()
	{
		switch (guiState) {

		case GuiState.standard:
		
			if (target) {
				if (GUI.Button (new Rect (10, 10, 300, 200), "Remove"))
					Remove ();
				if (GUI.Button (new Rect (10, 225, 300, 200), "Duplicate"))
					Duplicate ();
			} else {
				if (GUI.Button (new Rect (10, 10, 300, 200), "Collection"))
					ShowCollection ();
				if(objToLoad.Length > 0)
					if (GUI.Button (new Rect (10, 225, 300, 200), "Create Object"))
					LoadObject ();
			}
			break;
		case GuiState.objLoading:	
			list = objLoader.GetList ();
			if(GUI.Button(new Rect((dropDownRect.x - 100), dropDownRect.y, dropDownRect.width, 25), ""))
			{
				if(!show)
				{
					show = true;
				}
				else
				{
					show = false;
				}
			}
			
			if(show && list != null)
			{
				scrollViewVector = GUI.BeginScrollView(new Rect((dropDownRect.x - 100), (dropDownRect.y + 25), dropDownRect.width, dropDownRect.height),scrollViewVector,new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length*25))));
				
				GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length*25))), "");
				
				for(int index = 0; index < list.Length; index++)
				{
					if(list[index] == null)
						break;
					if(GUI.Button(new Rect(0, (index*25), dropDownRect.height, 25), ""))
					{
						show = false;
						indexNumber = index;
					}
					
					GUI.Label(new Rect(5, (index*25), dropDownRect.height, 25), list[index]);
					
				}
				
				GUI.EndScrollView();   
			}
			else
			{
				if(list != null)	{
					GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y, 300, 25), list[indexNumber]);
					objToLoad = list[indexNumber];
				}
			}
			if (GUI.Button (new Rect (500, 10, 300, 200), "Select"))
				SelectObject ();
			//if (GUI.Button (new Rect (10, 225, 300, 200), "Duplicate"))
			//	Duplicate ();
			break;
		}
	}

	void SelectObject(){
		guiState = GuiState.standard;
	}

	void ShowCollection(){
		guiState = GuiState.objLoading;
	}

	void LoadObject() {
		StartCoroutine (objLoader.Load(objToLoad));
		StartCoroutine (TargetNewObject());
	}

	IEnumerator TargetNewObject() {
		while(objLoader.loading) {
			yield return new WaitForSeconds(0.1f);
		}
		target = objLoader.GetObj()[0];
		//Rigidbody r = new Rigidbody();
		target.AddComponent<BoxCollider>();
		target.AddComponent<Rigidbody>();
	}
}

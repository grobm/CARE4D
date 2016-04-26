using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectController : MonoBehaviour {
	public float speed = 0.5F;
	public Scrollbar SB;
	public Text SBT;

	void Start () {
	}
	

	void Update () {
		if (SB.gameObject.activeSelf) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved) { // ROTATE
				transform.Rotate (touchDeltaPosition.y * speed, touchDeltaPosition.x * speed, 0, Space.World);
			} else if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved && (Input.GetTouch (0).position.x / Screen.width < 0.8)) { // MOVE
				transform.Translate (touchDeltaPosition.x/15.0f, touchDeltaPosition.y/15.0f, 0, Space.World);
			} else if (Input.touchCount == 3 /* && Input.GetTouch (0).phase == TouchPhase.Moved*/) { //RESET
				transform.localRotation = new  Quaternion (0, 0, 0, 0);
				transform.localScale = new  Vector3 (0.9f, 0.9f, 0.9f);
				transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
				transform.Translate (-0.57f, 3.8f, 90.0f, Space.World);
			}
		}
	}

	public void ObjectScaler(){ //SCALE
		if(SB.value > 0.05 && SB.value < 0.95){
			transform.localScale = new Vector3((SB.value*2),(SB.value*2),(SB.value*2));
		}
	}
}



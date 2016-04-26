using UnityEngine;

public class ZoomView : MonoBehaviour
{
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	public float speed = 0.1F;
    public float FOV = 60.0f;


	public void OnResetCamera(){
		Vector3 temp = new Vector3(-141.3647f,131.693f,-2.400001f);
		transform.position = temp;
        Camera.current.fieldOfView = FOV;

//		GameObject.transform.position.x = -141.3647;
//		GameObject.transform.position.y = 131.693;
//		GameObject.transform.position.z = -2.400001;
//		this.transform.Translate(1, 1, 1);
		//-141.3647, 131.693, -2.400001
	}



	void Update()
	{
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel ("ARBase");
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			
			// If the camera is orthographic...
			if (GetComponent<Camera>().orthographic)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
				
				// Make sure the orthographic size never drops below zero.
				GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
			}
			else
			{
				// Otherwise change the field of view based on the change in distance between the touches.
				GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
				
				// Clamp the field of view to make sure it's between 0 and 180.
				GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 10.1f, 105.9f);
			}
		}
	}
}
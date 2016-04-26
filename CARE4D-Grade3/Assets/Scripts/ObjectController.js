#pragma strict


 var rotationSpeed = 2.0;
 var lerpSpeed = 1.0;
 
 private var speed = new Vector3();
 private var avgSpeed = new Vector3();
 private var dragging = false;
 private var targetSpeedX = new Vector3();
 
 function OnMouseDown() 
 {
     dragging = true;
 }
 
 function Update() {
 

 
 if (Input.touchCount == 1)
 {
     var theTouch : Touch = Input.GetTouch(0);
 
     if (theTouch.phase == TouchPhase.Moved)
     {
         OnMouseDown();
     }
 
     if ((theTouch.phase == TouchPhase.Ended) || (theTouch.phase == TouchPhase.Canceled))
     {
         dragging = false;
     }
  }
 
  if (Input.touchCount > 1)
 {
     dragging = false;
 }
 
     //Debug.Log ("Speed = " + speed);
     //Debug.Log ("Dragging = " + dragging);
 
     if ((theTouch.phase == TouchPhase.Moved) && dragging)
         {
         speed = new Vector3(theTouch.position.x, theTouch.position.y, 0);
         avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
         }
 
 
     if (Input.GetMouseButton(0) && dragging) 
         {
         speed = new Vector3(-Input.GetAxis ("Mouse X"), Input.GetAxis("Mouse Y"), 0);
         avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
         }
 
      else 
         {
         if (dragging) {
             speed = avgSpeed;
             dragging = false;
         }
         var i = Time.deltaTime * lerpSpeed;
         speed = Vector3.Lerp( speed, Vector3.zero, i);   
     }
 
     transform.Rotate( Camera.main.transform.up * speed.x * rotationSpeed, Space.World );
     transform.Rotate( Camera.main.transform.right * speed.y * rotationSpeed, Space.World );
 
 }



//
//private var leftFingerPos : Vector2 = Vector2.zero;
//private var leftFingerLastPos : Vector2 = Vector2.zero;
//private var leftFingerMovedBy : Vector2 = Vector2.zero;
// 
//public var slideMagnitudeX : float = 0.0;
//public var slideMagnitudeY : float = 0.0;
// 
// 
//function Update()
//{
//    if (Input.touchCount == 1)
//    {
//        var touch : Touch = Input.GetTouch(0);
//       
//        if (touch.phase == TouchPhase.Began)
//        {
//            leftFingerPos = Vector2.zero;
//            leftFingerLastPos = Vector2.zero;
//            leftFingerMovedBy = Vector2.zero;
//           
//            slideMagnitudeX = 0;
//            slideMagnitudeY = 0;
//           
//            // record start position
//            leftFingerPos = touch.position;
//           
//        }
//       
//        else if (touch.phase == TouchPhase.Moved)
//        {
//            leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
//                                                                // The position delta since last change.
//            leftFingerLastPos = leftFingerPos;
//            leftFingerPos = touch.position;
//           
//            // slide horz
//            slideMagnitudeX = leftFingerMovedBy.x / Screen.width;
//           
//            // slide vert
//            slideMagnitudeY = leftFingerMovedBy.y / Screen.height;
//           
//        }
//       
//        else if (touch.phase == TouchPhase.Stationary)
//        {
//            leftFingerLastPos = leftFingerPos;
//            leftFingerPos = touch.position;
//           
//            slideMagnitudeX = 0.0;
//            slideMagnitudeY = 0.0;
//        }
//       
//        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
//        {
//            slideMagnitudeX = 0.0;
//            slideMagnitudeY = 0.0;
//        }
//    }
//}

//
//#pragma strict
//
///// Rotation Script. Assign it to Main camera
//
//var target : Transform;
//var distance = 10.0;
//
//
//var xSpeed = 250.0;
//var ySpeed = 120.0;
//
//
//private var x = 0.0;
//private var y = 0.0;
//
//var xsign =1;
//
//@script AddComponentMenu("Camera-Control/Mouse Orbit")
//
//function Start () {
//var angles = transform.eulerAngles;
//x = angles.y;
//y = angles.x;
//
//var rotation = Quaternion.Euler(y, x, 0);
//var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
//
//transform.rotation = rotation;
//transform.position = position;
//
//
//}
//
//function LateUpdate () {
//
//
////get the rotationsigns
//
//var forward = transform.TransformDirection(Vector3.up);
//var forward2 = target.transform.TransformDirection(Vector3.up);
//if (Vector3.Dot(forward,forward2) < 0)
//xsign = -1; 
//else
//xsign =1;
//
//
//for (var touch : Touch in Input.touches) {
//if (touch.phase == TouchPhase.Moved) {
//x += xsign * touch.deltaPosition.x * xSpeed *0.02;
//y -= touch.deltaPosition.y * ySpeed *0.02;
//
//
//
//var rotation = Quaternion.Euler(y, x, 0);
//var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
//
//transform.rotation = rotation;
//transform.position = position;
//}
//}
//}
//
//
//
/////// For pinch zoom. Assign this to the parent object
//
//
//
//
//public var scaleFactor: float = 10; 
//public var maxZoom : float = 20; 
//
//function Update(){
//
//if ( Input.touchCount == 2 ){ 
//
//var touch1 : Touch = Input.GetTouch( 0 ); 
//var touch2 : Touch = Input.GetTouch( 1 ); 
//
//if ( touch1.position.y < touch2.position.y ) {
//transform.localScale.x -= ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor; 
//transform.localScale.y -= ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor; 
//transform.localScale.z -= ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor;
//
//}
//if ( touch1.position.y > touch2.position.y) {
//transform.localScale.x += ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor; 
//transform.localScale.y += ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor; 
//transform.localScale.z += ( touch1.deltaPosition.x - touch2.deltaPosition.x ) / scaleFactor; 
//}
//
//if(transform.localScale.x >= maxZoom)
//transform.localScale.x = maxZoom;
//if(transform.localScale.y >= maxZoom)
//transform.localScale.y = maxZoom;
//if(transform.localScale.z >= maxZoom)
//transform.localScale.z = maxZoom;
//if(transform.localScale.x <= 0.4)
//transform.localScale.x = 0.4;
//if(transform.localScale.y <= 0.4)
//transform.localScale.y = 0.4;
//if(transform.localScale.z <= 0.4)
//transform.localScale.z = 0.4;
//} 
//
//
//}
 

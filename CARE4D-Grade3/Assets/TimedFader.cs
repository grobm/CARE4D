using UnityEngine;
using System.Collections;

public class TimedFader : MonoBehaviour {

	public float speed = 0.3f;    
	public float offset = 1.0f;
	
	private Vector3 _initialPosition;
	private float _currentTime = 0;
	private bool _move = true;

	void Shove(string name) {
		_move = true;
	}
	
	// Use this for initialization
	void Start () {
		_initialPosition = transform.localPosition;        
	}
	
	// Update is called once per frame
	void Update () {
		if(_move) {
			_currentTime += Time.deltaTime;
		}
		
		if(_currentTime < speed) {
			float currentOffset = offset * ((speed - _currentTime) / speed);
			Vector3 currentPosition = new Vector3(_initialPosition.x, _initialPosition.y - currentOffset, _initialPosition.z);
			transform.localPosition = currentPosition;
		}	
	}
}

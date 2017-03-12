using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

	public static BoxController instance;
	public int status;
	private float minDistance = 50.0f;
	Vector2 begin, end;

	void Awake ()
	{
		if (instance == null)
			instance = this;
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	public void _SwipeDetect ()
	{
		if (Input.GetMouseButtonDown (0) == true) {
			begin = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0) == true) {
			end = Input.mousePosition;
			if (begin != end && begin != Vector2.zero && end != Vector2.zero) {
				Vector2 delta = end - begin;
				if (Mathf.Abs (delta.x) > minDistance && Mathf.Abs (delta.x) > Mathf.Abs (delta.y)) {
					status = (delta.x > 0) ? 1 : 2;
                }
				if (Mathf.Abs (delta.y) > minDistance && Mathf.Abs (delta.x) < Mathf.Abs (delta.y)) {
					status = (delta.y > 0) ? 3 : 4;
                }
			}
		}
	}
}

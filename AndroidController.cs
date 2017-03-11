using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))		//Nut Back tren Anroid co key code la Escape
			Application.Quit();
	}
}
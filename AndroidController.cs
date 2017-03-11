using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidController : MonoBehaviour {

	void _LoadBackMenu()
	{
//		float fadeTime = GameObject.Find ("Canvas").GetComponents<Fade>.BeginFade (1);
//		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (0);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 		//Nut Back tren Anroid co key code la Escape
		{		
			if (SceneManager.GetActiveScene ().buildIndex == 1) 
			{
				_LoadBackMenu ();
			}
			else if (SceneManager.GetActiveScene ().buildIndex == 0)
				Application.Quit();
		}
	}
}
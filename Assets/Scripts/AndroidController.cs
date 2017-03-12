using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidController : MonoBehaviour {
	
	[SerializeField]
	private GameObject startPanel, instructionPanel, leaderboardPanel;

	void _LoadBackMenu()
	{
		SceneManager.LoadScene (0);
	}

	void _MainMenuBack()
	{
		if (startPanel.activeSelf)
			Application.Quit ();
		else 
		{
			leaderboardPanel.SetActive(false);
			instructionPanel.SetActive(false);
			startPanel.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 		//Nut Back tren Anroid co key code la Escape
		{		
			if (SceneManager.GetActiveScene ().buildIndex == 1) 			
				_LoadBackMenu ();		
			else if (SceneManager.GetActiveScene ().buildIndex == 0)
				_MainMenuBack ();
		}
	}
}
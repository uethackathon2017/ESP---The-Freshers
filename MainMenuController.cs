using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    //[SerializeField]
    //private GameObject playButton,leaderBoardButton,settingButton,instructionButton;


    public static MainMenuController instance;
    public int stepRemaining;

    [SerializeField]
    private GameObject mainPanel,instructionPanel;




    private void Awake()
    {
        if (instance == null) 
			instance = this;
		Application.targetFrameRate = 30;		//Co dinh FPS 30
    }




    public void _playButton()
    {
        stepRemaining = 5;
		Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void _settingButton()
    {
        mainPanel.SetActive(false);
    }

    public void _leaderBoardButton()
    {
        mainPanel.SetActive(false);
    }

    public void _instructionButton()
    {
        mainPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void _backButton()
    {
        mainPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }
}

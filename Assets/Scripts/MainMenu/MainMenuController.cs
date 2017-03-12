using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    //[SerializeField]
    //private GameObject playButton,leaderBoardButton,settingButton,instructionButton;


    public static MainMenuController instance;
    public int stepRemaining;

    [SerializeField]
    private GameObject mainPanel,instructionPanel,highScorePanel;


    [SerializeField]
    private Text best, second, third;

    private void Awake()
    {
        if (instance == null) 
			instance = this;
		Application.targetFrameRate = 30;		//Co dinh FPS 30
		QualitySettings.vSyncCount = 2;
    }




    public void _playButton()
    {
        stepRemaining = 5;
		Time.timeScale = 1;
		SceneManager.LoadScene (1);
    }

    public void _settingButton()
    {
        mainPanel.SetActive(false);
    }

    public void _leaderBoardButton()
    {
        mainPanel.SetActive(false);
        _ShowLeaderboard();
        highScorePanel.SetActive(true);
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
    public void _BackButtonLeaderboard()
    {
        mainPanel.SetActive(true);
        highScorePanel.SetActive(false);
    }
    public void _ShowLeaderboard() 
    {
        if (HighScore.instance != null)
        {
            best.text = "" + HighScore.instance.highScore[0];
            second.text = "" + HighScore.instance.highScore[1];
            third.text = "" + HighScore.instance.highScore[2];
        }
    }
}

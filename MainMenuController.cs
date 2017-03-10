using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    //[SerializeField]
    //private GameObject playButton,leaderBoardButton,settingButton,instructionButton;

    [SerializeField]
    private GameObject mainPanel,instructionPanel;


    public void _playButton()
    {
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

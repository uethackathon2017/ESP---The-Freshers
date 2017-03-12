using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreExcuter : MonoBehaviour
{
    /* Script hi?n di?m lên màn hình
     */

    [SerializeField]
    Text scoreText, stepText;

    void _excuteScore()
    {
        if (ScoreController.instance == null) return;
        //ScoreController.instance._updateScore();
        //scoreText.text = "" + ScoreController.instance.score;
        //if (MainMenuController.instance != null) stepText.text = "" + MainMenuController.instance.stepRemaining;
        if (ScoreController.instance != null)
        {
            ScoreController.instance._updateStepRemaining();
            stepText.text = "" + ScoreController.instance.stepRemaining;
            scoreText.text = "" + MapMaker.instance.countLevel;
        }
    }

    private void Update()
    {
        // asd
        _excuteScore();
    }

}

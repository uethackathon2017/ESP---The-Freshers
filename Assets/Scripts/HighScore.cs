using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public static HighScore instance;

    public int[] highScore = new int[3];
    private const string BEST = "Best";
    private const string SECOND = "Second";
    private const string THIRD = "Third";

    void Awake()
    {
        _MakeOneInstance();      
        IsGameStartedForTheFirstTime();
        _GetHighScore();
    }

    void IsGameStartedForTheFirstTime() {
        if(!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(BEST, 0);
            PlayerPrefs.SetInt(SECOND, 0);
            PlayerPrefs.SetInt(THIRD, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    void _MakeOneInstance() {
        if (instance != null) Destroy(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void _PushHighScore(int score) {
        int i;
        for (i = 0; i<3; i++) if (highScore[i]<score-1)
            {
                if (i < 2)
                {
                    highScore[i + 1] = highScore[i];
                    highScore[i] = score - 1;
                }
                else highScore[i] = score - 1;
                break;
            }
        _SetHighScore();
    }
    public void _SetHighScore()
    {
        PlayerPrefs.SetInt(BEST, highScore[0]);
        //int n = PlayerPrefs.GetInt(BEST);
        PlayerPrefs.SetInt(SECOND, highScore[1]);
        PlayerPrefs.SetInt(THIRD, highScore[2]);
    }
    public void _GetHighScore()
    {
        highScore[0] = PlayerPrefs.GetInt(BEST);
        highScore[1] = PlayerPrefs.GetInt(SECOND);
        highScore[2] = PlayerPrefs.GetInt(THIRD);
    }
}

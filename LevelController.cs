using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour {

    public static LevelController instance;

    // Use this for initialization
    private void Awake()
    {
        _makeInstance();
    }
    // Update is called once per frame
    void Update () {

	}

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }


    public void _restartButton()
    {
        MapMaker.instance._BuildMap(MapMaker.instance.map);
    }


    public void _levelPassedButton()
    {
        MapMaker.instance.levelPassedPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void _gameOverButton()
    {
        MapMaker.instance.gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


    public int _checkendgame()
    /* m = 0 <=> thua
     * m = 1 <=> th?ng
     */
    {
        int i, j;
        int m = 1;
        for (i = 0; i < 15; i++)
        {
            for (j = i + 1; j < 16; j++)
            {
                if (MapMaker.instance.listText[i].text != MapMaker.instance.listText[j].text)
                {
                    m = 0;
                    break;
                }
                else continue;
            }
        }
        return m;
    }
}

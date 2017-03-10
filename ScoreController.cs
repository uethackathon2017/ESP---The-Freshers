using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    /*Script qu?n lý score, high score
     */

    public static ScoreController instance;

    public int stepRemaining;
    public int score, finalScore;
    public int highScore;
    public bool gameOver = false;
    public bool thisIsNewLevel;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void _detailOfMap(int[,] map, out int maxOfMap, out int minOfMap)
    //maxOfMap là s? max c?a map hi?n t?i, minOfMap là s? min c?a map hi?n t?i
    {
        maxOfMap = -1;
        minOfMap = 100;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                maxOfMap = map[i, j] > maxOfMap ? map[i, j] : maxOfMap;
                minOfMap = map[i, j] < minOfMap ? map[i, j] : minOfMap;
            }
    }

    public void _updateStepRemaining()
    /* C?p nh?t s? bu?c sai còn l?i
     */
    {
        if (DataExtractor.instance == null) return;
        int maxOfMap, minOfMap;
        _detailOfMap(DataExtractor.instance.map, out maxOfMap, out minOfMap);
        if (maxOfMap > DataExtractor.instance.max)
        {
            DataExtractor.instance.max = maxOfMap;
            stepRemaining--;
        }
    }
}
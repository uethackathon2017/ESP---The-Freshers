using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
using System;
public class MapMaker : MonoBehaviour {

    public int countLevel = 1;
    public static MapMaker instance;
    private bool isMoving;
	[SerializeField]
	private GameObject pointer;

    public GameObject levelPassedPanel;

	public List<Text> listText = new List<Text>();

	public int[,] map ;

	private int x = 0, y = 0,pos = 0;

	private Vector3 temp;

	public List<GameObject> row = new List<GameObject> ();

    public Text levelPassedText;

    public GameObject gameOverPanel;

    bool case1 = false;


    

	void Awake(){
		if (DataExtractor.instance != null) {
			DataExtractor.instance._ReadJSON (countLevel);
			x = DataExtractor.instance.x;
			y = DataExtractor.instance.y;
			map = DataExtractor.instance.map;
			pointer.transform.position = row [x * 4 + y].transform.position;
			pos = x + y;
		}
		if (DataExtractor.instance != null) {
			DataExtractor.instance._ReadJSON (countLevel);
			_BuildMap (map);
		}
        _makeInstance();

    }

	// Use this for initialization
	void Start () {
        isMoving = false;
	}
	// Update is called once per frame
	void Update () {
		BoxController.instance._SwipeDetect ();
		_MoveBox (BoxController.instance.status);
        levelPassedText.text = "Level " + (countLevel-1) + " Passed";
        if (LevelController.instance._checkendgame() == 1)
        {
            levelPassedPanel.SetActive(true);
            Time.timeScale = 0;

            countLevel += 1;
            DataExtractor.instance._ReadJSON(countLevel);
            x = DataExtractor.instance.x;
            y = DataExtractor.instance.y;
            map = DataExtractor.instance.map;
            pointer.transform.position = row[x * 4 + y].transform.position;
            pos = x + y;
            _BuildMap(map);
        }

        if (ScoreController.instance != null)
           if (ScoreController.instance.stepRemaining == 0)
           {
               gameOverPanel.SetActive(true);
               Time.timeScale = 0;
           }
    }

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }



    void _MoveBox(int status)
    {
        pos = x * 4 + y;
        switch (status)
        {
            case 1:
                {
                    if (y < 3)
                    {
                        if (!isMoving)
                        {
                            isMoving = true;// ngan cac hoat dong khac trong khi dang di chuyen
                            LeanTween.move(pointer, row[pos + 1].transform.position, .1f).setOnComplete(() =>
                            {
                                isMoving = false;
                                y++;
                                _ChangeNumber(x, y);
                            });// nho doan nay

                        }
                    }
                    break;
                }
            case 2:
                {
                    if (y > 0)
                    {
                        if (!isMoving)
                        {
                            isMoving = true;
                            LeanTween.move(pointer, row[pos - 1].transform.position, .1f).setOnComplete(() =>
                            {
                                isMoving = false;
                                y--;
                                _ChangeNumber(x, y);
                            });// nho doan nay
                        }
                    }
                    break;
                }
            case 3:
                {
                    if (!isMoving)
                    {
                        isMoving = true;
                        LeanTween.move(pointer, row[pos - 4].transform.position, .1f).setOnComplete(() =>
                        {
                            isMoving = false;
                            x--;
                            _ChangeNumber(x, y);
                        });// nho doan nay
                    }
                    break;
                }
            case 4:
                {
                    if (!isMoving)
                    {
                        isMoving = true;
                        LeanTween.move(pointer, row[pos + 4].transform.position, .1f).setOnComplete(() =>
                        {
                            isMoving = false;
                            x++; ;
                            _ChangeNumber(x, y);
                        });// nho doan nay
                    }
                    break;
                }
        }
        BoxController.instance.status = 0;
    }

    void _Add(Text text, int num)
	{
		text.text = "" + num;
	}

	public void _BuildMap(int[,] imap)
	{
		int i, j;
		i = 0;
		j = 0;
		foreach (Text text in listText)
		{
			_Add(text, imap[i, j]);  //Add l?n lu?t theo th? t? t? tr�i qua ph?i, t? tr�n xu?ng du?i
			if (j == 3)
			{
				i++;
				j = 0;
			}
			else
				j++;
		}
	}
	void _ChangeNumber(int x,int y){
		map [x, y]++;
		listText [x * 4 + y].text = "" + map [x, y];
	}
}
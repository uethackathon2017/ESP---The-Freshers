using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;
public class MapMaker : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip swipeClip, passLevelClip, gameOverClip;

    public int countLevel = 1;
    public static MapMaker instance;
    private bool isMoving, isChecked;
    [SerializeField]
    private GameObject pointer;

    public GameObject levelPassedPanel;

    public List<Text> listText = new List<Text>();

    public int[,] map;

    private int x = 0, y = 0, pos = 0;

    private Vector3 temp;

    public List<GameObject> row = new List<GameObject>();

    public Text levelPassedText, scoreText, timeText, ranOutTime, ranOutLive;

    public GameObject gameOverPanel;

    bool gameOver = true;

    double timeLimit;

    void Awake()
    {
        if (DataExtractor.instance != null)
        {
            DataExtractor.instance._ReadJSON(countLevel);
            x = DataExtractor.instance.x;
            y = DataExtractor.instance.y;
            map = DataExtractor.instance.map;
            timeLimit = DataExtractor.instance.limit;
            timeText.gameObject.SetActive(true);
            pointer.transform.position = row[x * 4 + y].transform.position;
            pos = x + y;
        }
        if (DataExtractor.instance != null)
        {
            DataExtractor.instance._ReadJSON(countLevel);
            _BuildMap(map);
        }
        _makeInstance();
        if (HighScore.instance != null)
        {
            HighScore.instance._GetHighScore();
        }
        Application.targetFrameRate = 30;		//Co dinh FPS bang 30
    }

    // Use this for initialization
    void Start()
    {
        isMoving = false;
        isChecked = false;
    }
    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        //timeText.text = "Time left: " + (int)timeLimit;
        timeText.text = "Time left\n" + string.Format("{0:0.00}", timeLimit);
        BoxController.instance._SwipeDetect();
        _MoveBox(BoxController.instance.status);
        levelPassedText.text = "Level " + (countLevel - 1) + " Passed";
        if (LevelController.instance._checkendgame() == 1 && timeLimit > 0.05f)
        {
            levelPassedPanel.SetActive(true);
            //timeText.gameObject.SetActive(false);
            Time.timeScale = 0;
            audioSource.PlayOneShot(passLevelClip);

            countLevel += 1;
            DataExtractor.instance._ReadJSON(countLevel);
            x = DataExtractor.instance.x;
            y = DataExtractor.instance.y;
            map = DataExtractor.instance.map;
            timeLimit = DataExtractor.instance.limit;
            timeText.gameObject.SetActive(true);
            pointer.transform.position = row[x * 4 + y].transform.position;
            pos = x + y;
            _BuildMap(map);
        }

		if ((timeLimit <= 0 || ScoreController.instance != null && ScoreController.instance.stepRemaining == 0) && isChecked == false)
        {
            isChecked = true;
            if (gameOver) audioSource.PlayOneShot(gameOverClip);
            gameOver = false;
            gameOverPanel.SetActive(true);
            if (ScoreController.instance.stepRemaining <= 0)
            {
                ranOutLive.gameObject.SetActive(true);
                ranOutTime.gameObject.SetActive(false);
            }
            else
            {
                ranOutLive.gameObject.SetActive(false);
                ranOutTime.gameObject.SetActive(true);
            }
            scoreText.text = "Score: " + (countLevel - 1);
            HighScore.instance._PushHighScore(countLevel);
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
                                audioSource.PlayOneShot(swipeClip);
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
                                audioSource.PlayOneShot(swipeClip);
                            });// nho doan nay
                        }
                    }
                    break;
                }
            case 3:
                {
                    if (x > 0)
                        if (!isMoving)
                        {
                            isMoving = true;
                            LeanTween.move(pointer, row[pos - 4].transform.position, .1f).setOnComplete(() =>
                            {
                                isMoving = false;
                                x--;
                                _ChangeNumber(x, y);
                                audioSource.PlayOneShot(swipeClip);
                            });// nho doan nay
                        }
                    break;
                }
            case 4:
                {
                    if (x < 3)
                        if (!isMoving)
                        {
                            isMoving = true;
                            LeanTween.move(pointer, row[pos + 4].transform.position, .1f).setOnComplete(() =>
                            {
                                isMoving = false;
                                x++; ;
                                _ChangeNumber(x, y);
                                audioSource.PlayOneShot(swipeClip);
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
    void _ChangeNumber(int x, int y)
    {
        map[x, y]++;
        listText[x * 4 + y].text = "" + map[x, y];
    }
}
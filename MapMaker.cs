using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MapMaker : MonoBehaviour {

    int countLevel;
    public static MapMaker instance;

	[SerializeField]
	private GameObject pointer;

	public List<Text> listText = new List<Text>();
	private int[,] map ;

	private int x = 0, y = 0,pos = 0;
	private Vector3 temp;
	public List<GameObject> row = new List<GameObject> ();

	void Awake(){
		if (DataExtractor.instance != null) {
			DataExtractor.instance._ReadJSON (1);
			x = DataExtractor.instance.x;
			y = DataExtractor.instance.y;
			map = DataExtractor.instance.map;
			pointer.transform.position = row [x * 4 + y].transform.position;
			pos = x + y;
		}
		if (DataExtractor.instance != null) {
			DataExtractor.instance._ReadJSON (1);
			_BuildMap (map);
		}
	}
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		BoxController.instance._SwipeDetect ();
		_MoveBox (BoxController.instance.status);
        if(LevelController.instance._checkEndGame() == 1)
        {
            DataExtractor.instance._ReadJSON(countLevel);
            x = DataExtractor.instance.x;
            y = DataExtractor.instance.y;
            map = DataExtractor.instance.map;
            pointer.transform.position = row[x * 4 + y].transform.position;
            pos = x + y;
            _BuildMap(map);
            countLevel += 1;
        }
	}

    void _makeInstance()
    {
        if (instance == null) instance = this;
    }


	void _MoveBox (int status)
	{
		pos = x*4 + y;
		switch (status) {
		case 1:
			{
				if (y < 3) {
					temp = row [pos + 1].transform.position - row [pos].transform.position;
					pointer.transform.Translate (temp);
					y++;
					_ChangeNumber (x, y);
				}
				break;
			}
		case 2:
			{
				if (y > 0) {
					temp = row [pos - 1].transform.position - row [pos].transform.position;
					pointer.transform.Translate (temp);
					y--;
					_ChangeNumber (x, y);
				}
				break;
			}
		case 3:
			{
				if (x > 0) {
					temp = row [pos - 4].transform.position - row [pos].transform.position;
					pointer.transform.Translate (temp);
					x--;
					_ChangeNumber (x, y);
				}
				break;
			}
		case 4:
			{
				if (x < 3) {
					temp = row [pos + 4].transform.position - row [pos].transform.position;
					pointer.transform.Translate (temp);
					x++;
					_ChangeNumber (x, y);
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

	void _BuildMap(int[,] imap)
	{
		int i, j;
		i = 0;
		j = 0;
		foreach (Text text in listText)
		{
			_Add(text, imap[i, j]);  //Add lần lượt theo thứ tự từ trái qua phải, từ trên xuống dưới
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
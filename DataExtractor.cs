using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System;
using UnityEngine.UI;
using System.IO;

public class DataExtractor : MonoBehaviour {

    public static DataExtractor instance;

	public int[,] map = new int [4, 4];     // Cái mảng này này ông nhõi 

	public int[] highScoreBoard = new int[3];

    public int x = 0, y = 0, max = 0;    // Toa do ban dau cua con tro va gia tri MAX

	void Awake ()
    {
		if (instance == null)
			instance = this;
	}
    private void Update()
    {
       
    }

    public void _ReadJSON(int level)        //Truyen vao level va doc ra du lieu cua level do
    {
        int i, j;
        string jsonString = Resources.Load<TextAsset> ("level"+level).text;     //Doc du lieu JSON ra dang text

        var jsonData = Json.Deserialize(jsonString) as Dictionary<string, object>;      //Dua du lieu trong file JSON ve kieu dictionary

        x = Convert.ToInt32(jsonData["xCor"]);      //Doc toa do x va y cua con tro
        y = Convert.ToInt32(jsonData["yCor"]);
        max = Convert.ToInt32(jsonData["max"]);     //Doc gia tri MAX

        var rawDict = (Dictionary<string, object>)Json.Deserialize(jsonString);
        var rawMap = (List<object>)rawDict["map"];     //Doc map tu dictionary

        for (i = 0; i < 4; i++)
        {
            var tempDict = (List<object>)rawMap[i];     //Lay ra 1 dong tu map
            for (j = 0; j < 4; j++)
            {
                map[i, j] = Convert.ToInt32(tempDict[j]);       //Doc gia tri o toa do [i,j]
            }
        }
    }
	public void InitHighScore()
	{
		int i;
		string jsonHighScore = Resources.Load<TextAsset> ("highScore").text;
		var highScoreData = Json.Deserialize (jsonHighScore) as Dictionary<string, object>;
		for (i = 0; i < 3; i++) 
		{
			highScoreBoard [i] = Convert.ToInt32 (highScoreData ["highScore" + i]);
		}
	}
	public void PushHighScore(int[] arr)
	{
		Dictionary<string, int> data = new Dictionary<string, int>()
		{
			{"highScore1",arr[0]},
			{"highScore2",arr[1]},
			{"highScore3",arr[2]}
		};
		var jsonFile = Json.Serialize (data);
		File.WriteAllText ("highScore.json", jsonFile);
	}
}

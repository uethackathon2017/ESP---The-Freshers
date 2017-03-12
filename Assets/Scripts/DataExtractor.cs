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

    public int x = 0, y = 0, max = 0;    // Toa do ban dau cua con tro va gia tri MAX

	public double limit = 0.0f;

	void Awake ()
    {
		if (instance == null)
			instance = this;
	}
    public void _ReadJSON(int level)        //Truyen vao level va doc ra du lieu cua level do
    {
        int i, j;
        string jsonString = Resources.Load<TextAsset> ("level"+level).text;     //Doc du lieu JSON ra dang text

        var jsonData = Json.Deserialize(jsonString) as Dictionary<string, object>;      //Dua du lieu trong file JSON ve kieu dictionary

        x = Convert.ToInt32(jsonData["xCor"]);      //Doc toa do x va y cua con tro
        y = Convert.ToInt32(jsonData["yCor"]);
		limit = Convert.ToDouble (jsonData["limit"]);		//Doc gia tri time limit
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
}
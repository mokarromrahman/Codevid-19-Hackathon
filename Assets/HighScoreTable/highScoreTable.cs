using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class highScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public List<HighScoreEntry> highScoreEntryList;
    public List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        //commented out - drag into the variables in the inspector instead
        //entryContainer = transform.Find("highScoreEntryContainer");
        //entryTemplate = transform.Find("highScoreEntryTemplate");

     
        entryTemplate.gameObject.SetActive(false);

        /**
        //generating a list for testing. need to actually grab the players score and players name
        highScoreEntryList = new List<HighScoreEntry>() {
            new HighScoreEntry{ score = 1, name = "1guy"},
            new HighScoreEntry{ score = 2, name = "2guy"},
            new HighScoreEntry{ score = 0, name = "0guy"},
            new HighScoreEntry{ score = 4, name = "4guy"},
            new HighScoreEntry{ score = 3, name = "3guy"}
        };
        **/

        //loading the string - if there is anything to load
        //possibly need a null string check here?
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //sort the list by score
        for (int i =0; i < highScoreEntryList.Count; i++){
            for (int j = i + 1; j < highScoreEntryList.Count; j++){
                if(highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            createHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

        /**
        HighScores highScores = new HighScores { highScoreEntryList = highScoreEntryList };
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save(); //saving the string in json format
        UnityEngine.Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        **/


    }

    public void createHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {

        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count); //position each set of entries on the board
        entryTransform.gameObject.SetActive(true); //display the list


        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        //add prefix for 1st second and third score 
        entryTransform.Find("rankText").GetComponent<Text>().text = rankString;

        //get the score of the high score entry
        int score = highScoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        //get the name of the player (need to change so player can input name)
        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);

    }


    public class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }


    /*
     * represents a single high score entry
     * implementing serializable allows HighScoreEntry objects to be converted to Json format
     * in other words, they can be serialized alongside ou highScoreEntryList into json format
     */
    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;
        public string name;

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * this class manages the score board and saves player scores. Scores will still be available offline
 */
public class highScoreTable : MonoBehaviour
{

    public Transform entryContainer;
    public Transform entryTemplate;
    public List<Transform> highScoreEntryTransformList;

    public static List<HighScoreEntry> highScoreEntryList;
    HighScores highScores;

    private void Awake()
    {
        //commented out - drag into the variables in the inspector instead
        //entryContainer = transform.Find("highScoreEntryContainer");
        //entryTemplate = transform.Find("highScoreEntryTemplate");
     
        entryTemplate.gameObject.SetActive(false);
        PlayerPrefs.DeleteAll();

        //loading the string - if there is anything to load
        //possibly need a null string check here?

        string jsonString = PlayerPrefs.GetString("highscoreTable"); //json string is empty if there is no high scores
        if (jsonString.Length < 1)
        {
           highScores = new HighScores { highScoreEntryList = highScoreEntryList }; //initialize highScores this way
        }
        else
        {
           highScores = JsonUtility.FromJson<HighScores>(jsonString); //highscores is non-null, load from json string
        }

        //UnityEngine.Debug.Log("highscores: " + highScores);


        //sort the list by score
        for (int i =0; i < highScores.highScoreEntryList.Count; i++){
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++){
                if(highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
        {
            createHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

    }

    /**
     * function to display the list on the screen and format it properly
     */
    public void createHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {

        float templateHeight = 20f; //make this more general for different screens?
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

        //add prefix for the rank
        entryTransform.Find("rankText").GetComponent<Text>().text = rankString;

        //get the score of the high score entry
        int score = highScoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        //get the name of the player (need to change so player can input name)
        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        //add the entry to the entryList (Transform is similar to inflater in android studio)
        transformList.Add(entryTransform);

    }


    /**
     * function that takes in a score and string and adds it to the
     * highscoreEntryList to be saved
     * param: score = the players score
     * param: name = the players name
     */
    public static void addHighScoreEntry(int score, string name)
    {
        //a new high score entry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        HighScores hs;

        // load saved high scores
        string jsonString = PlayerPrefs.GetString("highscoreTable"); //uploading list from key --> will be empty upon application launch
        if (jsonString.Length < 1)
        {
            hs = new HighScores { highScoreEntryList = highScoreEntryList };
        }
        else
        {
            hs = JsonUtility.FromJson<HighScores>(jsonString); //highscores is non null
        }

        // add new entry to high scores
        hs.highScoreEntryList.Add(highScoreEntry);
        
        //save updated highscores
        string json = JsonUtility.ToJson(hs); // converting highScores to json. 
        PlayerPrefs.SetString("highscoreTable", json); //key, value --> saving the json string of highscores
        PlayerPrefs.Save(); //saving the string in json format

    }

    /*
     *class that holds the list to be jsonified lol 
     * ---> Highscores is an object that is a list of objects of high scores
     */
    public class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }


    /*
     * represents a single high score entry objects (implements serializable)
     * implementing serializable allows HighScoreEntry objects to be converted to Json format
     * in other words, they can be serialized alongside ou highScoreEntryList into json format
     * ----> HighScoreEntry objects are a high score object. composed of name and score.
     */
    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;
        public string name;

    }

}

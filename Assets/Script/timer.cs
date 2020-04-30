﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    //max time limit
    const float timeLimit = 20f;

    //counter we're using to keep track of the time
    float timeStart;

    //textbox we're displaying to
    public Text textBox;

    // Start is called before the first frame update
    //here is a script comment
    void Start()
    {
        textBox.text = timeStart.ToString();

        timeStart = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //if (timeStart == 0){
        //    timeStart = 5;
        //}

        //reduce the time and display
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();


        if (Goal.GoalReached)
        {
            Debug.Log("Ran out of time.");
            //increase the points by the amount of seconds left times 100
            Score.CurrentScore += (int)timeStart * 100;

            //reset the timer and the goal reached flag and send back to the beggining
            timeStart = timeLimit;
            Goal.GoalReached = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        //time ran out
        if (timeStart <= 0)
        {
            Debug.Log("Ran out of time.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.CurrentScore = 0;
            return;
        }
    }
}
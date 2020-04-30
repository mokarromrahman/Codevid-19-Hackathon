using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public static bool GoalReached { get; set; }

    private void Start()
    {
        GoalReached = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("You won!");
        //Score.CurrentScore += 1000;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GoalReached = collision.tag.Equals("Player");

    }
}

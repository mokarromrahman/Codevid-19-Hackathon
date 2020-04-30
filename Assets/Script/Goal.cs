using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    //
    public static bool GoalReached { get; set; }
    public static bool GameOver { get; set; }
    public string levelScene;

    private void Start()
    {
        GoalReached = false;
        GameOver = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("You won!");
        //Score.CurrentScore += 1000;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GoalReached = collision.tag.Equals("Player");

        GameOver = false;

        SceneManager.LoadScene(levelScene);
        Debug.Log("game won");
    }
}

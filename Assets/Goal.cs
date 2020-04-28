using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You won!");
        Score.CurrentScore = 1000;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

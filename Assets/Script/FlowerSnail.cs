using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerSnail : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //decrease points by 50 points when hitting a negative object
        if(collision.tag.Equals("Hand")|| collision.tag.Equals("Remote")|| collision.tag.Equals("Phone"))
        {
            //Debug.Log("We lost!");
            Score.CurrentScore -= 50;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //prevent the points from being less than 0
            if(Score.CurrentScore < 1)
                Score.CurrentScore = 0;

        }

        //getting lysol 
        if (collision.tag.Equals("Lysol"))
        {
            Debug.Log("Extra points!");
            Score.CurrentScore += 50;
        }

        //getting to the end
        if(collision.tag.Equals("Goal"))
        {
            Score.CurrentScore += 1000;
            Debug.Log("Reached the endpoint.");

        }
    }
}

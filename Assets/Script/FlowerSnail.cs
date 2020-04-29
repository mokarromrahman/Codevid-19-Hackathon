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
        if(collision.tag.Equals("Hand")|| collision.tag.Equals("Remote")|| collision.tag.Equals("Phone"))
        {
            Debug.Log("We lost!");
            Score.CurrentScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collision.tag.Equals("Lysol"))
        {
            Debug.Log("Extra points!");
            Score.CurrentScore += 50;
        }
    }
}

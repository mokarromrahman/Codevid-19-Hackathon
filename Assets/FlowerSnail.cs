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

    public Rigidbody2D _rb2D;

    // Update is called once per frame
    void Update()
    {
        //checking for input
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //move 1 unit to the right frm the current location
            _rb2D.MovePosition(_rb2D.position + Vector2.right);
        }
        //left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rb2D.MovePosition(_rb2D.position + Vector2.left);
        }
        //up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb2D.MovePosition(_rb2D.position + Vector2.up);
        }
        //down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb2D.MovePosition(_rb2D.position + Vector2.down);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Worm")
        {
            Debug.Log("We lost!");
            Score.CurrentScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator animator;
    public int speed = 5;
    Vector2 pointA;
    Vector2 pointB;
    Vector2 targetDistance;

    Vector2 screenBoundary;

    // Start is called before the first frame update
    void Start()
    {
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButtonUp(0))
        {
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            MoveCharacter();
        }
    }
    private void FixedUpdate()
    {

        if (player.position == targetDistance ||
            (targetDistance.x > screenBoundary.x || targetDistance.x < -screenBoundary.x) ||
            (targetDistance.y > screenBoundary.y || targetDistance.y + Vector2.down.y < -screenBoundary.y)) { 
            player.velocity = new Vector2(0, 0);
        }

    }
    private void MoveCharacter()
    {
   
        Debug.Log("Moving character...");
        
        Vector2 direction = getAngle();
        //player.velocity = new Vector2(10,10);

        if (Mathf.Abs(direction.x) >= 0.5f)
        {
            if (direction.x > 0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                player.velocity = new Vector2(speed, 0);
                targetDistance = player.position + Vector2.right;
            }
            else
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                player.velocity = new Vector2(-speed, 0);
                targetDistance = player.position + Vector2.left;
            }                
        }

        if (Mathf.Abs(direction.y) >= 0.5f)
        {
            if(direction.y > 0)
            {
                player.velocity = new Vector2(0, speed);
                targetDistance = player.position + Vector2.up;
            }                
            else
            {
                player.velocity = new Vector2(0, -speed);
                targetDistance = player.position + Vector2.down;
            }


           
        }

        animator.SetFloat("Vertical", player.velocity.y);
        animator.SetFloat("Horizontal", player.velocity.x);
        animator.SetFloat("Speed", player.velocity.sqrMagnitude);


    }    
    private Vector2 getAngle()
    {
        Vector2 offset = pointB - pointA;
        return Vector2.ClampMagnitude(offset, 1.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rb;
    public enum MoveOptions { UpDown, LeftRight };
    public MoveOptions movementOptions;

    private bool movingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        //set rb to a Rigidbody on our Ship object.  
        // If there is no Rigidbody then we will get an error.        
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is not existing!");
        }


        if (movementOptions == MoveOptions.LeftRight)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY |
            RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX |
            RigidbodyConstraints2D.FreezeRotation;
        }
    }

    //This method gets called when we are dragging the mouse over our ship.
    // private void OnMouseDrag()
    // {
    //     //This turns our mouse pointer into usable 2D coordinates. 
    //     Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     Vector3 shipPosition = transform.position; // This is current ship position in coordinates. 

    //     Vector2 directionToMove = new Vector2(0, 0);

    //     if (movementOptions == MoveOptions.UpDown)
    //     {
    //         // if our mouse curser is above the ship  
    //         if (shipPosition.y < touchPoint.y)
    //         {
    //             //We are going up 
    //             directionToMove.y += touchPoint.y - shipPosition.y;
    //         }
    //         else if (shipPosition.y > touchPoint.y) // if the curser is below the ship 
    //         {
    //             // we are going down 
    //             directionToMove.y -= shipPosition.y - touchPoint.y;
    //         }
    //     }
    //     else
    //     {
    //         // if our mouse curser goes right side of the ship  
    //         if (shipPosition.x < touchPoint.x)
    //         {
    //             //We are going to right side 
    //             directionToMove.x += touchPoint.x - shipPosition.x;
    //         }
    //         else if (shipPosition.x > touchPoint.x) // if the curser goes left to the ship 
    //         {
    //             // we are going left 
    //             directionToMove.x -= shipPosition.x - touchPoint.x;
    //         }
    //     }

    //     // Tells the rigidbody/Physics calculator to move us in the direction we want 
    //     rb.AddForce(directionToMove * movementSpeed, ForceMode2D.Force);
    // }

     void Update()
    {
        // Move the vehicle horizontally
        if (movingRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        // If the vehicle reaches the right boundary, change direction
        if (transform.position.x >= 7.5f)
        {
            movingRight = false;
        }
        // If the vehicle reaches the left boundary, change direction
        else if (transform.position.x <= -7.5f)
        {
            movingRight = true;
        }
    }


    private void OnMouseDown()
    {
        rb.isKinematic = false; 
    }

    private void OnMouseUp()
    {
        rb.isKinematic = true; 
        rb.velocity = new Vector2(0, 0); 
    }

}

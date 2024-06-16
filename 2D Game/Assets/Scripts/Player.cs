
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 125F;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is not existing!");
        }

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    private void OnMouseDrag()
    {
        Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objectPosition = transform.position;
        Vector2 directionToMove = new Vector2(0, 0);

        if (objectPosition.y < touchPoint.y)
        {
            directionToMove.y += touchPoint.y - objectPosition.y;
        }
        else if (objectPosition.y > touchPoint.y)
        {
            directionToMove.y -= objectPosition.y - touchPoint.y;
        }


        if (objectPosition.x < touchPoint.x)
        {
            directionToMove.x += touchPoint.x - objectPosition.x;
        }
        else if (objectPosition.x > touchPoint.x)
        {
            directionToMove.x -= objectPosition.x - touchPoint.x;
        }

        rb.velocity = Vector2.zero;
        rb.AddForce(directionToMove * movementSpeed, ForceMode2D.Force);
    }


    // Detect collisions with vehicles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("vehicle"))
        {
            PlayerLives playerLives = GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                playerLives.DecreaseLives();
            }
            else
            {
                Debug.LogError("PlayerLives script not found!");
            }
        }

    }
}

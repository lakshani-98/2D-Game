
using UnityEngine;

public class Movable : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rb;
    public enum MoveOptions { UpDown, LeftRight };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is not existing!");
        }

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnMouseDrag()
    {
        Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shipPosition = transform.position;

        Vector2 directionToMove = new Vector2(0, 0);

        if (shipPosition.y < touchPoint.y)
        {
            directionToMove.y += touchPoint.y - shipPosition.y;
        }
        else if (shipPosition.y > touchPoint.y)
        {
            directionToMove.y -= shipPosition.y - touchPoint.y;
        }

        if (shipPosition.x < touchPoint.x)
        {
            directionToMove.x += touchPoint.x - shipPosition.x;
        }
        else if (shipPosition.x > touchPoint.x)
        {
            directionToMove.x -= shipPosition.x - touchPoint.x;
        }

        rb.AddForce(directionToMove * movementSpeed, ForceMode2D.Force);
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

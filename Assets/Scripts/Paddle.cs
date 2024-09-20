using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int id;  // Changed id to an integer for consistency
    public float moveSpeed = 2f;

    private void Update()
    {
        float value = ProcessInput();
        Move(value);
    }

    private void Move(float value)
    {
        Vector2 velo = rb2d.velocity;
        velo.y = value * moveSpeed;
        rb2d.velocity = velo;
    }

    private float ProcessInput()
    {
        float movement = 0f;

        if (id == 1)
        {
            movement = Input.GetAxis("MovePlayer1");
            Debug.Log("Player 1 Input: " + movement);
        }
        else if (id == 2)
        {
            movement = Input.GetAxis("MovePlayer2");
            Debug.Log("Player 2 Input: " + movement);
        }

        return movement;
    }
}

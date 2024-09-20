using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float startX = 0f;
    public float maxStartY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InitialPush();
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;  // Stop the ball's movement
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    void InitialPush()
    {
        Vector2 dir = Vector2.left;

        if (Random.value < 0.5f)
        {
            dir = Vector2.right;
        }

        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            ResetBall();  // Reset position and stop the ball
            InitialPush();  // Apply initial push after resetting
        }
    }
}

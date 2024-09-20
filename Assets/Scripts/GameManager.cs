using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ScorePlayer1, ScorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;

    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
        {
            ScorePlayer1++;
        }
        else if (id == 2)  // Ensure correct player score update
        {
            ScorePlayer2++;
        }

        UpdateScores();
    }

    private void UpdateScores()
    {
        scoreTextLeft.SetScore(ScorePlayer1);
        scoreTextRight.SetScore(ScorePlayer2);
    }
}

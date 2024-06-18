using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text p1Score;
    public Text p2Score;
    public Text result;

    // Change score variables to represent the tennis scoring system
    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public void addScore(int input)
    {
        if (input == 1)
        {
            // Player 1 scores
            if (scoreP1 == 0)
            {
                scoreP1 = 15;
            }
            else if (scoreP1 == 15)
            {
                scoreP1 = 30;
            }
            else if (scoreP1 == 30)
            {
                scoreP1 = 40;
            }
            else if (scoreP1 == 40)
            {
                if (scoreP2 == 40)
                {
                    // Deuce
                    scoreP1 = 41;
                    scoreP2 = 40;
                }
                else if (scoreP2 == 41)
                {
                    // Player 2 had advantage, so it's back to Deuce
                    scoreP1 = 40;
                    scoreP2 = 40;
                }
                else
                {
                    // Player 1 wins the game
                    result.text = "Player 1 Wins!";
                }
            }
            else if (scoreP1 == 41)
            {
                // Player 2 had advantage, back to Deuce
                //scoreP1 = 40;
                //scoreP2 = 40;
                // Player 1 wins the game
                    result.text = "Player 1 Wins!";
            }
        }
        else if (input == 2)
        {
            // Player 2 scores
            if (scoreP2 == 0)
            {
                scoreP2 = 15;
            }
            else if (scoreP2 == 15)
            {
                scoreP2 = 30;
            }
            else if (scoreP2 == 30)
            {
                scoreP2 = 40;
            }
            else if (scoreP2 == 40)
            {
                if (scoreP1 == 40)
                {
                    // Deuce
                    scoreP1 = 40;
                    scoreP2 = 41;
                }
                else if (scoreP1 == 41)
                {
                    // Player 1 had advantage, back to Deuce
                    scoreP1 = 40;
                    scoreP2 = 40;
                }
                else
                {
                    // Player 2 wins the game
                    result.text = "Player 2 Wins!";
                }
            }
            else if (scoreP2 == 41)
            {
                // Player 1 had advantage, back to Deuce
                //scoreP1 = 40;
                //scoreP2 = 40;
                // Player 2 wins the game
                    result.text = "Player 2 Wins!";
            }
        }

        // Update the displayed scores
        p1Score.text = GetScoreText(scoreP1);
        p2Score.text = GetScoreText(scoreP2);
    }

    // Helper method to get the score as a string
    private string GetScoreText(int score)
    {
        /*if (score == 40)
        {
            return "Advantage";
        }*/
        if (score == 41)
        {
            return "Ad";
        }
        return score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed.
    }
}

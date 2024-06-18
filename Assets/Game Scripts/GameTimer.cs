using System.Collections;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer display
    public TextMeshProUGUI player1TimeText; // Player 1's time display
    public TextMeshProUGUI countdownText; // Countdown display
    private float startTime;
    private bool isTimerRunning = false;
    public float player1Time = 0f; // Store player 1's time
    public Driver driver;

    // Make sure Start() does not automatically start the timer.
    void Start()
    {
        if (GameManager.Instance.isPlayer1Done)
        {
            // Display player one's time at the start of player two's turn
            player1TimeText.text = "Player 1 Time: " + FormatTime(GameManager.Instance.player1Time);
        }

        StartCountdown(); // Start the countdown for player two
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimerDisplay();
        }
    }

    // Method to start the countdown
    public void StartCountdown(int countdownTime = 3)
    {
        StartCoroutine(CountdownCoroutine(countdownTime));
    }

    // Countdown coroutine
    private IEnumerator CountdownCoroutine(int seconds)
    {
        countdownText.gameObject.SetActive(true);

        while (seconds > 0)
        {
            countdownText.text = seconds.ToString();
            yield return new WaitForSeconds(1);
            seconds--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1); // Brief pause

        countdownText.gameObject.SetActive(false);
        StartTimer(); // Only start the timer after the countdown
        driver.EnableMovement();
    }

    // Method to start the game timer
    public void StartTimer()
    {
        if (!isTimerRunning) // Add this check to prevent the timer from starting multiple times
        {
            startTime = Time.time;
            isTimerRunning = true;
            timerText.gameObject.SetActive(true); // Make sure the timer text is visible
        }
    }

    // Method to stop the timer for Player 1
    public void StopTimerForPlayer1()
    {
        if (isTimerRunning) // Add this check to ensure we're actually running before stopping
        {
            isTimerRunning = false;
            player1Time = Time.time - startTime;
            GameManager.Instance.SetPlayer1Time(player1Time); // Save time to GameManager
            player1TimeText.text = "Player 1 Time: " + FormatTime(player1Time);
        }
    }

    // Method to update the timer display
    private void UpdateTimerDisplay()
    {
        if (isTimerRunning)
        {
            float timeElapsed = Time.time - startTime;
            timerText.text = FormatTime(timeElapsed);
        }
    }

    // Method to format the time into a string
    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 1000) % 1000);
        return $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }
    // Method to stop the timer for Player 2
    public void StopTimerForPlayer2()
    {
        if (isTimerRunning)
        {
            isTimerRunning = false;
            float player2Time = Time.time - startTime;
            GameManager.Instance.SetPlayer2Time(player2Time); // Save time to GameManager
        }
    }
}













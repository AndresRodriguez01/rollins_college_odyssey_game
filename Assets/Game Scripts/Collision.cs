using UnityEngine;

public class Collision : MonoBehaviour
{
    private Driver driverScript;
    public Driver driver;
    public GameTimer gameTimer; // Reference to the GameTimer script

    private void Start()
    {
        driverScript = GetComponent<Driver>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); // Debug to check collisions

        if (other.CompareTag("Lake"))
        {
            Debug.Log("Entered the lake");
            driverScript.slowDownFactor = 0.01f;
        }
        else if (other.CompareTag("Pickup"))
        {
            Debug.Log("Collided with pickup object");
            other.gameObject.SetActive(false);
            driverScript.hasPickedUpObject = true;
            driverScript.DeactivateWall(); // Deactivate the wall when pickup is collected
        }
        else if (other.CompareTag("FinishLine"))
        {
            if (driverScript.hasPickedUpObject)
            {
                if (!GameManager.Instance.isPlayer1Done) // Player 1 finishes
                {
                    gameTimer.StopTimerForPlayer1();
                    driver.DisableMovement();
                    Invoke("ResetForPlayerTwo", 1f); // 1 second delay
                }
                else // Player 2 finishes
                {
                    gameTimer.StopTimerForPlayer2(); // Need to implement this method in GameTimer
                    driver.DisableMovement();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lake"))
        {
            Debug.Log("Exited the lake");
            driverScript.slowDownFactor = 1f;
        }
    }

    private void ResetForPlayerTwo()
    {
        GameManager.Instance.RestartLevelForPlayer2();
    }
}



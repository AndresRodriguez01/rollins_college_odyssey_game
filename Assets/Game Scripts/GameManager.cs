using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button buttonToLoadScene1;
    public static GameManager Instance;
    public bool isPlayer1Done = false;
    public float player1Time = 0f;
    public float player2Time = 0f;


    void Start()
    {
        // Assuming the scenes are named "Scene1", "Scene2", "Scene3", and "Scene4"
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("MapScene"));

    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed on scene load
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }
    }

    // Method to be called when Player 1 finishes
    public void SetPlayer1Time(float time)
    {
        isPlayer1Done = true;
        player1Time = time;
        // Additional logic can be added here if needed
    }


    public void SetPlayer2Time(float time)
    {
        player2Time = time;
        LoadResultScene(); // Call to load the result scene
    }

    private void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene"); // Replace "ResultScene" with your result scene's name
    }

    // Method to restart the level for Player 2

    public void RestartLevelForPlayer2()
    {
        // Optionally reset any necessary game state before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to reset the game for a new match
    public void ResetGame()
    {
        isPlayer1Done = false;
        player1Time = 0f;
        // Reset other game states as necessary
        // Optionally reload the scene or reset specific objects
    }
    


    // Additional methods for game management can be added here
}










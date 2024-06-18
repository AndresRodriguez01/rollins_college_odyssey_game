using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Replace with the name of your game scene

    public void TransitionToGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

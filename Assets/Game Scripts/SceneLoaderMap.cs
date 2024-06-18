using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Button buttonToLoadScene1;
    public Button buttonToLoadScene2;
    public Button buttonToLoadScene3;
    public Button buttonToLoadScene5;

    void Start()
    {
        // Assuming the scenes are named "Scene1", "Scene2", "Scene3", and "Scene4"
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("IntroScene"));
        if (buttonToLoadScene2 != null)
            buttonToLoadScene2.onClick.AddListener(() => LoadScene("StartPage"));
        if (buttonToLoadScene3 != null)
            buttonToLoadScene3.onClick.AddListener(() => LoadScene("StartPageTenis"));
        if (buttonToLoadScene5 != null)
            buttonToLoadScene5.onClick.AddListener(() => LoadScene("MainMenuScene"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}




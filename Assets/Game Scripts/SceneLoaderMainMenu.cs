using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoaderMainMenu : MonoBehaviour
{
    public Button buttonToLoadScene1;
    public Button buttonToLoadScene2;
    public Button buttonToLoadScene3;
    public Button buttonToLoadScene4;
  

    void Start()
    {
        // Assuming the scenes are named "Scene1", "Scene2", "Scene3", and "Scene4"
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("MapScene"));
        if (buttonToLoadScene2 != null)
            buttonToLoadScene2.onClick.AddListener(() => LoadScene("Scene2"));
        if (buttonToLoadScene3 != null)
            buttonToLoadScene3.onClick.AddListener(() => LoadScene("Scene3"));
        if (buttonToLoadScene4 != null)
            buttonToLoadScene4.onClick.AddListener(() => LoadScene("Scene4"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tenisQuit : MonoBehaviour
{
    public Button buttonToLoadScene1;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("StartPageTenis"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

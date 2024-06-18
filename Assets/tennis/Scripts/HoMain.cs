using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoMain : MonoBehaviour
{
    public Button buttonToLoadScene1;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("StartPageTenis"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

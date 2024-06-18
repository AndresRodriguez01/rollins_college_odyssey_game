using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTennis : MonoBehaviour
{
    public Button buttonToLoadScene1;
    public Button buttonToLoadScene2;
    public Button buttonToLoadScene3;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("SampleScene"));
        if (buttonToLoadScene2 != null)
            buttonToLoadScene2.onClick.AddListener(() => LoadScene("MapScene"));
        if (buttonToLoadScene3 != null)
            buttonToLoadScene3.onClick.AddListener(() => LoadScene("HowToPlayTennis"));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M : MonoBehaviour
{

    public void OnPlayButton()
    {
        SceneManager.LoadScene("game");
    }
    public void OnQuitButton()
    {
        SceneManager.LoadScene("MapScene");
        
        
    }

    public void OnHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

     public void OnMainMenuButton()
    {
        SceneManager.LoadScene("StartPage");
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneScript : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public Button buttonToLoadScene1;
    public Button buttonToLoadScene2;
    // Assign this in the Unity Inspector

    void Start()
    {
        string winner = DetermineWinner();
        winnerText.text = winner;
        if (buttonToLoadScene1 != null)
            buttonToLoadScene1.onClick.AddListener(() => LoadScene("MapScene"));
        if (buttonToLoadScene2 != null)
            buttonToLoadScene2.onClick.AddListener(() => LoadScene("IntroScene"));
    }

    private string DetermineWinner()
    {
        float player1Time = GameManager.Instance.player1Time;
        float player2Time = GameManager.Instance.player2Time;

        if (player1Time < player2Time)
            return "Player 1 Wins!";
        else if (player2Time < player1Time)
            return "Player 2 Wins!";
        else
            return "It's a Tie!";
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}


using UnityEngine;
using UnityEngine.UI; // Required namespace for UI components like Button
using UnityEngine.SceneManagement;

public class TextPagination : MonoBehaviour
{
    public GameObject[] pages;
    public Button nextButton;
    public Button previousButton;
    public Button quitButton;
    private int currentPage = 0;

    public string gameSceneName = "GameScene"; // Replace with your actual game scene name

    void Start()
    {
        if (quitButton != null)
            quitButton.onClick.AddListener(() => LoadScene("MapScene"));

        ShowPage(currentPage);

        // Add listeners to the buttons for click events
        nextButton.onClick.AddListener(ShowNextPage);

        // If you have a previous button, uncomment the following line
         previousButton.onClick.AddListener(ShowPreviousPage);
    }

    public void ShowNextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            // Not on the last page, show the next one
            pages[currentPage].SetActive(false);
            currentPage++;
            pages[currentPage].SetActive(true);
        }
        else
        {
            // On the last page, load the game scene
            SceneManager.LoadScene(gameSceneName);
        }
    }


    public void ShowPreviousPage()
    {
        Debug.Log("Previous button clicked."); // Add this line to debug

        if (currentPage > 0)
        {
            pages[currentPage].SetActive(false);
            currentPage--;
            pages[currentPage].SetActive(true);
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void ShowPage(int pageIndex)
    {
        foreach (var page in pages)
        {
            page.SetActive(false); // Hide all pages
        }
        pages[pageIndex].SetActive(true); // Show the current page
    }
}



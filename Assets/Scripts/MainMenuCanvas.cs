using UnityEngine.UI;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public Canvas mainMenuCanvas,gameCanvas;
    public GameObject gameManager;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.SetActive(false);
        gameCanvas.enabled = false;
    }

    public void PlayGame()
    {
        mainMenuCanvas.enabled = false;
        gameManager.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

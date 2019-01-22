using UnityEngine.UI;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public Canvas mainMenuCanvas,gameCanvas,pauseMenuCanvas;
    public GameObject gameManager;
    public AudioSource[] audioSources;
    public Toggle soundToggle;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.GetComponent<GameManager>().audioSources = audioSources;
        gameManager.SetActive(false);
        gameCanvas.enabled = false;
        pauseMenuCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
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

    public void ChangeVolume()
    {
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.volume = soundToggle.isOn ? 1f : 0f;
        }
        gameManager.GetComponent<GameManager>().isSoundOn=soundToggle.isOn;
    }

}

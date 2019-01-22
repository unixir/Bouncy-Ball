using UnityEngine.UI;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public Canvas mainMenuCanvas,gameCanvas,pauseMenuCanvas;
    public GameObject gameManager;
    public AudioSource[] audioSources;
    public Toggle soundToggle;
    public Animator[] animators;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        animators = GetComponentsInChildren<Animator>();
        gameManager.GetComponent<GameManager>().audioSources = audioSources;
        gameManager.SetActive(false);
        gameCanvas.enabled = false;
        pauseMenuCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        //MenuEnter();
    }
    private void OnEnable()
    {
        MenuEnter();
    }

    private void OnDisable()
    {
        MenuExit();
    }
    public void PlayGame()
    {
        //MenuExit();
        mainMenuCanvas.enabled = false;
        gameManager.SetActive(true);
    }

    void MenuExit()
    {
        foreach(Animator animator in animators)
        {
            animator.SetBool("Visible", false);
        }
    }

    void MenuEnter()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("Visible", true);
        }
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

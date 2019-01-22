using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //public
    public GameObject player, hoopPrefab, iHoop;
    public Slider timeSlider;
    public Image sliderFillArea;
    public TextMeshProUGUI scoreText;
    public Canvas gameCanvas, mainMenuCanvas, pauseCanvas;
    public Button pauseButton;
    //private
    bool modeIsLeft,timerEnabled=false;
    float hoopPosX, hoopPosY, timeDepletionRate = 5f, winTime=50;
    int score;
    AudioSource audioSource;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1f;
        mainMenuCanvas.enabled = false;
        gameCanvas.enabled = true;
        timerEnabled = true;
        pauseButton.enabled = true;
        timeSlider.value = 100;
        StartCoroutine(StartTimer());
        score = 0;
        scoreText.text = score.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
        if (Random.Range(0, 1.1f) >= 0.5f)
            modeIsLeft = true;
        else modeIsLeft = false;
        player.GetComponent<BallControl>().modeLeft = modeIsLeft;
        SpawnHoop();
    }

    private void OnDisable()
    {
        StopCoroutine(StartTimer());
        //player.SetActive(false);
        if(gameCanvas)
        gameCanvas.enabled = false;
        DestroyAllHoops();
        pauseButton.enabled = false;
    }

    IEnumerator StartTimer()
    {
        while (timerEnabled)
        {
            timeSlider.value = timeSlider.value - timeDepletionRate;
            if (timeSlider.value <= 60)
            {
                sliderFillArea.color = Color.yellow;
            }
            if (timeSlider.value <= 20)
            {
                sliderFillArea.color = Color.red;
            }
            else
            {
                sliderFillArea.color = Color.green;
            }
            if (timeSlider.value <= 0)
            {
                ShowMainMenu();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ShowMainMenu()
    {
        gameCanvas.enabled = false;
        pauseCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        this.gameObject.SetActive(false);
        OnDisable();
        DestroyAllHoops();
    }

    void DestroyAllHoops()
    {
        GameObject[] hoops = GameObject.FindGameObjectsWithTag("Hoop");
        foreach(GameObject hoop in hoops)
        {
            Destroy(hoop);
        }
    }
    public void RespawnHoops()
    {
        audioSource.Play();
        timeSlider.value += winTime;
        ++score;
        scoreText.text = score.ToString();
        Destroy(iHoop);
        SpawnHoop();
        modeIsLeft = !modeIsLeft;
        player.GetComponent<BallControl>().modeLeft = !modeIsLeft;
    }

    void SpawnHoop()
    {
        hoopPosX = modeIsLeft ? -1.8f : 1.8f;
        hoopPosY = Random.Range(-1f, 4.1f);
        iHoop = Instantiate(hoopPrefab, new Vector2(hoopPosX, hoopPosY), Quaternion.Euler(80f, 0f, 0f));
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        gameCanvas.enabled = true;
        pauseCanvas.enabled = false;
    }
}

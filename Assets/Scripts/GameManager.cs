using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject player, hoopPrefab, iHoop;
    public Slider timeSlider;
    public TextMeshProUGUI scoreText;
    public bool modeIsLeft,timerEnabled=false;
    public float hoopPosX, hoopPosY, timeDepletionRate = 5f, winTime=50;
    int score;
    void Start()
    {
        timerEnabled = true;
        StartCoroutine(StartTimer());
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        if (Random.Range(0, 0.5f) >= 0.5f)
        {
            modeIsLeft = true;
        }
        else modeIsLeft = false;
        player.GetComponent<BallControl>().modeLeft = modeIsLeft;
        SpawnHoop();
        
        timerEnabled = true;
    }

    IEnumerator StartTimer()
    {
        while (timerEnabled)
        {
            //Debug.Log("Timer");
            timeSlider.value = timeSlider.value - timeDepletionRate;
            if (timeSlider.value <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void RespawnHoops()
    {
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

    
}

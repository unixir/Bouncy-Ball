using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHoop : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager= GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponentInParent<FirstHoop>().firstHoop)
        {
            gameManager.RespawnHoops();
        }
    }
}

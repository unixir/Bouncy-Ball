using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstHoop : MonoBehaviour
{
    public bool firstHoop = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        firstHoop = true;
    }
}

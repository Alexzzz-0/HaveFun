using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    private int count = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            if (count >= 2)
            {
                GameManager.instance.Win();
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            count--;
            if (count < 0)
            {
                count = 0;
            }
        }
    }
}

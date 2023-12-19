using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounusTwo : MonoBehaviour
{
    public bool yes = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            yes = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            yes = false;
        }
    }
}

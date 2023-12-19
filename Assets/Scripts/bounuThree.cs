using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounuThree : MonoBehaviour
{
    [SerializeField] private BounusTwo theother;
    public int index;
    private bool yes = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            yes = true;
            if (yes && theother.yes)
            {
                GameManager.instance.CheckBoth(index);
                gameObject.SetActive(false);
                theother.gameObject.SetActive(false);
            }
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

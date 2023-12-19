using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusNormal : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA") || other.gameObject.CompareTag("playerB"))
        {
            gameObject.SetActive(false);
        }
    }
}

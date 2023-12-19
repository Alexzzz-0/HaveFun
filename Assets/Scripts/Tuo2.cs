using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuo2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA") || other.gameObject.CompareTag("playerB"))
        {
            SceneManager.LoadScene(2);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private Transform playerA;
    [SerializeField] private Transform playerB;
    private float timer = 0;
    private float maxTimer = 0.5f;
    private bool A;
    private bool B;
    private bool Afire;
    private bool Bfire;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA"))
        {
            A = true;
        }

        if (other.gameObject.CompareTag("playerB"))
        {
            B = true;
        }
    }

    private void Update()
    {
        if (A && B)
        {
            SceneManager.LoadScene(1);
        }

        if (playerA.position.x > 23f && playerA.position.x < 33f)
        {
            Afire = true;
        }
        else
        {
            Afire = false;
        }

        if (playerB.position.x > 24f && playerB.position.x < 32f)
        {
            Bfire = true;
        }
        else
        {
            Bfire = false;
        }

        if (Afire || Bfire)
        {
            fire.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(index);
            }
        }
        else
        {
            fire.SetActive(false);
        }
    }
}

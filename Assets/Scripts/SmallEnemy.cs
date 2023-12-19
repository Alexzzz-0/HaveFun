using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    [SerializeField] private TextMeshPro score;
    private Vector3 newPos;
    private int scoreNum;
    void Start()
    {
        // transform.position = new Vector3(14f, 1, 0);
        // transform.DOMoveX(-14f, 5f).SetLoops(-1);

        transform.position = new Vector3(-2.8f, 1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.CompareTag("slice"))
        // {
        //     gameObject.SetActive(false);
        // }

        // if (other.gameObject.CompareTag("playerA") || (other.gameObject.CompareTag("playerB")))
        // {
        //     other.gameObject.SetActive(false);
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("slice"))
        {
            scoreNum++;
            score.text = scoreNum.ToString();
            switch (scoreNum)
            {
                case 1:
                    newPos = new Vector3(3f, 3f);
                    transform.position = newPos;
                    break;
                case 2:
                    newPos = new Vector3(-6f, 6f);
                    transform.position = newPos;
                    break;
                case 3:
                    newPos = new Vector3(-10f, 1f);
                    transform.position = newPos;
                    break;
                case 4:
                    newPos = new Vector3(10f, 3f);
                    transform.position = newPos;
                    break;
                case 5:
                    newPos = new Vector3(4f, 3f);
                    transform.position = newPos;
                    transform.localScale = new Vector3(5f, 1f, 1f);
                    break;
                
            }
            //gameObject.SetActive(false);
        }
    }
}

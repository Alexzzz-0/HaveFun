using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class bonusCollect : MonoBehaviour
{
    [SerializeField] private TextMeshPro mark;
    public int index;
    private bool floating = false;
    private Tween horizontal;
    private void Start()
    {
        gameObject.transform.position = new Vector3(4.02f, 1.36f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA")||other.gameObject.CompareTag("playerB"))
        {
            index++;
            mark.text = index.ToString();
            //GameManager.instance.NewLevel(index);
            //gameObject.SetActive(false);
            switch (index)
            {
                case 1:
                    transform.position = new Vector3(-5.57f,1.36f);
                    break;
                case 2:
                    transform.position = new Vector3(1f,1.36f);
                    break;
                case 3:
                    transform.position = new Vector3(6f,1.36f);
                    break;
                case 4:
                    transform.position = new Vector3(20f,1.36f);
                    break;
                case 5:
                    gameObject.SetActive(false);
                    break;
                // case 5:
                //     DOTween.KillAll();
                //     Vector3 newPos = transform.position;
                //     newPos.y = 0f;
                //     newPos.x = 10f;
                //     transform.position = newPos;
                //     transform.DOMoveY(13f, 4f).SetLoops(-1);
                //     break;
                // case 6:
                //     transform.DOMoveX(10f, 3f).SetLoops(-1);
                //     break;
                // case 10:
                //     DOTween.KillAll(gameObject);
                //     break;
                // case 13:
                //     transform.DOMoveY(13f, 4f).SetLoops(-1);
                //     break;
            }
        }

        
    }
    
}

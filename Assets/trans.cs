using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trans : MonoBehaviour
{
    [SerializeField] private GameObject solidGround;
    [SerializeField] private Transform playerA;
    [SerializeField] private Transform playerB;
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("playerA") )
        {
            solidGround.SetActive(true);
            solidGround.transform.localScale = new Vector3(3, 1, 1);
            solidGround.transform.position = playerA.position + new Vector3(0, -1f, 0);
            GameObject newObj = Instantiate(solidGround);
            newObj.transform.position = playerB.position + new Vector3(0, -1f, 0);

            transform.position = playerB.position + new Vector3(0, 7f, 0);
        }

        if (other.CompareTag("playerB"))
        {
            solidGround.SetActive(true);
            solidGround.transform.localScale = new Vector3(3, 1, 1);
            solidGround.transform.position = playerA.position + new Vector3(0, -1f, 0);
            GameObject newObj = Instantiate(solidGround);
            newObj.transform.position = playerB.position + new Vector3(0, -1f, 0);
            
            transform.position = playerA.position + new Vector3(0, 7f, 0);
        }
    }
}

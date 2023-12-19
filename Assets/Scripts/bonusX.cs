using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusX : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            gameObject.SetActive(false);
            TestSceneManager.instance.SpawnMonster();
        }
    }
}

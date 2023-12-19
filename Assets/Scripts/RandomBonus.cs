using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBonus : MonoBehaviour
{
    public int index;
    public string tag;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            ArcadeManager.instance.RandomNew(index);
        }
    }
}

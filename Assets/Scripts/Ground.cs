using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA"))
        {
            PlatformPlayer.instance.jumpA = true;
        }

        if (other.gameObject.CompareTag("playerB"))
        {
            PlatformPlayer.instance.jumpB = true;
        }
    }
}

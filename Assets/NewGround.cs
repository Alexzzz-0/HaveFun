using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGround : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("playerA"))
        {
            Contrast.instance.jumpA = true;
        }

        if (other.gameObject.CompareTag("playerB"))
        {
            Contrast.instance.jumpB = true;
        }
    }
}

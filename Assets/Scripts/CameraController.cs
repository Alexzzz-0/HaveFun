using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerA;
    [SerializeField] private Transform playerB;
    [SerializeField] private Transform slice;

    private LineRenderer lr;
    private Vector3 newPos;
    private Vector3 gap1;
    private Vector3 gap2;
    private float distance;
    private float currentDis;

    public static CameraController instance;

    private void Start()
    {
        instance = this;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 3;
        distance = Vector3.Distance(playerA.position, playerB.position);
    }

    public void Camera()
    {
        
        newPos = transform.position;
        if (playerA.position.y > playerB.position.y)
        {
            newPos.y = playerA.position.y ;
        }
        else
        {
            newPos.y = playerB.position.y;
        }

        newPos.x = (playerA.position.x + playerB.position.x) / 2f;
        
        transform.position = newPos;


        currentDis = Vector3.Distance(playerA.position, playerB.position);
        // if (currentDis < distance)
        // {
        //     lr.startColor = Color.red;
        //     lr.endColor = Color.red;
        // }
        // else
        // {
        //     lr.startColor = Color.cyan;
        //     lr.endColor = Color.cyan;
        // }
        lr.SetPosition(0,playerA.position);
        // gap1 = Vector3.Lerp(playerA.position, playerB.position, 0.5f);
        // lr.SetPosition(1,gap1);
        
        lr.SetPosition(1,slice.position);
        lr.SetPosition(2,playerB.position);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ArcadeManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerA;
    [SerializeField] private PlayerController playerB;
    [SerializeField] private CameraController camera;
    [SerializeField] private GameObject Aobject;
    [SerializeField] private GameObject Bobject;
    [SerializeField] private TextMeshPro score;
    

    public static ArcadeManager instance;
    private float timer = 4f;
    private float timerSet = 8f;
    private int scoreNum;
    private bool locked = true;
    private bool A;
    private bool B;
    

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 Apos = playerA.transform.position;
            playerA.transform.position = playerB.transform.position;
            playerB.transform.position = Apos;
        }
        playerA.Player();
        playerB.Player();
        camera.Camera();

        timer += Time.deltaTime;
        if (timer > timerSet)
        {
            timer = 0;
            Aobject.transform.position = new Vector3(Random.Range(-5f,8f),Random.Range(0,6f));
            Bobject.transform.position = new Vector3(Random.Range(-5f, 8f), Random.Range(0, 6f));

            score.text = null;
            A = false;
            B = false;
        }

        if (A && B)
        {
            score.text = "WIN";
            score.color = Color.red;
        }

    }

    public void RandomNew(int index)
    {
        if (index == 0)
        {
            Aobject.transform.position = new Vector3(Random.Range(-5f,8f),Random.Range(0,6f));
            score.text += " Y";
            A = true;
        }

        if (index == 1)
        {
            Bobject.transform.position = new Vector3(Random.Range(-5f, 8f), Random.Range(0, 6f));
            score.text += "B";
            B = true;
        }

        
    }
}

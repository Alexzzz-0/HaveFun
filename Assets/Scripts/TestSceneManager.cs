using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerA;
    [SerializeField] private PlayerController playerB;
    [SerializeField] private CameraController camera;
    [SerializeField] private GameObject monster;

    public static TestSceneManager instance;
    private bool locked = true;

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
        playerA.Player();
        playerB.Player();
        camera.Camera();

        if (locked)
        {
            monster.transform.position = new Vector3(-6.85f, 0);
        }
        
    }

    public void SpawnMonster()
    {
        locked = false;
    }
    
    
}

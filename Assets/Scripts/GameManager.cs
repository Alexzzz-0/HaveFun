using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerA;
    [SerializeField] private PlayerController playerB;
    [SerializeField] private CameraController camera;
    [SerializeField] private GameObject winFX;

    public static GameManager instance;
    public int currentLevel = 3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
        winFX.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("reload");
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (currentLevel)
            {
                case 0:
                    playerA.gameObject.transform.position = new Vector3(4f, 0, 0);
                    playerB.gameObject.transform.position = new Vector3(-0.67f, 0, 0);
                    break;
                case 1:
                    playerA.gameObject.transform.position = new Vector3(-4.2f, 15.34f, 0);
                    playerB.gameObject.transform.position = new Vector3(-8.26f, 15.34f, 0);
                    break;
                case 2:
                    playerA.gameObject.transform.position = new Vector3(6.59f, 24.49f, 0);
                    playerB.gameObject.transform.position = new Vector3(2.515f, 24.49f, 0);
                    break;
                case 3:
                    playerA.gameObject.transform.position = new Vector3(2.86f, 28.6f, 0);
                    playerB.gameObject.transform.position = new Vector3(-1.215f, 28.6f, 0);
                    break;
                case 4:
                    playerA.gameObject.transform.position = new Vector3(2.86f, 28.6f, 0);
                    playerB.gameObject.transform.position = new Vector3(-1.215f, 28.6f, 0);
                    break;
                case 5:
                    playerA.gameObject.transform.position = new Vector3(2.86f, 28.6f, 0);
                    playerB.gameObject.transform.position = new Vector3(-1.215f, 28.6f, 0);
                    break;
            }
        }
        
        playerA.Player();
        playerB.Player();
        camera.Camera();
    }

    public void NewLevel(int level)
    {
        currentLevel = level;
        
    }

    public void CheckBoth(int level)
    {
        currentLevel = level;
    }

    public void Win()
    {
        if (currentLevel == 5)
        {
            winFX.SetActive(true);
            
            Invoke("Reload",1f);
        }
    }

    private void Reload()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}

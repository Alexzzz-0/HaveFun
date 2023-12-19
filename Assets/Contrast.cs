using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contrast : MonoBehaviour
{
    [SerializeField] private GameObject playerA;
    [SerializeField] private GameObject playerB;
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject slice;
    [SerializeField] private LineRenderer Aforce;
    [SerializeField] private LineRenderer Bforce;
    [SerializeField] private LineRenderer Amax;
    [SerializeField] private LineRenderer Bmax;
    private GameObject pressedObject;
    private KeyCode pressedCode;
    private Vector3 slicePos;
    private Vector3 pressedSpeed;
    private float pressedTimer;
    private float maxTime = 1f;
    private float distance;
    private float maxDis = 25f;
    private float currentMax;
    private float maxHeight = 16f;
    private float timerA;
    private float timerB;
    private float speed = 50f;
    private float Hspeed = 5f;
    private float heightTotal;
    private bool moveA = true;
    private bool moveB = true;
    public bool jumpA = true;
    public bool jumpB = true;

    private Rigidbody Arb;
    private Rigidbody Brb;

    public static Contrast instance;

    private enum GameState
    {
        control,
        accecelerate
    }

    private GameState _gameState = GameState.control;
    private void Start()
    {
        Arb = playerA.GetComponent<Rigidbody>();
        Brb = playerB.GetComponent<Rigidbody>();

        instance = this;
    }

    void Update()
    {
        switch (_gameState)
        {
            case GameState.control:
                Arb.velocity *= 0.997f;
                Brb.velocity *= 0.997f;

                heightTotal = playerA.transform.position.y + playerB.transform.position.y;
                
                if (moveA)
                {
                    line.endColor = Color.blue;
                    line.startColor = Color.blue;
                    
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        // _gameState = GameState.accecelerate;
                        // pressedCode = KeyCode.A;
                        // pressedObject = playerA;
                        Arb.velocity = Vector3.left * heightTotal * Hspeed; 
                        moveA = false;
                        moveB = true;
                    }
                    // else if (Input.GetKeyDown(KeyCode.S))
                    // {
                    //     Arb.velocity = Vector3.down * speed;
                    //      moveA = false;
                    //      moveB = true;
                    //  }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        // _gameState = GameState.accecelerate;
                        // pressedObject = playerA;
                        // pressedCode = KeyCode.D;
                        Arb.velocity = Vector3.right * heightTotal * Hspeed;
                        moveA = false;
                        moveB = true;
                    } else if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (jumpA)
                        {
                            Arb.velocity = Vector3.up * speed; 
                            moveA = false;
                            moveB = true;
                            jumpA = false;
                        }
                        
                    }
                }
                
                if (moveB)
                {
                    line.endColor = Color.yellow;
                    line.startColor = Color.yellow;
                    
                    // if (Input.GetKeyDown(KeyCode.DownArrow))
                    // {
                    //     Brb.velocity = Vector3.down * speed;
                    //     moveA = true;
                    //     moveB = false;
                    // }else 
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        // _gameState = GameState.accecelerate;
                        // pressedObject = playerB;
                        // pressedCode = KeyCode.LeftArrow;
                        Brb.velocity = Vector3.left * heightTotal * Hspeed; 
                        moveA = true;
                        moveB = false;
                    }else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        // _gameState = GameState.accecelerate;
                        // pressedObject = playerB;
                        // pressedCode = KeyCode.RightArrow;
                        Brb.velocity = Vector3.right * heightTotal * Hspeed; 
                        moveA = true;
                        moveB = false;
                    }else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (jumpB)
                        {
                            Brb.velocity = Vector3.up * speed; 
                            moveA = true;
                            moveB = false;
                            jumpB = false;
                        }
                    }
                }
                
                
                break;
            case GameState.accecelerate:
                //to indicate that the mode is accecelerating
                // line.endColor = Color.red;
                // line.startColor = Color.red;
                Aforce.gameObject.SetActive(true);
                Bforce.gameObject.SetActive(true);
                Amax.gameObject.SetActive(true);
                Bmax.gameObject.SetActive(true);
                
                //stable things
                Arb.useGravity = false;
                Brb.useGravity = false;
                Arb.velocity = Vector3.zero;
                Brb.velocity = Vector3.zero;
                
                //
                pressedTimer += Time.deltaTime;
                if (pressedTimer > maxTime)
                {
                    pressedTimer = 0;
                }
                
                //
                if (Input.GetKeyUp(pressedCode))
                {
                    _gameState = GameState.control;
                    pressedTimer = 0;
                    currentMax = 0;
                    distance = 0;
                    Aforce.gameObject.SetActive(false);
                    Bforce.gameObject.SetActive(false);
                    Amax.gameObject.SetActive(false);
                    Bmax.gameObject.SetActive(false);
                    Arb.useGravity = true;
                    Brb.useGravity = true;
                    
                    pressedObject.GetComponent<Rigidbody>().velocity = pressedSpeed;
                }
                //
                switch (pressedCode)
                {
                    case KeyCode.A:
                        currentMax = playerA.transform.position.y / maxHeight * maxDis;
                        Amax.SetPosition(0,playerA.transform.position);
                        Amax.SetPosition(1,new Vector3(playerA.transform.position.x - currentMax,playerA.transform.position.y, playerA.transform.position.z));
                        distance = pressedTimer / maxTime * currentMax;
                        Aforce.SetPosition(0,playerA.transform.position);
                        Aforce.SetPosition(1,new Vector3(playerA.transform.position.x - distance,playerA.transform.position.y, playerA.transform.position.z));
                        pressedSpeed = new Vector3(-Hspeed * distance,0,0);
                        break;
                    case KeyCode.D:
                        currentMax = playerA.transform.position.y / maxHeight * maxDis;
                        Amax.SetPosition(0,playerA.transform.position);
                        Amax.SetPosition(1,new Vector3(playerA.transform.position.x + currentMax,playerA.transform.position.y, playerA.transform.position.z));
                        distance = pressedTimer / maxTime * currentMax;
                        Aforce.SetPosition(0,playerA.transform.position);
                        Aforce.SetPosition(1,new Vector3(playerA.transform.position.x + distance,playerA.transform.position.y, playerA.transform.position.z));
                        pressedSpeed = new Vector3(Hspeed * distance,0,0);
                        break;
                    case KeyCode.RightArrow:
                        currentMax = playerB.transform.position.y / maxHeight * maxDis;
                        Amax.SetPosition(0,playerB.transform.position);
                        Amax.SetPosition(1,new Vector3(playerB.transform.position.x + currentMax,playerB.transform.position.y, playerB.transform.position.z));
                        distance = pressedTimer / maxTime * currentMax;
                        Bforce.SetPosition(0,playerB.transform.position);
                        Bforce.SetPosition(1,new Vector3(playerB.transform.position.x + distance,playerB.transform.position.y, playerB.transform.position.z));
                        pressedSpeed = new Vector3(Hspeed * distance,0,0);
                        break;
                    case KeyCode.LeftArrow:
                        currentMax = playerB.transform.position.y / maxHeight * maxDis;
                        Amax.SetPosition(0,playerB.transform.position);
                        Amax.SetPosition(1,new Vector3(playerB.transform.position.x - currentMax,playerB.transform.position.y, playerB.transform.position.z));
                        distance = pressedTimer / maxTime * currentMax;
                        Bforce.SetPosition(0,playerB.transform.position);
                        Bforce.SetPosition(1,new Vector3(playerB.transform.position.x - distance,playerB.transform.position.y, playerB.transform.position.z));
                        pressedSpeed = new Vector3(-Hspeed * distance,0,0);
                        break;
                }
                
                
                break;
        }
        
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
        
        CameraController.instance.Camera();

        //SliceControl();
    }

    void SliceControl()
    {
        slicePos = (playerA.transform.position + playerB.transform.position) / 2;
        slice.transform.position = slicePos;

        slice.transform.localScale = new Vector3(Mathf.Abs(playerA.transform.position.x - playerB.transform.position.x) -1, 0.5f, 0.5f);
    }
}

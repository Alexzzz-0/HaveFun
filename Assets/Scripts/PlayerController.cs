using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private TextMeshPro count;

    private MeshRenderer mesh;
    
    private Rigidbody rb;
    private float speed = 10f;
    private float timer;
    private float coolTimer;
    private bool overwhelmed;
    private Color initColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        initColor = mesh.material.color;
    }

    public void Player()
    {
        if (!overwhelmed)
        {
            if (Input.GetKey(up))
            {
                timer += Time.deltaTime * 10f;
            
                rb.velocity = Vector3.up * speed;
            }else if (Input.GetKey(down))
            {
                timer += Time.deltaTime * 10f;
            
                rb.velocity = Vector3.down * speed;
            }else

            if (Input.GetKey(right))
            {
                timer += Time.deltaTime * 10f;
            
                rb.velocity = Vector3.right * speed;
            }else if (Input.GetKey(left))
            {
                timer += Time.deltaTime * 10f;
            
                rb.velocity = Vector3.left * speed;
            }

            mesh.material.color = initColor;
        }
        if (Input.GetKeyUp(up)||Input.GetKeyUp(down)|| Input.GetKeyUp(left)|| Input.GetKeyUp(right))
        {
            timer = 0;
            overwhelmed = true;
        }
        
        rb.velocity *= 0.997f;
        
        if (overwhelmed)
        {
            coolTimer += Time.deltaTime;

            if (coolTimer > 3f)
            {
                Debug.Log(gameObject.name);
                overwhelmed = false;
                coolTimer = 0;
            }
            
            mesh.material.color = Color.gray;

            count.text = (3f - coolTimer).ToString("f0");
        }
    }
}

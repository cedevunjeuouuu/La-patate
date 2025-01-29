using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform checkSol;
    private float rayonSol = 0.3f;
    [SerializeField] private LayerMask sol;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(checkSol.position, rayonSol, sol);
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0,250));
        }
        
        
        if (x > 0)
        {
            transform.Translate(x * moveSpeed * Time.deltaTime,0,0);
            transform.eulerAngles = new Vector2(0,0);
        }
        
        if (x < 0)
        {
            transform.Translate(-x * moveSpeed * Time.deltaTime,0,0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    } 
}

using System;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    
    private Transform alliePos;
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed = 2f;
    
    
    void Start()
    {
        alliePos = GameObject.FindWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        rb.velocity = new Vector2(alliePos.position.x - gameObject.transform.position.x,
            alliePos.position.y - gameObject.transform.position.y) * movementSpeed;
    }
}

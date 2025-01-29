using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpHigh;
    
    void Update()
    {
        if (Input.GetKey("d"))
        {
            Vector3 direction = new Vector3(1,0,0);
            direction = direction.normalized;
            GetComponent<Rigidbody2D>().linearVelocity= direction * moveSpeed;
        }
        if (Input.GetKey("q"))
        {
            Vector3 direction = new Vector3(-1,0,0);
            direction = direction.normalized;
            GetComponent<Rigidbody2D>().linearVelocity= direction * moveSpeed;
        }
        if (Input.GetKeyDown("space"))
        {
            Vector3 direction = new Vector3(0,jumpHigh,0);
            GetComponent<Rigidbody2D>().linearVelocity= direction * moveSpeed;
        }
    } 
}

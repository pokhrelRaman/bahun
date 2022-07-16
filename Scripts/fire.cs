using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 bulletdirection;
    public float fireSpeed;
    public Rigidbody2D rb;

   
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.x += 
        rb.velocity += bulletdirection * fireSpeed;
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}

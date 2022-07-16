using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 bulletdirection2;
    public float fireSpeed;
    public Rigidbody2D rb;


    void FixedUpdate()
    {
        rb.velocity += bulletdirection2 * fireSpeed;
       // rb.velocity = bulletdirection2;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        print(col.gameObject.name);
        if(col.gameObject.name == "Player")
        {
            PlayerMovement.instance.playerHealth();
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Enemy")
        {
            enemyfire.instance.enemyHealth();
            Destroy(gameObject);
        }


    }
}

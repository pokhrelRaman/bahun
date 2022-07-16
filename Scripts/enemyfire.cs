using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfire : MonoBehaviour
{
    public GameObject defaultShot,particle;
    public Transform firepoint;
    private float currentTime;
    int health;
    public static enemyfire instance;

     void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 2f) {
            GameObject bullet =   Instantiate(defaultShot, firepoint.position, transform.rotation);
            Destroy(bullet, 0.1f);
            currentTime = 0;
        }



    }



    public void enemyHealth()
    {
        health -= 10;
        particle.SetActive(true);
        Invoke("disable", 1f);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void disable()
    {
        particle.SetActive(false);    
    }













}

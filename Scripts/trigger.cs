using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject food;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes");
        Instantiate(food, new Vector2(-255f,-98f), transform.rotation);
    }
}


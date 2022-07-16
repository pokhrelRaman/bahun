using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smootfactor;

  

    // Update is called once per frame
    void Update()
    {
        follow();
    }
    void follow()
    {
        Vector3 targetposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, target.position, smootfactor * Time.deltaTime);
        transform.position = targetposition;
    }
}

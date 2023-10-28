using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D other) 
    {
        Debug.Log("Collision with object");
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Whattt??");
    }
}

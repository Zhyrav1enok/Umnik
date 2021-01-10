using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject particles;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}

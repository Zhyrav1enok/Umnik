using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    public Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.worldCamera = other.gameObject.GetComponentInChildren<Camera>();
        }
    }
}

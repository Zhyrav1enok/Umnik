using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasItemInfo : MonoBehaviour
{
    private Transform player;
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 targetPoint = player.position;
        //targetPoint.y *= -1;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        targetRotation.x = transform.rotation.x;
        targetRotation.z = transform.rotation.z;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }
}

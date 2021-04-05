using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelTwo
{
    public class TabletCamera : MonoBehaviour
    {
        public Camera tabletCamera;

        void Update()
        {
            RaycastHit hit;
            
            if (Physics.Raycast(tabletCamera.transform.position, tabletCamera.transform.forward, out hit)) 
            {
                if (hit.transform.gameObject.CompareTag("Element"))
                {
                    
                }
            }
        }
    }
}

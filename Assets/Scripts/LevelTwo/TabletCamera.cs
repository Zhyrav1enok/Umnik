using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelTwo
{
    public class TabletCamera : MonoBehaviour
    {
        public GameController gameController;
        public Camera tabletCamera;
        public Slider slider;

        void Update()
        {
            RaycastHit hit;
            
            if (Physics.Raycast(tabletCamera.transform.position, tabletCamera.transform.forward, out hit)) 
            {
                if (hit.transform.gameObject.CompareTag("Element"))
                {
                    slider.value += 1f;
                    if (slider.value == 100)
                    {
                        Destroy(hit.transform.gameObject);
                        gameController.Win();
                    }
                }
            }
            
        }
    }
}

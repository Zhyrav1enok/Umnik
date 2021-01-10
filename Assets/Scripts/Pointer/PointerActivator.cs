    using System;
    using UnityEngine;
    using Valve.VR;

    public class PointerActivator : MonoBehaviour
    {
        public GameObject pointer;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("UI"))
            {
                pointer.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("UI"))
            {
                pointer.SetActive(false);
            }
        }
    }
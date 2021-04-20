using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelFour
{
    public class MetalTrigger : MonoBehaviour
    {
        public GameController gameController;

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Element"))
            {
                gameController.StartGame();
                Destroy(other.gameObject);
            }    
        }
    }
}

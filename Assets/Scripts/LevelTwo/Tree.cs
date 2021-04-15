using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelTwo
{
    public class Tree : MonoBehaviour
    {
        private GameController gameController;

        private void Start() 
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
       
        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Element"))
            {
                gameController.ElementConnection();
                Destroy(other.gameObject);
            }
        }
    }
}

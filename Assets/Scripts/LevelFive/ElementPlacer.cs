using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelFive
{
    public class ElementPlacer : MonoBehaviour
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
                gameController.StartGame();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

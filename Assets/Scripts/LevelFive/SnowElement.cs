using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelFive
{
    public class SnowElement : MonoBehaviour
    {
        private GameController gameController;

        private void Start() 
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Drill"))
            {
                if (gameController.countElements > 1)
                    gameController.countElements--;
                else
                {
                    gameController.countElements--;
                    gameController.Win();
                }
                Destroy(gameObject);
            }
        }
    }
}

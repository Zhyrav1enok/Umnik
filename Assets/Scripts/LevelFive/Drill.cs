using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelFive
{
    public class Drill : MonoBehaviour
    {
        public GameController gameController;

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Earth"))
            {
                gameController.Lose();
                //Destroy(other.gameObject.transform.parent.gameObject);
            }    
        }
    }
}

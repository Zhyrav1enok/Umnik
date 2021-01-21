using System;
using UnityEngine;

namespace LevelOne
{
    public class PlaceCrystal : MonoBehaviour
    {
        public GameObject gameController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Crystal"))
            {
                gameController.GetComponent<CrystalManager>().enabled = true;
                gameController.GetComponent<GameController>().BotFly2();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelTwo
{
    public class GameController : MonoBehaviour
    {
        #region Variabless
        [Header("Player")]
        public GameObject winUI;
        public GameObject loseUI;
        public GameObject pointer;
        public GameObject tablet;
        public GameObject player;
        

        [Header("PlayerUI")] 
        public List<GameObject> missions = new List<GameObject>();
        public GameObject playerCanvas;
        public int currentMission = 0;

        [Header("Drone")]
        public GameObject drone;
        #endregion
        void Start()
        {
            pointer.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
            tablet.SetActive(false);
        }

        void Update()
        {
        
        }

        // -----------------------Tablet game session-----------------------
        IEnumerator ElementLife()
        {
            // TODO: создание и распределение элемента по дереву
            yield return null;
        }


        // -----------------------Activate tablets on drone and player-----------------------
        public void ElementConnection()
        {
            drone.transform.Find("Tablet").gameObject.SetActive(true);
        }

        public void TabletActivationOnPlayer()
        {
            tablet.SetActive(true);
            StartCoroutine(ElementLife());
        }


        // -----------------------Activate UI with win or lose-----------------------
        public void Win()
        {
            pointer.SetActive(true);
            winUI.SetActive(true);
            tablet.SetActive(false);
            playerCanvas.SetActive(false);
        }

        public void Lose()
        {
            pointer.SetActive(true);
            loseUI.SetActive(true);
            tablet.SetActive(false);
            playerCanvas.SetActive(false);
        }
    }
}

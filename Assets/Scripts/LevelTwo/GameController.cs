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

        public void ElementConnection()
        {
            drone.transform.Find("Tablet").gameObject.SetActive(true);
        }

        public void TabletActivationOnPlayer()
        {
            tablet.SetActive(true);
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


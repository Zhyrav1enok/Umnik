using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelThree
{
    public class GameController : MonoBehaviour
    {
        #region Variabless
        [Header("Player")]
        public GameObject winUI;
        public GameObject loseUI;
        public GameObject pointer;
        public GameObject player;


        [Header("PlayerUI")]
        public List<GameObject> missions = new List<GameObject>();
        public GameObject playerCanvas;
        //public Text textTimer;

        public int currentMission = 0;

        public Material waterMaterial;

        [Header("Drone")]
        public GameObject drone;

        #endregion

        void Start()
        {
            pointer.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
        }

        void Update()
        {

        }

        public void NextMission()
        {
            missions[currentMission].SetActive(false);
            currentMission++;
            missions[currentMission].SetActive(true);
        }

        // -----------------------Game session-----------------------


        // -----------------------Activate UI with win or lose-----------------------
        public void Win()
        {
            StopAllCoroutines();
            pointer.SetActive(true);
            winUI.SetActive(true);
            //tablet.SetActive(false);
            playerCanvas.SetActive(false);
        }

        public void Lose()
        {
            pointer.SetActive(true);
            loseUI.SetActive(true);
            //tablet.SetActive(false);
            playerCanvas.SetActive(false);
        }

        public void GoToMenu()
        {
            Destroy(player);
            SceneManager.LoadScene("Main menu");
        }

        private void OnDestroy()
        {
            missions.Clear();
            StopAllCoroutines();
        }
    }
}
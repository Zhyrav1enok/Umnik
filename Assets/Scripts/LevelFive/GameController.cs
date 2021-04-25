using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LevelFive
{
    public class GameController : MonoBehaviour
    {
        #region Variabless
        [Header("Player")]
        public GameObject winUI;
        public GameObject loseUI;
        public GameObject pointer;
        public GameObject element;
        public GameObject player;


        [Header("PlayerUI")]
        public List<GameObject> missions = new List<GameObject>();
        public GameObject playerCanvas;
        public Text textTimer;

        public int currentMission = 0;

        //public Material metal;

        [Header("Drone")]
        public GameObject elementOnDrone;

        public float delayOfGame = 60f;

        #endregion

        void Start()
        {
            pointer.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
            element.SetActive(false);
        }

        public void NextMission()
        {            
            missions[currentMission].SetActive(false);
            currentMission++;
            missions[currentMission].SetActive(true);   
        }

        public void StartGame()
        {
            StartCoroutine(Game());
            NextMission();
        }

        public void PickUpElement()
        {
            NextMission();
            Destroy(elementOnDrone);
            element.SetActive(true);
        }

        // -----------------------Game session-----------------------
        private IEnumerator Game()
        {
            

            textTimer.gameObject.SetActive(true);
            float stopTime = Time.time + delayOfGame;
            while (Time.time < stopTime)
            {
                textTimer.text = "ТАЙМЕР: " + (int)(stopTime - Time.time);

                yield return new WaitForSeconds(1f);
            }
            
            Lose();
        }

        // -----------------------Activate UI with win or lose-----------------------
        public void Win()
        {
            StopAllCoroutines();
            pointer.SetActive(true);
            winUI.SetActive(true);
            playerCanvas.SetActive(false);
        }

        public void Lose()
        {
            StopAllCoroutines();
            pointer.SetActive(true);
            loseUI.SetActive(true);
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

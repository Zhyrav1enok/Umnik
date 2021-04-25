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
        public GameObject drill;
        public GameObject player;


        [Header("PlayerUI")]
        public List<GameObject> missions = new List<GameObject>();
        public int currentMission = 0;
        public GameObject playerCanvas;
        public Text textTimer;


        [Header("Drone")]
        public GameObject elementOnDrone;
        public GameObject drillOnDrone;
        public float delayOfGame = 60f;


        [Header("Element")]
        public GameObject snowPrefab;
        public List<Transform> SpawnPoints = new List<Transform>();
        [HideInInspector] public int countElements;

        #endregion

        void Start()
        {
            pointer.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
            element.SetActive(false);
            drill.SetActive(false);
            drillOnDrone.SetActive(false);
            countElements = SpawnPoints.Count;
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
            drillOnDrone.SetActive(true);
            NextMission();
        }

        public void PickUpElement()
        {
            NextMission();
            Destroy(elementOnDrone);
            element.SetActive(true);
        }

        public void PickUpDrill()
        {
            NextMission();
            Destroy(drillOnDrone);
            drill.SetActive(true);
        }

        // -----------------------Game session-----------------------
        private IEnumerator Game()
        {
            for (int i = 0; i < SpawnPoints.Count; i++)
            {
                Instantiate(snowPrefab, SpawnPoints[i].position, Quaternion.identity);
            }

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
            drill.SetActive(false);
        }

        public void Lose()
        {
            StopAllCoroutines();
            pointer.SetActive(true);
            loseUI.SetActive(true);
            playerCanvas.SetActive(false);
            drill.SetActive(false);
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

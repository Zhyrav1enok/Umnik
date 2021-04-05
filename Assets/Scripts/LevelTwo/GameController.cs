using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        public Text textTimer;

        public int currentMission = 0;

        [Header("Drone")]
        public GameObject drone;

        [Header("SpawnPointsElement")]
        public List<Transform> spawnPoints = new List<Transform>();
        public GameObject instanceElement;
        public float delayOfSearch = 30f;
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

        public void NextMission()
        {
            missions[currentMission].SetActive(false);
            currentMission++;
            missions[currentMission].SetActive(true);
        }

        // -----------------------Tablet game session-----------------------
        IEnumerator ElementLife()
        {
            GameObject element = Instantiate(instanceElement, spawnPoints[Random.Range(0, spawnPoints.Count - 1)].transform.position, Quaternion.identity);
            textTimer.gameObject.SetActive(true);
            float stopTime = Time.time + delayOfSearch;

            while (Time.time < stopTime)
            {
                textTimer.text = "ТАЙМЕР: " + (int)(stopTime - Time.time);

                yield return new WaitForSeconds(1f);
            }
            
            Lose();
        }


        // -----------------------Activate tablets on drone and player-----------------------
        public void ElementConnection()
        {
            drone.transform.Find("Tablet").gameObject.SetActive(true);
            NextMission();
        }

        public void TabletActivationOnPlayer()
        {
            tablet.SetActive(true);
            NextMission();
            StartCoroutine(ElementLife());
        }


        // -----------------------Activate UI with win or lose-----------------------
        public void Win()
        {
            StopAllCoroutines();
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

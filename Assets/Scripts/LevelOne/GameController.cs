using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

namespace LevelOne
{
    public class GameController : MonoBehaviour
    {
        public GameObject winUI;
        public GameObject loseUI;
        public GameObject pointer;
        public GameObject gun;
        public GameObject gunOnBot;
        public Animator botAnimator;

        [Header("PlayerUI")] 
        public List<GameObject> missions = new List<GameObject>();
        public GameObject playerCanvas;
        public int currentMission = 0;
        
        void Start()
        {
            pointer.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
            gun.SetActive(false);
        }

        void Update()
        {
        
        }

        public void Win()
        {
            pointer.SetActive(true);
            winUI.SetActive(true);
            gun.SetActive(false);
            playerCanvas.SetActive(false);
        }

        public void Lose()
        {
            pointer.SetActive(true);
            loseUI.SetActive(true);
            gun.SetActive(false);
            playerCanvas.SetActive(false);
        }

        public void GunOn()
        {
            gun.SetActive(true);
            gunOnBot.SetActive(false);
            botAnimator.SetTrigger("isPickUp");
            missions[2].SetActive(false);
            missions[3].SetActive(true);
        }

        public void BotFly2()
        {
            botAnimator.SetTrigger("isBeggin");
            missions[1].SetActive(false);
            missions[2].SetActive(true);
        }

        public void GoToMenu()
        {
            //SteamVR_LoadLevel.Begin("Main menu");
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("Main menu");
        }
    }
}

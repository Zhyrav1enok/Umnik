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
        }

        public void Lose()
        {
            pointer.SetActive(true);
            loseUI.SetActive(true);
            gun.SetActive(false);
        }

        public void GunOn()
        {
            gun.SetActive(true);
            gunOnBot.SetActive(false);
            botAnimator.SetTrigger("isPickUp");
        }

        public void BotFly2()
        {
            botAnimator.SetTrigger("isBeggin");
        }

        public void GoToMenu()
        {
            //SteamVR_LoadLevel.Begin("Main menu");
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("Main menu");
        }
    }
}

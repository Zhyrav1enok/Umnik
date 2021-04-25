using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class GameController : MonoBehaviour
    {
        public GameObject canvas;
        public GameObject bot;
        
        private Animator botAnimator;
        
        void Start()
        {
            canvas.SetActive(false);
            botAnimator = bot.GetComponent<Animator>();
        }
    
        public void BotButtonAwake()
        {
            StartCoroutine(BotAwake());
        }
    
        public void BotButtonSleep()
        {
            StartCoroutine(BotSleep());
        }
    
        public void LevelSelect1()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("LevelOne");
        }
        
        public void LevelSelect2()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("LevelTwo");
        }
        
        public void LevelSelect3()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("LevelThree");
        }

        public void LevelSelect4()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("LevelFour");
        }

        public void LevelSelect5()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("LevelFive");
        }
    
        private IEnumerator BotAwake()
        {
            botAnimator.SetTrigger("Awake");
            yield return new WaitForSeconds(5f);
            canvas.SetActive(true);
            botAnimator.SetTrigger("Active");
        }
        
        private IEnumerator BotSleep()
        {
            botAnimator.SetTrigger("Sleep");
            yield return new WaitForSeconds(1.25f);
            canvas.SetActive(false);
        }
    }
}


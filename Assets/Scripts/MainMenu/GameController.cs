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
            SceneManager.LoadScene("Level 1");
        }
        
        public void LevelSelect2()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("Level 2");
        }
        
        public void LevelSelect3()
        {
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene("Level 3");
        }
    
        private IEnumerator BotAwake()
        {
            botAnimator.SetTrigger("Awake");
            yield return new WaitForSeconds(1.5f);   // Ждем время анимации бота
            canvas.SetActive(true);
        }
        
        private IEnumerator BotSleep()
        {
            botAnimator.SetTrigger("Sleep");
            yield return new WaitForSeconds(1.5f);   // Ждем время анимации бота
            canvas.SetActive(false);
        }
    }
}


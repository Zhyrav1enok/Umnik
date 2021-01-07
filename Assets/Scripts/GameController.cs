using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        
    }

    public void BotButtonAwake()
    {
        StartCoroutine(BotAwake());
    }

    public void BotButtonSleep()
    {
        StartCoroutine(BotSleep());
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeInterval = 60f; 
    [SerializeField] private int initialMoney = 100;
    [SerializeField] private int moneyDecreasePerMinute = 5;

    [SerializeField] private Slider moneySlider;
    [SerializeField] private Text timerText; 

    private float timer;
    private int currentMoney;

    private void Start()
    {
        timer = timeInterval;
        currentMoney = initialMoney;
        moneySlider.maxValue = initialMoney;
        moneySlider.value = currentMoney;
    }

    private void Update()
    {
        
        timer -= Time.deltaTime;

        UpdateTimerUI(); 

        if (timer <= 0)
        {
            // Disminuir dinero
            DecreaseMoney(moneyDecreasePerMinute);

            // Reiniciar el temporizador
            timer = timeInterval;
        }
    }

    private void DecreaseMoney(int amount)
    {
        int targetMoney = currentMoney - amount;
        targetMoney = Mathf.Clamp(targetMoney, 0, initialMoney);

       
        StartCoroutine(LerpMoney(targetMoney));

        if (targetMoney <= 0)
        {
            Debug.Log("Game Over - No tienes suficiente dinero");
           
        }
    }

    private System.Collections.IEnumerator LerpMoney(int target)
    {
        float elapsedTime = 0f;
        float duration = 1f; // Duración de la interpolación en segundos

        int startMoney = currentMoney;

        while (elapsedTime < duration)
        {
            currentMoney = (int)Mathf.Lerp(startMoney, target, elapsedTime / duration);
            moneySlider.value = currentMoney;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentMoney = target;
        moneySlider.value = currentMoney;
    }

    private void UpdateTimerUI()
    {
        timerText.text = Mathf.Ceil(timer).ToString(); 
    }
}



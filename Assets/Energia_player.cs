using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia_player: MonoBehaviour
{
    [SerializeField] int maxenergia;
    [SerializeField] Slider sliderenergia;
    private int currentenergia;

    private void Start()
    {
        currentenergia = maxenergia;
        sliderenergia.maxValue = maxenergia;
        sliderenergia.value = currentenergia;
    }

    public void DecreaseEnergy(int amount)
    {
        currentenergia -= amount;
        currentenergia = Mathf.Clamp(currentenergia, 0, maxenergia);
        sliderenergia.value = currentenergia;

        if (currentenergia <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    private void OnTriggerEnter2D(Collider2D   Other)
    {
        Debug.Log("Colisión detectada con: " + Other.gameObject.tag);
        if (Other.gameObject.CompareTag("cafe"))
        {
         
            int energyToRegenerate = Mathf.RoundToInt(maxenergia * 0.2f);

          
            currentenergia += energyToRegenerate;
            currentenergia = Mathf.Clamp(currentenergia, 0, maxenergia);

          
            sliderenergia.value = currentenergia;

        
            Debug.Log("Energía regenerada: " + energyToRegenerate);
        }
    }



}


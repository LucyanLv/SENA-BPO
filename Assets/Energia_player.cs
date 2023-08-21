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
}


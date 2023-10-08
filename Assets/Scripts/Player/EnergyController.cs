using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    [SerializeField] int maxEnergy;

    [SerializeField] Slider sliderEnergy;

    private int currentEnergy;

    private void Start()
    {
        currentEnergy = maxEnergy;
        sliderEnergy.maxValue = maxEnergy;
        sliderEnergy.value = currentEnergy;
    }

    public void DecreaseEnergy(int amount)
    {
        currentEnergy -= amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        sliderEnergy.value = currentEnergy;

        if (currentEnergy <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void IncreaseMoney(int amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        sliderEnergy.value = currentEnergy;

        if (currentEnergy <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Colisión detectada con: " + Other.gameObject.tag);
        if (Other.gameObject.CompareTag("cafe"))
        {
            int energyToRegenerate = Mathf.RoundToInt(maxEnergy * 0.2f);

            currentEnergy += energyToRegenerate;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

            sliderEnergy.value = currentEnergy;
            Debug.Log("Energía regenerada: " + energyToRegenerate);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private float timeInterval = 60f; // Intervalo de tiempo en segundos
    [SerializeField] private int initialCoffe = 100;
    [SerializeField] private int coffeDecreasePerMinute = 5;
    [SerializeField] private int speedDecrease = 1;

    [SerializeField] private Slider coffeSlider;
    [SerializeField] private Text timerText; // Referencia al texto del temporizador

    private float timer;
    private int currentCoffe;

    private void Start()
    {
        timer = timeInterval;
        currentCoffe = initialCoffe;
        coffeSlider.maxValue = initialCoffe;
        coffeSlider.value = currentCoffe;
    }

    private void Update()
    {
        // Actualizar el temporizador
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            DecreaseCoffe(coffeDecreasePerMinute);

            // Reiniciar el temporizador
            timer = timeInterval;
        }
    }
    [ContextMenu("DecreaseCoffe")]
    private void DecreaseCoffe(int amount)
    {
        int targetCoffe = currentCoffe - amount;
        targetCoffe = Mathf.Clamp(targetCoffe, 0, initialCoffe);

        // Interpolación suave para disminuir el dinero gradualmente
        StartCoroutine(LerpCoffe(targetCoffe));

        if (targetCoffe <= 0)
        {
            FindObjectOfType<Final_Nivel>().FinalizacionNivel();

        }
        if (targetCoffe == 60 || targetCoffe == 30)
        {
            FindObjectOfType<Player_Mov>().DecreaseSpeed(speedDecrease);
        }
    }

    private IEnumerator LerpCoffe(int target)
    {
        float elapsedTime = 0f;
        float duration = 1f; // Duración de la interpolación en segundos

        int startCoffe = currentCoffe;

        while (elapsedTime < duration)
        {
            currentCoffe = (int)Mathf.Lerp(startCoffe, target, elapsedTime / duration);
            coffeSlider.value = currentCoffe;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentCoffe = target;
        coffeSlider.value = currentCoffe;
    }

    

    private void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Colisi�n detectada con: " + Other.gameObject.tag);
        if (Other.gameObject.CompareTag("cafe"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/DrinkCoffee");
            int energyToRegenerate = Mathf.RoundToInt(initialCoffe * 0.2f);

            DecreaseCoffe(-energyToRegenerate);

            Debug.Log("Energ�a regenerada: " + energyToRegenerate);
        }
    }

}


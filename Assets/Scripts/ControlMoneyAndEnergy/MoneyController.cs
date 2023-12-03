using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField] int maxMoney;

    [SerializeField] Slider sliderMoney;

    private int currentMoney;

    private void Start()
    {
        currentMoney = maxMoney/2;
        sliderMoney.maxValue = maxMoney;
        sliderMoney.value = currentMoney;

    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= amount;
        currentMoney = Mathf.Clamp(currentMoney, 0, maxMoney);
        sliderMoney.value = currentMoney;

        if (currentMoney <= 0)
        {
            FindObjectOfType<Final_Nivel>().FinalizacionNivel();
        }
    }

    public void IncreaseMoney(int amount)
    {
        currentMoney += amount;
        currentMoney = Mathf.Clamp(currentMoney, 0, maxMoney);
        sliderMoney.value = currentMoney;

        //if (currentMoney <= 0)
        //{
        //    FindObjectOfType<Final_Nivel>().FinalizacionNivel();
        //}
    }

    //private void OnTriggerEnter2D(Collider2D Other)
    //{
    //    Debug.Log("Colisión detectada con: " + Other.gameObject.tag);
    //    if (Other.gameObject.CompareTag("cafe"))
    //    {
    //        int moneyToRegenerate = Mathf.RoundToInt(maxMoney * 0.2f);

    //        currentMoney += moneyToRegenerate;
    //        currentMoney = Mathf.Clamp(currentMoney, 0, maxMoney);

    //        sliderMoney.value = currentMoney;
    //        Debug.Log("Energía regenerada: " + moneyToRegenerate);
    //    }
    //}
}
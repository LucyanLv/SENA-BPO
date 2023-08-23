using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejoDeBotones : MonoBehaviour
{
    public Button miBoton;

    void Start()
    {
        miBoton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Debug.Log("¡Se hizo clic en el botón!");
    }
}

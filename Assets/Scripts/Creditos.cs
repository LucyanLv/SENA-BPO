using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
   public void credits(string NombreDeEscena)
    {
       SceneManager.LoadScene(NombreDeEscena);
    }
}

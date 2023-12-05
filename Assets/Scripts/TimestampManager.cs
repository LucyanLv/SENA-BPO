using UnityEngine;
using System;

public class TimestampManager : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void SaveTimestamp(String key)
    {
        // Obtener el timestamp actual en segundos
        long timestamp = GetTimestamp();

        // Convertir el timestamp a cadena de texto y guardarlo en PlayerPrefs
        PlayerPrefs.SetString(key, timestamp.ToString());

        // Guardar PlayerPrefs para asegurar que los cambios se almacenen
        PlayerPrefs.Save();
    }

    public void LoadAndDisplayTimestamp(String key)
    {
        // Recuperar la cadena de texto del timestamp desde PlayerPrefs
        string timestampString = PlayerPrefs.GetString(key, "0");

        // Convertir la cadena de texto a un valor de tiempo
        long timestamp = long.Parse(timestampString);

        // Mostrar el timestamp en la consola
        Debug.Log("Timestamp recuperado: " + timestamp);

        // Puedes convertir el timestamp a un formato de fecha y hora si es necesario
        DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
        Debug.Log("Fecha y hora: " + dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    long GetTimestamp()
    {
        // Obtener el timestamp actual en segundos
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}

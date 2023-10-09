using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Net;
using System;

public class RegisterController : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button Registerbutton;
    public Button Gotologinbutton;
    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {

        Registerbutton.onClick.AddListener(writeStufflofile);
        Gotologinbutton.onClick.AddListener(goToLoginScene);
        if (File.Exists(Application.dataPath + "/ credentials.txt *"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/ credentials.txt *"));
        }

        else
        {
            File.WriteAllText(Application.dataPath + "/ credentials.txt ", "");
        }
    }

    void goToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }


    void writeStufflofile()
    {
        bool isExists = false;
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        Debug.Log(Application.dataPath + "/credentials.txt");
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(UsernameInput.text))
            {
                isExists = true;
                break;
            }
        }
        if (isExists)
        {
            Debug.Log($"Usernam  ' {UsernameInput.text}' already exists");
        }
        else
        {
            credentials.Add(UsernameInput.text + ":" + PasswordInput.text);
            File.WriteAllLines(Application.dataPath + "/ credentials.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Net;
using System;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class RegisterController : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField CodeInput;
    public Button Registerbutton;

    //ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Registerbutton.onClick.AddListener(writeStufflofile);

    }

    void goToLevel1()
    {
        SceneManager.LoadScene(3);
    }


    void writeStufflofile()
    {
        PlayerPrefs.SetString("username", UsernameInput.text);
        PlayerPrefs.SetString("code", CodeInput.text);
        PlayerPrefs.Save();
        goToLevel1();
    }


}
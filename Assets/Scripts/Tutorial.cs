using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Player_Mov player;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4,text5,text6;
    public GameObject panel;
    public GameObject indic1;
    public GameObject flecha,circulo;

    void Awake()
    {
        player.canMove=false;
        text1.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void texto2()
    {
        text1.SetActive(false);
        text2.SetActive(true);
    }
    public void texto3()
    {
        text2.SetActive(false);
        text3.SetActive(true);
    }
    public void texto4()
    {
        text3.SetActive(false);
        text4.SetActive(true);
    }
    public void run()
    {
        text4.SetActive(false);
        panel.SetActive(false);
        indic1.SetActive(true);
        flecha.SetActive(true);
        circulo.SetActive(true);
        player.canMove=true;
    }
    public void texto5()
    {
        panel.SetActive(true);
        text5.SetActive(true);
        flecha.SetActive(false);
        circulo.SetActive(false);
        player.canMove=false;

    }
}

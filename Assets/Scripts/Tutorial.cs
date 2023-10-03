using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Player_Mov player;
    public Pregunta_Tutorial tuto;
    public GameObject text1,launch,questionEmon,menu;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4,text5,text6,text7,text8,text9,text10,text11,text12,text13;
    public GameObject panel;
    public GameObject indic1;
    public GameObject flecha,circulo;

    void Awake()
    {
        player.canMove=false;
        text1.SetActive(true);
    }
    public void texto2()
    {
        text1.SetActive(false);
        text2.SetActive(true);}

    public void texto3()
    {
        text2.SetActive(false);
        text3.SetActive(true);}

    public void texto4()
    {
        text3.SetActive(false);
        text4.SetActive(true);}

    public void run()
    {
        text4.SetActive(false);
        panel.SetActive(false);
        indic1.SetActive(true);
        flecha.SetActive(true);
        circulo.SetActive(true);
        player.canMove=true;
    }
    public void run2()
    { 
        panel.SetActive(false);
        text11.SetActive(false);
        player.canMove=true;
        StartCoroutine(time());}

    public void run3()
    {
        panel.SetActive(false);
        tuto.questionpanel.SetActive(true);
        player.canMove=false;
    }
        
        
    public void texto5()
    {
        panel.SetActive(true);
        text5.SetActive(true);
        flecha.SetActive(false);
        circulo.SetActive(false);
        indic1.SetActive(false);
        player.canMove=false;}

    public void texto6()
    {
        text5.SetActive(false);
        text6.SetActive(true); }
    public void texto7()
    {
        text6.SetActive(false);
        text7.SetActive(true);}

    public void texto8()
    {
        text7.SetActive(false);
        text8.SetActive(true);}
    
    public void texto9()
    {
        text8.SetActive(false);
        text9.SetActive(true);}

    public void texto10()
    {
        text9.SetActive(false);
        text10.SetActive(true);}

        public void texto11()
    {
        text10.SetActive(false);
        text11.SetActive(true);}

        public void texto12()
    {
        text11.SetActive(false);
        tuto.textin.SetActive(false);

        text12.SetActive(true);}

        public void texto13()
        {
            text12.SetActive(false);
            text13.SetActive(true);
            StartCoroutine(time2());
        }
        
        IEnumerator time()
        {
            yield return new WaitForSeconds(2f);
            questionEmon.SetActive(true);
            launch.SetActive(true);
            
        }
        IEnumerator time2()
        {
            yield return new WaitForSeconds(1f);
            menu.SetActive(true);
            
        }
}

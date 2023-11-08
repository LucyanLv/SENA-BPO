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
    public GameObject back1,back2,back3,back4,back5,back7,back8,back9,back11,back12,back13;
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

    public void Back1()
    {
        text1.SetActive(true);
        text2.SetActive(false);
    }

    public void texto3()
    {
        text2.SetActive(false);
        text3.SetActive(true);}

    public void Back2()
    {
        text2.SetActive(true);
        text3.SetActive(false);
    }

    public void texto4()
    {
        text3.SetActive(false);
        text4.SetActive(true);}

    public void Back3()
    {
        text3.SetActive(true);
        text4.SetActive(false);}
    

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
        
        public void Back4()
    {
        text5.SetActive(true);
        text6.SetActive(false);
    }
    public void texto7()
    {
        text6.SetActive(false);
        text7.SetActive(true);}
    public void Back5()
    {
         text6.SetActive(true);
        text7.SetActive(false);
    }

    public void texto8()
    {
        text7.SetActive(false);
        text8.SetActive(true);}
    public void Back6()
    {
         text7.SetActive(true);
        text8.SetActive(false);
    }
    
    public void texto9()
    {
        text8.SetActive(false);
        text9.SetActive(true);}

    public void Back7()
    {
        text8.SetActive(true);
        text9.SetActive(false);
    }

    public void texto10()
    {
        text9.SetActive(false);
        text10.SetActive(true);}

    public void Back8()
    {
        text9.SetActive(true);
        text10.SetActive(false);

    }

        public void texto11()
    {
        text10.SetActive(false);
        text11.SetActive(true);}

    public void Back9()
    {
        text10.SetActive(true);
        text11.SetActive(false);
    }

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
    public void Back10()
    {
        text12.SetActive(true);
        text13.SetActive(false);
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

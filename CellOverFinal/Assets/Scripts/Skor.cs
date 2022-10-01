using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skor : MonoBehaviour
{
    public static Skor instance;
    int skor=0;
    public TMP_Text skorVeri, yuksekSkorVeri;
    public AudioSource vurmaSesi;


    public void Start()
    {
        instance = this;
        yuksekSkorVeri.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void puanKazan()
    {
        vurmaSesi.Play();
        skor += 50;
        skorVeri.text = skor.ToString();
        

        if (skor > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", skor);
            yuksekSkorVeri.text= skor.ToString();
        }
        
       
    }

}

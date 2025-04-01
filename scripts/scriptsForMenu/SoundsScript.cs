using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using YG;
using Microsoft.CSharp;
using TMPro;
public class SoundsScript : MonoBehaviour
{
    public static AudioSource button_click;
    public AudioMixer audioMixer;
    public Scrollbar Music_Scrollbar;
    public Scrollbar SFX_Scrollbar;

   // public TextMeshProUGUI test2;
   // public TextMeshProUGUI test3;

    public float tmp;
    private void Update()
    {
        audioMixer.GetFloat("MusicBus", out tmp);
        audioMixer.GetFloat("SFXBus", out float tmp1);
       // test3.text = Convert.ToString(tmp) + Convert.ToString(tmp1);
    }

    public void Awake()
    {
       
        button_click = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
        Music_Scrollbar = GameObject.Find("Music_Scrollbar").GetComponent<Scrollbar>();
        SFX_Scrollbar = GameObject.Find("SFX_Scrollbar").GetComponent<Scrollbar>();
    }
    public void Start()
    {
         

       // test2.text = Convert.ToString(YG2.saves.SFX_Value / 100f) + '/' + Convert.ToString(YG2.saves.Music_Value / 100f);
        SFX_Scrollbar.value = YG2.saves.SFX_Value/100f;
        Music_Scrollbar.value = YG2.saves.Music_Value/100f;
        audioMixer.SetFloat("MusicBus", YG2.saves.Music_Value / 100f);
        audioMixer.SetFloat("SFXBus", YG2.saves.SFX_Value / 100f);
        SetMusicVolume();
        SetSFXVolume();
    }
    public static void Button_Click_Play()
    {
        DontDestroyOnLoad(button_click);
        button_click.Play();
    }

    public void OnExit()
    {
        YG2.saves.SFX_Value = SFX_Scrollbar.value * 100f;
        YG2.saves.Music_Value = Music_Scrollbar.value * 100f;
        YG2.SaveProgress();
    }
    public void SetMusicVolume()
    {
        
       // YG2.saves.Music_Value = Music_Scrollbar.value*100f;
       // YG2.SaveProgress();
        if (Music_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("MusicBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(Music_Scrollbar.value) * 20;
            audioMixer.SetFloat("MusicBus", volume);
        }
        //test2.text = Convert.ToString(YG2.saves.SFX_Value / 100f) + '/' + Convert.ToString(YG2.saves.Music_Value / 100f);
    }

    public void SetSFXVolume()
    {
       
       // YG2.saves.SFX_Value = Music_Scrollbar.value * 100f;
       // YG2.SaveProgress();
        if (SFX_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("SFXBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(SFX_Scrollbar.value) * 20;
            audioMixer.SetFloat("SFXBus", volume);
        }
       // test2.text = Convert.ToString(YG2.saves.SFX_Value / 100f) + '/' + Convert.ToString(YG2.saves.Music_Value / 100f);
    }


}

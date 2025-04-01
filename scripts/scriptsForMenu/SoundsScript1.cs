using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using YG;
using TMPro;

public class SoundsScript1 : MonoBehaviour
{   public GameObject pauseCanvas;
    public static AudioSource button_click;
   
    public AudioMixer audioMixer;
  //  public TextMeshProUGUI test;
    public Scrollbar Music_Scrollbar;
    public Scrollbar SFX_Scrollbar;
    private bool status = true;




    public void Start()
    {

        
        button_click = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
        //  Music_Scrollbar = GameObject.Find("Music_Scrollbar").GetComponent<Scrollbar>();
        // SFX_Scrollbar = GameObject.Find("SFX_Scrollbar").GetComponent<Scrollbar>();


        SFX_Scrollbar.value = YG2.saves.SFX_Value / 100f;
        Music_Scrollbar.value = YG2.saves.Music_Value / 100f;
        audioMixer.SetFloat("MusicBus", YG2.saves.Music_Value / 100f);
        audioMixer.SetFloat("SFXBus", YG2.saves.SFX_Value / 100f);
        SetMusicVolume1();
        SetSFXVolume1();
    }
    public void OnExit()
    {
        YG2.saves.SFX_Value = SFX_Scrollbar.value * 100f;
        YG2.saves.Music_Value = Music_Scrollbar.value * 100f;
        YG2.SaveProgress();
    }
    private void Update()
    {
        if (pauseCanvas.activeInHierarchy && status) { 
        
            if (GameObject.Find("ButtonClickSound").GetComponent<AudioSource>() != null){
                button_click = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
            }
            
            Music_Scrollbar = GameObject.Find("Music_Scrollbar").GetComponent<Scrollbar>();
            SFX_Scrollbar = GameObject.Find("SFX_Scrollbar").GetComponent<Scrollbar>();
            status = false;
        }
    }
    public void SetMusicVolume1()
    {
       
        if (Music_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("MusicBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(Music_Scrollbar.value) * 20;
            audioMixer.SetFloat("MusicBus", volume);
        }
        
    }

    public void SetSFXVolume1()
    {
        
        if (SFX_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("SFXBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(SFX_Scrollbar.value) * 20;
            audioMixer.SetFloat("SFXBus", volume);
        }
    }
  
    public void Button_SFX()
    {
        try
        {
            SoundsScript.Button_Click_Play();
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("NullReferenceException");
        }
    }
}

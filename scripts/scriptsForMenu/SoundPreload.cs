using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using YG;

public class SoundPreload : MonoBehaviour
{

    public AudioSource audio;

    [SerializeField] private AudioClip[] audioClipsToPreload;

    void Awake()
    {
        
        // Предзагружаем аудиофайлы
        foreach (var clip in audioClipsToPreload)
        {
            if (clip != null)
            {
                clip.LoadAudioData();
              
            }
        }
    }
    private void Start()
    {
        audio = GameObject.Find("Menu_music").GetComponent<AudioSource>();
        audio.Play();
        
    }
    private void Update()
    {
        if(audio.isPlaying == false)
        {
            audio.Play();
        }
    }
}





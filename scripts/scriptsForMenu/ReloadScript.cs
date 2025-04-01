using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject pauseMenu;
    private Canvas canvas;
    private EventSystem eventSystem;
    private Button[] buttons;
    private Text[] texts;

    void Start()
    {
        // Находим Canvas
        canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
           // Debug.LogError("<color=red>Canvas не найден на сцене!</color>");
            return;
        }

        // Находим EventSystem
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            //Debug.LogError("<color=red>EventSystem не найден на сцене!</color>");
            gameObject.AddComponent<EventSystem>();
            eventSystem = EventSystem.current;
        }

        // Находим все UI-элементы
        buttons = FindObjectsOfType<Button>();
        texts = FindObjectsOfType<Text>();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Time.timeScale = 1f;
            // Debug.Log("<color=green>Игра возобновлена, перезагружаем Canvas</color>");
          //  if ((!pauseMenu.activeInHierarchy && pauseMenu != null))
         //  {
                Time.timeScale = 1f;
         //  }
            
            AudioListener.pause = false;

            // Перезапускаем Canvas
            if (canvas != null)
            {   if (canvas.enabled == true)
                {

                    canvas.enabled = false;
                    canvas.enabled = true;
                }
                
             //   Debug.Log("<color=blue>Canvas перезапущен</color>");
            }

            // Перезапускаем EventSystem
            if (eventSystem != null)
            {
                eventSystem.enabled = false;
                eventSystem.enabled = true;
            //    Debug.Log("<color=blue>EventSystem перезапущен</color>");
            }

            // Перезапускаем UI-элементы
            if (buttons != null)
            {
                foreach (var button in buttons)
                {
                    button.enabled = false;
                    button.enabled = true;
                }
            }
            if (texts != null)
            {
                foreach (var text in texts)
                {
                    text.enabled = false;
                    text.enabled = true;
                }
            }
          //  Debug.Log("<color=blue>UI-элементы перезапущены</color>");
        }
        else
        {
           // Debug.Log("<color=red>Игра приостановлена</color>");
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }
}


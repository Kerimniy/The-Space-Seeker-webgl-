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
        // ������� Canvas
        canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
           // Debug.LogError("<color=red>Canvas �� ������ �� �����!</color>");
            return;
        }

        // ������� EventSystem
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            //Debug.LogError("<color=red>EventSystem �� ������ �� �����!</color>");
            gameObject.AddComponent<EventSystem>();
            eventSystem = EventSystem.current;
        }

        // ������� ��� UI-��������
        buttons = FindObjectsOfType<Button>();
        texts = FindObjectsOfType<Text>();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Time.timeScale = 1f;
            // Debug.Log("<color=green>���� ������������, ������������� Canvas</color>");
          //  if ((!pauseMenu.activeInHierarchy && pauseMenu != null))
         //  {
                Time.timeScale = 1f;
         //  }
            
            AudioListener.pause = false;

            // ������������� Canvas
            if (canvas != null)
            {   if (canvas.enabled == true)
                {

                    canvas.enabled = false;
                    canvas.enabled = true;
                }
                
             //   Debug.Log("<color=blue>Canvas �����������</color>");
            }

            // ������������� EventSystem
            if (eventSystem != null)
            {
                eventSystem.enabled = false;
                eventSystem.enabled = true;
            //    Debug.Log("<color=blue>EventSystem �����������</color>");
            }

            // ������������� UI-��������
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
          //  Debug.Log("<color=blue>UI-�������� ������������</color>");
        }
        else
        {
           // Debug.Log("<color=red>���� ��������������</color>");
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }
}


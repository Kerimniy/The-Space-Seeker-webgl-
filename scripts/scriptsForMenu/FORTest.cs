using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class FORTest : MonoBehaviour
{
    public TextMeshProUGUI test;
    
    private void Update()
    {
        test.text = linkst.Lang_Locale;
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventSystem eventSystem = EventSystem.current;
            eventSystem.enabled = false;
            eventSystem.enabled = true;
        }
        DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.L))
        {
            linkst.object_count = 5;
        }
    }








}

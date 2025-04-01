using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TimeScript : MonoBehaviour
{
    DateTime time;
    public TextMeshProUGUI textMesh;
    
    void Start()
    {
        textMesh = GameObject.Find("TimeOutput").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time = DateTime.Now;
      
        string txt = time.ToLongTimeString();
        string new_txt = txt.Substring(0,8);
        textMesh.text = new_txt;
    }
}

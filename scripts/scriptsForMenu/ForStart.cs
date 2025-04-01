using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForStart : MonoBehaviour
{
   
    public GameObject Menu;
    public GameObject StartM;
    private void Start()
    {
        
        if (linkst.activated != true)
        {
            Menu.SetActive(false);
            StartM.SetActive(true);
        }
        else if (linkst.activated)
        {
            Menu.SetActive(true);
        }
    }

    void Update()
    {
     
        if (Input.anyKeyDown && !linkst.activated)
        {
            Menu.SetActive(true);
            StartM.SetActive(false);
            linkst.activated = true;
        }
    }
}

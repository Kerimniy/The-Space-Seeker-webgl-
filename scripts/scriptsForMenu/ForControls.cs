using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForControls : MonoBehaviour
{
    public SpriteRenderer w1;
    public SpriteRenderer a1;
    public SpriteRenderer s1;
    public SpriteRenderer d1;
    public SpriteRenderer q1;
    public SpriteRenderer e1;
    public SpriteRenderer c1;

    public Sprite w;
    public Sprite a;
    public Sprite s;
    public Sprite d;
    public Sprite q;
    public Sprite e;
    public Sprite c;
    public Sprite[] en;

    private bool setted;
    // Start is called before the first frame update
    private void Start()
    {
        setted = false;
    }

    void Update()
    {
        if (linkst.Lang_Locale == "ru" && setted == false)
        {
            w1.sprite = w;
            a1.sprite = a;
            s1.sprite = s;
            d1.sprite = d;
            q1.sprite = q;
            e1.sprite = e;
            c1.sprite = c;
            setted = true;

        }
        else if (linkst.Lang_Locale == "en" && setted == false)
        {
            w1.sprite = en[0];
            a1.sprite = en[1];
            s1.sprite = en[2];
            d1.sprite = en[3];
            q1.sprite = en[4];
            e1.sprite = en[5];
            c1.sprite = en[6];
            setted = true;

        }
    }
}

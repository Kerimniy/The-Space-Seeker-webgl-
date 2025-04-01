using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;
using System.Text;
namespace YG
{
    public class Language : MonoBehaviour
    {
      
        [DllImport("__Internal")]
        private static extern string GetLang();
      //  [SerializeField] TextMeshProUGUI text;
      //  [SerializeField]  TextMeshProUGUI  text1;
        public string CurrentLanguage;
        public Language Instance;
         void  Awake()
        {
            
            //text = GameObject.Find("TESTIM").GetComponent<TextMeshProUGUI>();
            //text1 = GameObject.Find("TESTIM1").GetComponent<TextMeshProUGUI>();
           
            
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                CurrentLanguage = GetLang();
                linkst.Lang_Locale = CurrentLanguage;
            //    text.text = CurrentLanguage;

            }
            else
            {
                Destroy(gameObject);
            }
            
        }
      
        private void Update()
        {
            linkst.Lang_Locale = GetLang();
          //  text.text = GetLang();

          //  text1.text = linkst.Lang_Locale;
        }
    
        public void OnYandexError()
        {
           // text1.text = "ÑÀÑÈ";
        }


    }
}

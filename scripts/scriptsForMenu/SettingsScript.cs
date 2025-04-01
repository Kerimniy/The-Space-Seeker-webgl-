using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



namespace YG
{
  

    public class SettingsScript : MonoBehaviour
    {
      
       
        private int currentResolutionIndex;
        public bool a;
        public Sprite spriteR;
        public Sprite spriteE;
        public GameObject Background;
        public Toggle Newtoggle;
        public TMP_Dropdown resolutionDropdown;
        public Toggle languageButton;
        public TMP_Dropdown qualityDropdown;

     //   public TextMeshProUGUI test2;
      //  public TextMeshProUGUI test4;

      
       // public TextMeshProUGUI test;
       
        public TMP_Text Quality_Text;
        private static Resolution[] resolutions;
        void Start()
        {
            qualityDropdown = GameObject.Find("Q_Dropdown").GetComponent<TMP_Dropdown>();

          //  test.text = Convert.ToString(YG2.saves.c);

            qualityDropdown.value = YG2.saves.QualityValue;
            SetQualityName();
            QualitySettings.SetQualityLevel(YG2.saves.QualityValue);
            Quality_Text.text = qualityDropdown.options[YG2.saves.QualityValue].text;
            //test4.text = qualityDropdown.options[qualityDropdown.value].text;

            linkst.rad_status = false;

        }

      

        public void SetQuality()
        {
            if (a)
            {
                SoundsScript.Button_Click_Play();
            }

            QualitySettings.SetQualityLevel(qualityDropdown.value);
            YG2.saves.QualityValue = qualityDropdown.value;
            
            int currentQualityLevel = QualitySettings.GetQualityLevel();
            string currentQualityName = QualitySettings.names[currentQualityLevel];
            YG2.SaveProgress();

        }
        /*
        public void ForTest()
        {   
            test.text =Convert.ToString(YG2.saves.c);
            YG2.saves.c++;
            YG2.SaveProgress();
            test2.text = Convert.ToString(YG2.saves.LevelComplete[0] +' ' + Convert.ToString(YG2.saves.LevelComplete[1]) + ' ' + Convert.ToString(YG2.saves.LevelComplete[2]) + ' ' + Convert.ToString(YG2.saves.LevelComplete[3]));

        }
        */
        public void SetQualityName()
        {
            if (linkst.Lang_Locale == "en")
            {
                qualityDropdown.options[0].text = "Low";
                qualityDropdown.options[1].text = "Medium";
                qualityDropdown.options[2].text = "High";
            }
            if (linkst.Lang_Locale == "ru")
            {
                qualityDropdown.options[0].text = "Низкие";
                qualityDropdown.options[1].text = "Средние";
                qualityDropdown.options[2].text = "Высокие";
            }
        }


        public void Set_a()
        {
            a = true;
        }

        public void OnExit()
        {
            YG2.SaveProgress();
        }
    }
}

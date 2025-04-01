using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class linkst : MonoBehaviour
{
    public static string Lang_Locale;
    public static Dictionary<string,dynamic> Saves;
    public static byte object_count = 0;
    public static bool rad_status;
    public static bool IsInCollider;
    public static int[] LevelComplete = {0,0,0,0};
    public static int currentScene = 1;
    public static bool activated;
    static void Awake()
    {
        Saves = new Dictionary<string, dynamic>
        {
            {"LevelComplete", new int[] {0,0,0,0 } },
            {"QualityValue", 2 },
            {"SFX_Value", 50f},
            {"Music_Value", 50f}
        };
        
    }

}
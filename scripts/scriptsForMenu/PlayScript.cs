using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using YG;

public class PlayScript : MonoBehaviour
{

    public GameObject exiting;
    public Button level0;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public GameObject MainMenu;
    public GameObject levels;
    public GameObject LoadingScreen;
    public Slider scale;
    public float holdTime = 0.5f; 


    void Awake()
    {
        linkst.LevelComplete[0] = YG2.saves.LevelComplete[0];
        linkst.LevelComplete[1] = YG2.saves.LevelComplete[1];
        linkst.LevelComplete[2] = YG2.saves.LevelComplete[2];
        linkst.LevelComplete[3] = YG2.saves.LevelComplete[3];

        
        if (linkst.LevelComplete[0] == 1)
        {
            level1.interactable = true;
            level2.interactable = false;
            level3.interactable = false;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[1] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = false;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[2] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = true;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[3] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = true;
            level4.interactable = true;
        }
    }


public void Play()
    {
        
        //SceneManager.LoadSceneAsync(linkst.currentScene);
        LoadingScreen.SetActive(true);
        MainMenu.SetActive(false);
        levels.SetActive(false);
        StartCoroutine(LoadAsync(linkst.currentScene));
    }



    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        
    }


    public void StartNewLevelwith(int levelindex)
    {
        LoadingScreen.SetActive(true);
        levels.SetActive(false);
        StartCoroutine(LoadAsync(levelindex));
       
    }

    IEnumerator LoadAsync(int levelindex)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(levelindex);
        loadAsync.allowSceneActivation = false;
        float time = 0f;
        bool completed = false;

        while (!loadAsync.isDone)
        {

            scale.value = loadAsync.progress;
            time += Time.unscaledDeltaTime;
            Debug.Log(time);
            if (time > 0.8f)
            {

                loadAsync.allowSceneActivation = true;
            }
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {

                scale.value += time;

                loadAsync.allowSceneActivation = true;
                Debug.Log(loadAsync.allowSceneActivation);
                completed = true;
            }

            yield return null;
        }


        scale.value = 1f;
        loadAsync.allowSceneActivation = true;


    }





}

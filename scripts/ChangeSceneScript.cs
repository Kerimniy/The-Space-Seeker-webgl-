using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ChangeSceneScript : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject LoadingScreen;
    public Slider scale;
    

    void Start()
    {
        Resume();
        

    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(sceneIndex);
            if (sceneIndex == 5)
            {
                StartCoroutine(LoadAsync(0));
            }
            else
            {
                StartCoroutine(LoadAsync(sceneIndex + 1));
            }
            
        }
        
        if (Time.timeScale == 1f && pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }

            if (SceneExists(sceneIndex + 1) || sceneIndex == 5)
            {
            
                if (linkst.object_count == 5 && Input.GetKeyDown(KeyCode.Space) && linkst.IsInCollider == true)
                {
                    if (sceneIndex == 5)
                    {
                    linkst.object_count = 0;
                    linkst.LevelComplete[3] = 1;
                    YG2.saves.LevelComplete[3] = linkst.LevelComplete[3];
                    YG2.SaveProgress();
                    LoadingScreen.SetActive(true);
                    StartCoroutine(LoadAsync(0));
                    }
                    else { 
                    linkst.object_count = 0;
                    linkst.LevelComplete[sceneIndex - 1] = 1;
                    YG2.saves.LevelComplete[sceneIndex - 1] = linkst.LevelComplete[sceneIndex - 1];
                    YG2.SaveProgress();
                    LoadingScreen.SetActive(true);
                    StartCoroutine(LoadAsync(sceneIndex + 1));
                    }
                

                }

            }


            if (Input.GetKeyDown(KeyCode.P) && pauseMenu.activeSelf == false)
            {   
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                

            }
            else if (Input.GetKeyDown(KeyCode.P) && pauseMenu.activeSelf == true)
            {
  
              Resume();

            }



    }
        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void returnMenu()
        {
        linkst.rad_status = false;
        linkst.object_count = 0;
        LoadingScreen.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(0));
        
        
        }


    bool SceneExists(int sceneIndex)
    {
        if (sceneIndex < SceneManager.sceneCountInBuildSettings) return true;
        else return false;
    }


    IEnumerator LoadAsync(int levelindex)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(levelindex);
        loadAsync.allowSceneActivation = false;
        float time = 0f;
        bool completed = false;
        
        while (!loadAsync.isDone )
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

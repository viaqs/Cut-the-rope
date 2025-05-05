using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject endLevelScreen;
    public Image[] stars;
    public Image[] endStars;
    public Sprite starOn;

    private int index = 0;
    
    private void Awake()
    {
        if(instance == null) instance = this;
        else gameObject.SetActive(false);
        
        endLevelScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddStar()
    {
        endStars[index].sprite = starOn;
        stars[index++].sprite = starOn;
    }

    public void OpenNextLevelScreen()
    {
        endLevelScreen.SetActive(true);
    }

    public void OpenNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}

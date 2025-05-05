using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        if (instance == null) instance = this;
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

    public void NextLevelScreen()
    {
        endLevelScreen.SetActive(true);
    }

    public void LoadNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}

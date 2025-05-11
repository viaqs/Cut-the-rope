using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject panel ;
    public Image[] stars;
    public Image[] stars2;
    public Sprite fullStar;

    private int sceneCount;
    private int randomIndex;
    private int index = 0;

    private void Awake()
    {
        if(instance == null) instance = this;
        else gameObject.SetActive(false);

        panel.SetActive(false);
         sceneCount = SceneManager.sceneCountInBuildSettings;
        
        randomIndex = UnityEngine.Random.Range(0, sceneCount);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
    public void startGame()
    {
        SceneManager.LoadScene(randomIndex);
    }
    public void nextLevel()
    {
        if (randomIndex == SceneManager.GetActiveScene().buildIndex)
        {
            randomIndex = (randomIndex + 1) % sceneCount;
        }

        SceneManager.LoadScene(randomIndex);
    }
    public void AddStar()
    {
        stars[index].sprite = fullStar;
        stars2[index].sprite = fullStar;
        index++;
    }

    public void endLevelscreen()
    {
        panel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool gameIsRunning = false;
    private int score = 0;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject); // Make sure Object is not destroyed on level loading
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        gameIsRunning = true;
    }

    // Overloading the LoadLevel method to accept multiply types of parameters
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        gameIsRunning = true;
    }

    public void EndLevel()
    {
        gameIsRunning = false;
        SceneManager.LoadScene("MainMenu");
        Init();
    }

    public void Init()
    {
        score = 0;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}

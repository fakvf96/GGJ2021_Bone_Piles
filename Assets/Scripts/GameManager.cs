using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

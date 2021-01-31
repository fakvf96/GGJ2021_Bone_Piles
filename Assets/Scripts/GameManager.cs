using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    bool Pause = false;
    bool Resume = false;

    public void PauseGame()
    {
        if (Pause)
        {
            Time.timeScale = 1;
            Pause = false;
        }
        else
        {
            Time.timeScale = 0;
            Pause = true;
        }
    }

    public void ResumeGame()
    {
        if (Resume)
        {
            Time.timeScale = 1;
            Resume = true;
        }
        else
        {
            Time.timeScale = 1;
            Resume = false;
            
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartGame(string SceneToLoad)

    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciando");
    }

    public void QuitGame()
    {
        Debug.Log("Batata");
        Application.Quit();
    }

    

}






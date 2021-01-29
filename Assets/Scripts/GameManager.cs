using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Fase1");
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
        Debug.Log("Batata");
        Application.Quit();
    }
}

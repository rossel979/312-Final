using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        // Loads the main game
        SceneManager.LoadScene(1);
    }


    public void Tutorial() 
    {
        //loads the tutorial 
        SceneManager.LoadScene(2);
    }

    public void Exit() 
    { 
        Application.Quit();
    }
    
    public void Credits() 
    {
        //loads credits scene
        SceneManager.LoadScene(2);
    }



}

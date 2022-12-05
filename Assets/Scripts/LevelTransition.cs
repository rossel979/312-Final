using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    bool blnIsTransitioning;
    bool blncollisionDisabled;
    
    void OnCollisionEnter(Collision other)
    {
        if (blnIsTransitioning || blncollisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "MainMenu":
                SceneManager.LoadScene(0);
                break;
            case "Finish":
                SceneManager.LoadScene(1);
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Credits":
                SceneManager.LoadScene(2);
                break;
        }
    }
   
}

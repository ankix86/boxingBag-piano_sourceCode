using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    public GameObject panelMenu,panelDificulty;

    public void play(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void retry()
    {
        Scene s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void tutorial()
    {

    }
    public void back()
    {
        panelDificulty.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void openDificultySelector()
    {
        panelDificulty.SetActive(true);
        panelMenu.SetActive(false);
    }
    
}

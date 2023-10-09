using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{       
    [SerializeField] GameObject soundMenu;

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Kevin 2");
    }
    
    public void SoundSettings()
    {
        soundMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject soundMenu;

    public static bool isPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    private void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
        if(Time.timeScale == 0){
            Resume();
        }
    }
    public void Quit(){
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void SoundSettings(){
        soundMenu.SetActive(true);

    }

    public void ResumeGame(){
        Resume();
    }
}

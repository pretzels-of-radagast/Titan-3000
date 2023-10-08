using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    [SerializeField] GameObject CreditsPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayAgain(){
        SceneManager.LoadScene("Kevin");
    }
    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadCredits(){
        CreditsPage.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    
    public Animator anim;
    public GameObject startMenu;
    public GameObject credits;
    public GameObject options;
    public GameObject difficultyN ;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        anim = GetComponent<Animator>();
        credits.SetActive(false);
        options.SetActive(false);
        difficultyN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Preparation()
    {
        difficultyN.SetActive(true);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Get ready! I guess...");
    }

     public void Settings()
     {
        startMenu.SetActive(false);
        options.SetActive(true);

     }

     public void Credits()
     {
        startMenu.SetActive(false);
        credits.SetActive(true);
     }

     public void CreditsQuit()
     {
        startMenu.SetActive(true);
        credits.SetActive(false);
     }


    public void SettingQuit()
    {
        startMenu.SetActive(true);
        options.SetActive(false);
    }

    public void Endless()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("The player has exitted, hopefully they'll play again");
    }
}

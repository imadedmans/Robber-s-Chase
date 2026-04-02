using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public GameObject comform;
    public GameObject complete;
    public GameObject StopMovement;
    public GameObject pauseMenu;
    public GameObject scoreText;

    public GameObject instructions;
    public float timeToProcede;

    public Animator anim;

    void Awake()
    {
        anim = comform.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        comform.SetActive(true);
        complete.SetActive(false);
        instructions.SetActive(false);
        pauseMenu.SetActive(false);
        scoreText.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Placeholder Player")
        { 
            CompleteLevel();
        }
    }

    public void BeginLevel()
    {
        comform.SetActive(false);
        Time.timeScale = 1.0f;
        scoreText.SetActive(true);
        instructions.SetActive(true);
        Invoke("Delete", timeToProcede);
    }

    void CompleteLevel() 
    {
        complete.SetActive(true);
        Invoke("NextLevel", 3f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Delete()
    {
        instructions.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartUP");
    }

    //pause menu stuff here
     
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

}

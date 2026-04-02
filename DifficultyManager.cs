using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    enum DifficultyOptions {None = 0, Easy = 1, Normal = 2, Hard = 3}
    DifficultyOptions d;

    public StartMenu startMenu;
    public Movement player;

    void Awake()
    {
        GameObject[] diff = GameObject.FindGameObjectsWithTag("difficulty");

        if (diff.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        d = DifficultyOptions.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DifficultySelection()
    {   
        if(d != DifficultyOptions.None)
        {
            Debug.Log("Difficulty: " + d + " has been chosen, Proceeding to game");
            startMenu.GameStart();

            yield return new WaitForSeconds(0.01f);

            Debug.Log("Woah, that proceeded successfully");
            SceneDecisiveness();
        }
    }

    public void Easy()
    {
        d = DifficultyOptions.Easy;
        StartCoroutine(DifficultySelection());
    }

    public void Normal()
    {
        d = DifficultyOptions.Normal;
        StartCoroutine(DifficultySelection());
    }

    public void Hard()
    {
        d = DifficultyOptions.Hard;
        StartCoroutine(DifficultySelection());
    }

    public void SceneDecisiveness()
    {
        Scene scene = SceneManager.GetActiveScene();

        //may have to use tentary operators for this

        if(scene.buildIndex == 1)
        {
            Debug.Log("Woah, that proceeded successfully 2: Electric Boogaloo");
            ApplyingDifficulty();
        }
    }

    public void ApplyingDifficulty()
    {
        GameObject player = GameObject.Find("Placeholder Player");
        Movement movement = GetComponent<Movement>();

        //for easy: currentSpeed = speed * 0.75;
        //for normal: currentSpeed = speed;
        //for hard: currentSpeed = speed * 1.5;
    }

}

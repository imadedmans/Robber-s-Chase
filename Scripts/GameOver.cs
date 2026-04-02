using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Movement player;
    private bool checkPoint = false;
    public GameObject checkpointLocal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        if(checkPoint == false)
        {
            ActualReset();
        }
        else if(checkPoint == true)
        {
            Debug.Log("Checkpoint Reached Again!");
            player.transform.position = checkpointLocal.transform.position;
            player.CheckpointReset();
        }
    }

    void ActualReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToStart()
    {
        SceneManager.LoadScene("StartUP");
    }

    public void Wat()
    {
        Debug.Log("dude that button does nothing stop pressing it");
    }

    public void CheckReached()
    {
        checkPoint = true;
    }
}

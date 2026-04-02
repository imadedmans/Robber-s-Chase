using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Placeholder Player")
        {
            Debug.Log("Checkpoint Reached!");
            gameOver.CheckReached();
        }
    }
}

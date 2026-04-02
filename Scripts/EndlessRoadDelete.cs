using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoadDelete : MonoBehaviour
{
    private float timeBeforeDelete = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", timeBeforeDelete);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

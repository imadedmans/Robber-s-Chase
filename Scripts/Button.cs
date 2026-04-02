using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Barrier;
    private bool barrierOpen = false;
    Animator barrAnim;

    // Start is called before the first frame update
    void Awake()
    {
        barrAnim = Barrier.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(barrierOpen == true)
        {
            barrAnim.enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        barrierOpen = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliBoss : MonoBehaviour
{
    [Header("Object Stuff")]
    public GameObject barrier;
    public Transform dropBarrier;
    public Animator animator;

    [Header("Physics")]
    public Rigidbody rb;
    public float verticalSpeed;
    public float horizontalSpeed;
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChoosingAttack", 5);
    }

    void Update()
    {
         
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, verticalSpeed * Time.deltaTime); 
    }

    public void ChoosingAttack()
    {
        int attackChooser = Random.Range(0, 1);

        if(attackChooser == 0)
        {
            BarrierDrop();
            Debug.Log("The boss has chosen to drop roadblocks!");
        }
        else if(attackChooser == 1)
        {
            MissileBarrage();
            Debug.Log("The boss has chosen to fire missiles!");
        }
    }

    public void BarrierDrop()
    {
        //Insert attack phase here
        ChoosingAttack();
    }

    public void MissileBarrage()
    {
        //Yada yada yada attack phase here
        ChoosingAttack();
    }

}

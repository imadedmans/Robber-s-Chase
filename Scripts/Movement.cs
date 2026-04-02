using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float endlessSpeed;
    public float horizontalSpeed;

    public Transform camera;
    public bool allowJumping = false;
    public float jumpStrength;
    private bool grounded = true;
    public bool endlessModeAcceleration = false;
    public GameObject gameOver;

    public GameManager gameManager;
    public Movement movementStopper;
    public AudioClip crashSFX;
    private AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody>();
        aS = GetComponent<AudioSource>();
        movementStopper.enabled = true;
        endlessSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vertical speed
        rb.AddForce(0, 0, speed * Time.deltaTime);

         //Horizontal speed
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(allowJumping && grounded)
            {
                rb.AddForce(0, jumpStrength * Time.deltaTime, 0, ForceMode.Impulse);
                grounded = false;
            }
        }

        else if(endlessModeAcceleration == true)
        {
            rb.AddForce(0, 0, endlessSpeed * Time.deltaTime);
            StartCoroutine(EndlessSpeedIncrease());
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Obsticle")
        {
            //Hey me in the future, just to let you know, I removed the camera death effect for convience sake, you need to find a way to bring it back
            rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationZ;
            movementStopper.enabled = false;
            aS.PlayOneShot(crashSFX, 1F);
            gameOver.SetActive(true);
        }

        if(col.collider.name == "Floor")
        {
            grounded = true;
        }
    }

    public IEnumerator EndlessSpeedIncrease()
    {
        endlessSpeed += 0.1f;
        yield return new WaitForSeconds(1);
        StartCoroutine(EndlessSpeedIncrease());
    }

    public void CheckpointReset()
    {
        movementStopper.enabled = true;
        gameOver.SetActive(false);
    }
 
}

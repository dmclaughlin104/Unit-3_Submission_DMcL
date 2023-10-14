using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //objects
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;

    //variables
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver = false;

    //audio variables
    public AudioClip jumpAudio;
    public AudioClip crashAudio;


    // Start is called before the first frame update
    void Start()
    {
        //assign rigid body component to object
        playerRB = GetComponent<Rigidbody>();

        //apply gravity physics
        Physics.gravity *= gravityModifier;

        //assign player animation controller to object
        playerAnim = GetComponent<Animator>();

        //apply audio source
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //jump control
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {

            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAudio.PlayOneShot(jumpAudio, 1.0f);

            isOnGround = false;

            dirtParticle.Stop();

            playerAnim.SetTrigger("Jump_trig");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashAudio, 1.0f);

            gameOver = true;
            Debug.Log("You've hit an obstacle - GAME OVER");
        }



    }

}

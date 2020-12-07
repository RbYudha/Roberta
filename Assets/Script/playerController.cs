using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    //Test non-preFabs
    //public Rigidbody2D fox;
    //public Animator foxAnim;
    //public Collider2D collFox;

    //Test preFabs
    private Rigidbody2D fox;
    private Animator foxAnim;
    private Collider2D collFox;
    //private AudioSource footstep;

    private enum State { idle, running, jumping, falling, hurt }; //State {0, 1, 2, ....}
    private State state = State.idle; //keadaan

    [SerializeField] private LayerMask ground;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherryText;
    //public int cherries = 0;
    [SerializeField] private float hurtForce = 6f;

    //Suara
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource medicine;
    [SerializeField] private AudioSource killEnemy;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource kenaMusuh;

    private void Start() {
        fox = GetComponent<Rigidbody2D>();
        foxAnim = GetComponent<Animator>();
        collFox = GetComponent<Collider2D>();
        //footstep = GetComponent<AudioSource>();
    }    

    private void Update()
    {
        if (state != State.hurt) {
            Movement();
        }
        VelocityState();
        foxAnim.SetInteger("state",(int)state);
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        // if (Input.GetKey(KeyCode.A)) {
        if (hDirection < 0)
        {
            fox.velocity = new Vector2(-5, fox.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        // else if (Input.GetKey(KeyCode.D)) {
        else if (hDirection > 0)
        {
            //fox.velocity = new Vector2(5, 0);
            fox.velocity = new Vector2(5, fox.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetButtonDown("Jump") && collFox.IsTouchingLayers(ground))
        {
            jumping.Play();
            Jump();
        }
    }

    private void Jump()
    {
        fox.velocity = new Vector2(fox.velocity.x, 7);
        state = State.jumping;
    }

    //setAnimation
    private void VelocityState()
    {

        if (state == State.jumping)
        {
            if (fox.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (collFox.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(fox.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(fox.velocity.x) > 2f)
        {
            //moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }


    //kill musuh
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //testing
            //Destroy(collision.gameObject);

            if (state == State.falling)
            {
                killEnemy.Play();
                Destroy(collision.gameObject);
                Jump();
            }
            else
            {
                state = State.hurt;
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    kenaMusuh.Play();
                    //enemy is to the right, trown left
                    fox.velocity = new Vector2(-7f, fox.velocity.y);
                }
                else
                {
                    kenaMusuh.Play();
                    //enemy is to the left, trown right
                    fox.velocity = new Vector2(7f, fox.velocity.y);
                }
            }
        }
    }

    //Cherry Colector
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable") {
            medicine.Play();
            Destroy(collision.gameObject);
            cherries += 1;
            cherryText.text = cherries.ToString();
        }
    }

    private void Footstep() {
        footstep.Play();
    }

}
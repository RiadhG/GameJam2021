using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public LayerMask dontHit;
    public GameObject can;
    Animator m_Animator;

    private bool isGrounded;
    public GameObject gun;
    public bool inCombat = false;
    public int level = 1;

    public bool puzzle = false;
    public bool axe = false;
    public bool katana = false;
    public bool trident = false;
    private int health = 100;
    public bool inLevel = false;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        m_Animator = gameObject.GetComponent<Animator>();
        isGrounded = true;
    }

    void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene("TestScene");            
        float moveHorizontal = Input.GetAxis ("Horizontal");
        rb2d.velocity = new Vector2 (moveHorizontal * speed, rb2d.velocity[1]);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb2d.velocity = new Vector2 (moveHorizontal * speed, 8);
            isGrounded = false;
            m_Animator.SetBool("isGrounded", false);
        }
        // if (Input.GetKeyDown(KeyCode.R))
        //     rb2d.position = rb2d.position + new Vector2 (moveHorizontal * 2, 0);
        if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") != 0)
            m_Animator.SetBool("isRunning", true);
        else
            m_Animator.SetBool("isRunning", false);
    }

    void LateUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Puzzle")
        {
            puzzle = true;
        }
        if (col.gameObject.name == "Axe")
        {
            axe = true;
        }
        if (col.gameObject.name == "Katana")
        {
            katana = true;
        }
        if (col.gameObject.name == "Trident")
        {
            trident = true;
        }

        if (col.gameObject.tag == "Ennemy")
        {
            inCombat = true;
        }

        if (col.gameObject.name == "l1End")
        {
            level = 0;
            // transform.position = dest2.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ennemy")
        {
            health -= 100;
        }
        if (col.gameObject.tag == "Ennemy Bullet")
        {
            health -= 20;
        }
        if(col.contacts.Length > 0)
        {
            ContactPoint2D contact = col.contacts[0];
            if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isGrounded = true;
                m_Animator.SetBool("isGrounded", true);
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
    }
}


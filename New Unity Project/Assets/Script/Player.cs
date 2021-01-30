using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public LayerMask dontHit;

    private bool isGrounded;
    public GameObject gun;
    public bool inCombat = false;

    private bool artifact1 = false;
    private bool LeifAxe = false;
    private bool artifact3 = false;
    private bool artifact4 = false;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        isGrounded = true;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        rb2d.velocity = new Vector2 (moveHorizontal * speed, rb2d.velocity[1]);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb2d.velocity = new Vector2 (moveHorizontal * speed, 8);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
            rb2d.position = rb2d.position + new Vector2 (moveHorizontal * 2, 0);
        if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "artifact1")
        {
            artifact1 = true;
        }
        if (col.gameObject.name == "LeifAxe")
        {
            LeifAxe = true;
        }
        if (col.gameObject.name == "artifact3")
        {
            artifact3 = true;
        }
        if (col.gameObject.name == "artifact4")
        {
            artifact4 = true;
        }

        if (col.gameObject.tag == "Ennemy")
        {
            inCombat = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ennemy")
        {
            SceneManager.LoadScene("SampleScene");            
        }
        if(col.contacts.Length > 0)
        {
            ContactPoint2D contact = col.contacts[0];
            if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
               isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public LayerMask dontHit;

    private bool isGrounded;
    public GameObject sword;
    public GameObject gun;

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
            rb2d.velocity = new Vector2 (moveHorizontal * speed, 8);
        if (Input.GetKeyDown(KeyCode.R))
            rb2d.position = rb2d.position + new Vector2 (moveHorizontal * 2, 0);
        
        if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
                transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}


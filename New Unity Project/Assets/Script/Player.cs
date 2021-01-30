using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            rb2d.velocity = new Vector2 (moveHorizontal * speed, 8);
        if (Input.GetKeyDown(KeyCode.R))
            rb2d.position = rb2d.position + new Vector2 (moveHorizontal * 2, 0);
        if (Input.GetKeyDown(KeyCode.S))
            sword.SetActive(!sword.activeSelf);
        if (Input.GetKeyDown(KeyCode.G))
            gun.SetActive(!gun.activeSelf);
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject door;
    //public AudioSource Pickup;


    // Start is called before the first frame update
    void Start()
    {
        //Pickup = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
//        if (col.gameObject.tag == "Player")
//        {
            door.SetActive(false);
            Destroy(gameObject);
        //Pickup.Play();
//        }
    }
}

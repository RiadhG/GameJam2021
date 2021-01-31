﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryRoads : MonoBehaviour
{
    public GameObject player;
    public GameObject startingPoint;
    public GameObject camera;
    public int level;

    //public AudioSource SelectWorld;

    // Start is called before the first frame update
    void Start()
    {
        //SelectWorld = GetComponent<AudioSource>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //SelectWorld.Play();
            player.SetActive(true);
            player.GetComponent<Player>().level = level;
            player.transform.position = startingPoint.transform.position;
            // camera.GetComponent<Cam>().offset = camera.transform.position - player.transform.position - new Vector3 (0, 0, 10);
            Debug.Log(camera.transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

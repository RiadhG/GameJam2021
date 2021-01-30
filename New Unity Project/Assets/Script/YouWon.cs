using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour
{
    public GameObject camera;
    public GameObject map;
    public GameObject player;

    public GameObject can;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            camera.transform.position = map.transform.position + new Vector3 (0, 0, -10);
            player.GetComponent<Player>().inCombat = false;
        // camera.GetComponent<Cam>().offset = map.transform.position - map.transform.position - new Vector3 (0, 0, 10);
            if (!player.GetComponent<Player>().puzzle || !player.GetComponent<Player>().axe || !player.GetComponent<Player>().katana || !player.GetComponent<Player>().trident)
                player.SetActive(false);
            else
            {
                player.SetActive(false);
                can.SetActive(true);
            }
        }
    }
}

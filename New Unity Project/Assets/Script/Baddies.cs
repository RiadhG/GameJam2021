using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddies : MonoBehaviour
{
    private GameObject m_Player;
    private float speed = 3;
    private float health = 30;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (m_Player.GetComponent<Player>().inCombat)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }
}

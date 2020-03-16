﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy2 : MonoBehaviour
{
    GameManager gm;
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.playerIsDead = true;
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            gm.CheckPlayerLives();
        }
    }
}
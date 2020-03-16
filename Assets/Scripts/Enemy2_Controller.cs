﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float timerBullet;
    private float maxTimerBullet;
    public GameObject bullet;

    public float timerMin = 4f;
    public float timerMax = 15f;
    public bool canFireBullets = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        timerBullet = 0;
        maxTimerBullet = Random.Range(timerMin, timerMax);

        if (canFireBullets)
            StartCoroutine("FireBullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
            Destroy(this.gameObject);
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.y = (bullet.GetComponent<Renderer>().bounds.size.y / 2) + (GetComponent<Renderer>().bounds.size.y / 2);
        GameObject.Instantiate(bullet, spawnPoint, transform.rotation);
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            if (timerBullet >= maxTimerBullet)
            {
                // Spawn an enemy
                SpawnBullet();
                timerBullet = 0;
                maxTimerBullet = Random.Range(timerMin, timerMax);
            }

            timerBullet += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

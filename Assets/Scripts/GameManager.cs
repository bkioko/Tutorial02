using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public GameObject playerPrefab;
    private GameObject Player;
    public Transform respawnLocation;
    public bool playerIsDead;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public GameObject gameOverScreen; 

    // Start is called before the first frame update
    void Start()
    {
        FindCurrentPlayerObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPlayerLives()
    {
        if (playerIsDead)
        {
            playerLives--;
            Player = null;
            if (playerLives > 0)
            {
                RespawnPlayer();
            }
            else
            {
                TriggerGameOver();
            }
            UpdateLives();

        }
    }

    void RespawnPlayer()
    {
        Instantiate(playerPrefab, respawnLocation.transform.position, respawnLocation.transform.rotation);
        playerIsDead = false;
        FindCurrentPlayerObject();
    }

    void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void UpdateLives()
    {
        if(playerLives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if(playerLives == 2)
        {
            life3.SetActive(false);
        }
        else if(playerLives == 1)
        {
            life2.SetActive(false);
        }
        else if(playerLives == 0)
        {
            life1.SetActive(false);
        }
    }

    void FindCurrentPlayerObject()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}

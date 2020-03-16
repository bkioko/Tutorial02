using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Controller : MonoBehaviour
{
    public float waitTime = 5.0f;
    public bool endlessSpawning = false;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        InstantiateObject();
    }

    void InstantiateObject()
    {
        Instantiate(objectToSpawn, objectToSpawn.transform.position, objectToSpawn.transform.rotation);
        if(endlessSpawning)
        {
            StartCoroutine(Delay(waitTime));
        }
    }
}

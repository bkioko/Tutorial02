using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithSpaceBar : MonoBehaviour
{
    public string LevelToLoadName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(LevelToLoadName);
    }
}

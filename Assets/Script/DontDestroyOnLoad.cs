using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject gameController;
    
    void Awake(){
        GameObject[] foundGameControllers = GameObject.FindGameObjectsWithTag("GameController");

        foreach (GameObject gc in foundGameControllers)
        {
            gameController = gc;
            DontDestroyOnLoad(gameController);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

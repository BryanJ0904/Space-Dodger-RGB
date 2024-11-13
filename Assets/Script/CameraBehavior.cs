using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private AudioSource audio;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.frenzyOn){
            audio.pitch = 1.5f;
        }else{
            audio.pitch = 1f;
        }
    }
}

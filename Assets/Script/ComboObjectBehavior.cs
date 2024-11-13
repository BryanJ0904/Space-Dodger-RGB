using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboObjectBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.asteroidChosen != null){
            spriteRenderer.sprite = gameManager.asteroidChosen.GetComponent<SpriteRenderer>().sprite;
        }
    }
}

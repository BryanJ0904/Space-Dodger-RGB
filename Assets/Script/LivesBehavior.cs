using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesBehavior : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int livesInt = (int)gameManager.lives;
        GetComponent<TMP_Text>().text = livesInt.ToString();
    }
}

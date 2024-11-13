using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private TMP_Text level;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        level = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int levelInt = (int)gameManager.level;
        level.text = levelInt.ToString();
    }
}

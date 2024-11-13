using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int scoreInt = (int)gameManager.score;
        score.text = scoreInt.ToString();
    }
}

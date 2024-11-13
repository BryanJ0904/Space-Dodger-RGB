using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryBehavior : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private string color;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(color == "Red"){
            int redBatteryInt = (int)gameManager.redBattery;
            GetComponent<TMP_Text>().text = redBatteryInt.ToString();
        }else if(color == "Green"){
            int greenBatteryInt = (int)gameManager.greenBattery;
            GetComponent<TMP_Text>().text = greenBatteryInt.ToString();
        }else if(color == "Blue"){
            int blueBatteryInt = (int)gameManager.blueBattery;
            GetComponent<TMP_Text>().text = blueBatteryInt.ToString();
        }
    }
}

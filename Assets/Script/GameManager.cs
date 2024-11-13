using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject UIText;
    public GameObject bonusPointsText;

    public float score = 0;
    public float scoreDebt = 0;
    public float level = 1f;
    public float lives = 3f;

    public float redBattery = 100;
    public float greenBattery = 100;
    public float blueBattery = 100;

    public bool frenzyOn = false;

    //COMBO AND BOOST
    //Combo Type:
    // 1 - 2x Damage for 10 seconds (Red)
    // 2 - +1 Live (Green)
    // 3 - Slowed time (Blue)
    private Coroutine comboActivation = null;
    public GameObject[] asteroidList;
    public GameObject asteroidChosen;
    public int comboTotalAmount;
    public float comboTotalScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; 
        StartCoroutine(frenzyTrigger());
        StartCoroutine(levelUp());
        StartCoroutine(batteryRegenerate());

        asteroidChosen = asteroidList[Random.Range(0,5)];
        if(asteroidChosen.GetComponent<AsteroidBehavior>().type == "small"){
            float comboTotalAmountFloat = Random.value * 20f;
            if(comboTotalAmountFloat < 10f){
                comboTotalAmountFloat = 10f;
            }
            comboTotalScore = comboTotalAmountFloat * 20f;
            comboTotalAmount = (int)comboTotalAmountFloat;
        }else if(asteroidChosen.GetComponent<AsteroidBehavior>().type == "big"){
            float comboTotalAmountFloat = Random.value * 10f;
            if(comboTotalAmountFloat < 4f){
                comboTotalAmountFloat = 4f;
            }
            comboTotalScore = comboTotalAmountFloat * 100f;
            comboTotalAmount = (int)comboTotalAmountFloat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0f){
            Destroy(GameObject.Find("Rocket"));
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }

        if(comboTotalAmount <= 0){
            if(comboActivation == null){
                comboActivation = StartCoroutine(ComboActivation());
            }
    
            asteroidChosen = asteroidList[Random.Range(0,5)];
            if(asteroidChosen.GetComponent<AsteroidBehavior>().type == "small"){
                float comboTotalAmountFloat = Random.value * 20f;
                if(comboTotalAmountFloat < 10f){
                    comboTotalAmountFloat = 10f;
                }
                comboTotalScore = comboTotalAmountFloat * 20f;
                comboTotalAmount = (int)comboTotalAmountFloat;
            }else if(asteroidChosen.GetComponent<AsteroidBehavior>().type == "big"){
                float comboTotalAmountFloat = Random.value * 10f;
                if(comboTotalAmountFloat < 4f){
                    comboTotalAmountFloat = 4f;
                }
                comboTotalScore = comboTotalAmountFloat * 100f;
                comboTotalAmount = (int)comboTotalAmountFloat;
            }
            
        Debug.Log(comboTotalScore);
        }
    }

    void FixedUpdate(){
        score += 1f * level * Time.deltaTime;
        if(scoreDebt > 0){
            score += 1f;
            scoreDebt -= 1f;
        }
    }

    IEnumerator frenzyTrigger()
    {
        yield return new WaitForSeconds(90f);
        frenzyOn = true;
        yield return new WaitForSeconds(30f);
        frenzyOn = false;
        StartCoroutine(frenzyTrigger());
    }

    IEnumerator levelUp()
    {
        yield return new WaitForSeconds(60f);
        level += 1f;
        StartCoroutine(levelUp());
    }

    IEnumerator batteryRegenerate(){
        yield return new WaitForSeconds(2f);
        if(redBattery < 100f){
            redBattery += 1f;
        }
        if(greenBattery < 100f){
            greenBattery += 1f;
        }
        if(blueBattery < 100f){
            blueBattery += 1f;
        }
        StartCoroutine(batteryRegenerate());
    }

    IEnumerator ComboActivation(){
        scoreDebt += comboTotalScore;
        int comboTotalScoreInt = (int)comboTotalScore;
        bonusPointsText.GetComponent<TMP_Text>().text = "You got " + comboTotalScoreInt.ToString() + " points!";
        bonusPointsText.SetActive(true);

        if(asteroidChosen.GetComponent<AsteroidBehavior>().color == "Red (Instance)"){
            Debug.Log("Red asteroid combo activated");
            yield return new WaitForSeconds(10f); 
            Debug.Log("Red asteroid combo deactivated");
        }else if(asteroidChosen.GetComponent<AsteroidBehavior>().color == "Green (Instance)"){
            Debug.Log("Green asteroid combo activated");
            yield return new WaitForSeconds(10f); 
            Debug.Log("Green asteroid combo deactivated");
        }else if(asteroidChosen.GetComponent<AsteroidBehavior>().color == "Blue (Instance)"){
            Debug.Log("Blue asteroid combo activated");
            yield return new WaitForSeconds(10f); 
            Debug.Log("Blue asteroid combo deactivated");
        }
        comboActivation = null;
    }
}

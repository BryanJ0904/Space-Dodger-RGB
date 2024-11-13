using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bigRedAsteroid;
    [SerializeField] private GameObject smallRedAsteroid;
    [SerializeField] private GameObject bigBlueAsteroid;
    [SerializeField] private GameObject smallBlueAsteroid;
    [SerializeField] private GameObject bigGreenAsteroid;
    [SerializeField] private GameObject smallGreenAsteroid;
    private GameObject[] smallAsteroidList, bigAsteroidList;
    private float smallSpawnDelay, bigSpawnDelay;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        smallAsteroidList = new GameObject[] {smallRedAsteroid, smallBlueAsteroid, smallGreenAsteroid};
        bigAsteroidList = new GameObject[] {bigRedAsteroid, bigBlueAsteroid, bigGreenAsteroid};
        StartCoroutine(generateSmallObject());
        StartCoroutine(generateBigObject());

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if(gameManager != null){
            if(gameManager.frenzyOn == true){
                smallSpawnDelay = 0.5f + (Random.Range(-1, 0) * Random.value / 10f * gameManager.level);
                bigSpawnDelay = 2.5f + (Random.Range(-1, 0) * Random.value / 5f * gameManager.level);
                if(smallSpawnDelay <= 0.1f){
                    smallSpawnDelay = 0.1f;
                }else if(bigSpawnDelay <= 0.5f){
                    bigSpawnDelay = 0.5f;
                }
            }else{
                smallSpawnDelay = 1f + (Random.Range(-1, 0) * Random.value / 5f * gameManager.level);
                bigSpawnDelay = 5f + (Random.Range(-1, 0) * Random.value / 2.5f * gameManager.level);
                if(smallSpawnDelay <= 0.2f){
                    smallSpawnDelay = 0.2f;
                }else if(bigSpawnDelay <= 1f){
                    bigSpawnDelay = 1f;
                }
            }
        }else{
            smallSpawnDelay = 1f;
            bigSpawnDelay = 5f;
        }
    }

    private IEnumerator generateSmallObject()
    {
        yield return new WaitForSeconds(smallSpawnDelay);
        int randomObjectPicker = Random.Range(0, 3);
        
        GameObject newObject;
        if(Screen.currentResolution.width != 1024 && Screen.currentResolution.height != 768){
            newObject = Instantiate(smallAsteroidList[randomObjectPicker], new Vector2(Random.Range(-6, 8), Random.Range(6, 10)), Quaternion.identity);
        }else{
            newObject = Instantiate(smallAsteroidList[randomObjectPicker], new Vector2(Random.Range(-4, 6), Random.Range(6, 10)), Quaternion.identity);
        }
        Rigidbody2D newObjectRb = newObject.GetComponent<Rigidbody2D>();
        int rng = Random.Range(-10, 10);
        newObjectRb.AddForce(new Vector3(Random.value * rng, 0f, 0f));
        newObjectRb.AddTorque(3f * rng);

        StartCoroutine(generateSmallObject());
    }

    private IEnumerator generateBigObject()
    {
        yield return new WaitForSeconds(bigSpawnDelay);
        int randomObjectPicker = Random.Range(0, 3);
        
        GameObject newObject = Instantiate(bigAsteroidList[randomObjectPicker], new Vector2(Random.Range(-6, 8), Random.Range(6, 10)), Quaternion.identity);
        Rigidbody2D newObjectRb = newObject.GetComponent<Rigidbody2D>();
        
        int rng = Random.Range(-3, 3);
        newObjectRb.AddForce(new Vector3(Random.value * rng, 0f, 0f));
        newObjectRb.AddTorque(10f * rng);
        StartCoroutine(generateBigObject());
    }
}

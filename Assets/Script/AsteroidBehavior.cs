using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField] public string type;
    [SerializeField] public string color;
    [SerializeField] private int health;
    private SpriteRenderer spriteRenderer;
    private AudioSource audio;
    [SerializeField] public GameObject collisionPoint;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Laser 1" || collision.gameObject.name == "Laser 2" || collision.gameObject.name == "Rocket"){
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            if(collision.gameObject.name == "Rocket"){
                health = 0;
            }else if(color == renderer.material.name){
                health -= 1;
            }
            if(health == 0){
                GameObject collisionObject = Instantiate(collisionPoint, transform.position, Quaternion.identity);
                GameObject collisionObjectScore = collisionObject.transform.GetChild(0).GetChild(0).gameObject;
                if(type == "small" && collision.gameObject.name != "Rocket"){
                    collisionObjectScore.GetComponent<TMP_Text>().text = "10";
                    gameManager.scoreDebt += 10;
                    if(GetComponent<SpriteRenderer>().sprite == gameManager.asteroidChosen.GetComponent<SpriteRenderer>().sprite){
                        gameManager.comboTotalAmount -= 1;
                    }
                }else if(type == "big" && collision.gameObject.name != "Rocket"){
                    collisionObjectScore.GetComponent<TMP_Text>().text = "50";
                    gameManager.scoreDebt += 50;
                    if(GetComponent<SpriteRenderer>().sprite == gameManager.asteroidChosen.GetComponent<SpriteRenderer>().sprite){
                        gameManager.comboTotalAmount -= 1;
                    }
                }
                Destroy(gameObject);
            }
            else if(color == renderer.material.name){
                audio.Play();
                StartCoroutine(changeColor());
            }
        }
    }

    IEnumerator changeColor()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(0.784f, 0.784f, 0.784f);
    }
}

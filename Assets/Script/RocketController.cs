using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject[] colorDependentObjects;
    [SerializeField] private GameObject laser;
    private Animator animation;
    public Material colorPicked;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        colorPicked = Resources.Load<Material>("Red");
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //INDESTRUCTIBLE DURING CRASHED ANIMATION
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        AnimatorStateInfo stateInfo = animation.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Crashed")){
            collider.enabled = false;
        }else{
            collider.enabled = true;
        }

        //CHANGE LASER COLOR
        //1 = RED   2 = GREEN   3 = BLUE
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            colorPicked = Resources.Load<Material>("Red");
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            colorPicked = Resources.Load<Material>("Green");
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            colorPicked = Resources.Load<Material>("Blue");
        }

        foreach (GameObject obj in colorDependentObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = colorPicked;
        }

        //LASER SHOOT
        if(Input.GetKeyDown(KeyCode.Space)){
            bool readyToLoad = true;

            if(colorPicked == Resources.Load<Material>("Red")){
                if(gameManager.redBattery >= 2f){
                    gameManager.redBattery -= 2f;
                }else{
                    readyToLoad = false;
                }
            }else if(colorPicked == Resources.Load<Material>("Green")){
                if(gameManager.greenBattery >= 2f){
                    gameManager.greenBattery -= 2f;
                }else{
                    readyToLoad = false;
                }
            }else if(colorPicked == Resources.Load<Material>("Blue")){
                if(gameManager.blueBattery >= 2f){
                    gameManager.blueBattery -= 2f;
                }else{
                    readyToLoad = false;
                }
            }
            
            if(readyToLoad == true){
                Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                GameObject newLaser = Instantiate(laser, laserPosition, Quaternion.identity);

                Transform laser1Transform = newLaser.transform.GetChild(0);
                Transform laser2Transform = newLaser.transform.GetChild(1);
                GameObject laser1 = laser1Transform.gameObject;
                GameObject laser2 = laser2Transform.gameObject;

                Renderer renderer1 = laser1.GetComponent<Renderer>();
                Renderer renderer2 = laser2.GetComponent<Renderer>();
                renderer1.material = colorPicked;
                renderer2.material = colorPicked;
            
                Rigidbody2D rb1 = laser1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = laser2.GetComponent<Rigidbody2D>();
                rb1.AddForce(new Vector2(0f, 10f));
                rb2.AddForce(new Vector2(0f, 10f));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        AsteroidBehavior asteroid = collision.gameObject.GetComponent<AsteroidBehavior>();
        if(asteroid.type == "small"){
            gameManager.lives -= 1f;
        }else if(asteroid.type == "big"){
            gameManager.lives -= 3f;
        }

        if(gameManager.lives < 0f){
            gameManager.lives = 0f;
        }else{
            animation.SetTrigger("isCrashed");
        }
    }
}

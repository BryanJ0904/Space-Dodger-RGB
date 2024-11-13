using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCloner : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool cloned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0f, -20f));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -3.5f && cloned == false){
            Instantiate(this.gameObject, new Vector3(1.5f, 13.5f, 0f), Quaternion.identity);
            cloned = true;
        }
        if(transform.position.y <= -13f){
            Destroy(gameObject);
        }
    }
}

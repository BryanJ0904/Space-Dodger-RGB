using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    float horizontalInput, verticalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ROCKET MOVEMENT
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Screen.currentResolution.width != 1024 && Screen.currentResolution.height != 768){
            if(transform.position.x > 8f){
                transform.position = new Vector3(8f, transform.position.y, 0f);
            }else if(transform.position.x < -6f){
                transform.position = new Vector3(-6f, transform.position.y, 0f);
            }

            if(transform.position.y > 3f){
                transform.position = new Vector3(transform.position.x, 3f, 0f);
            }else if(transform.position.y < -2.5f){
                transform.position = new Vector3(transform.position.x, -2.5f, 0f);
            }
        }else{
            if(transform.position.x > 5.8f){
                transform.position = new Vector3(5.8f, transform.position.y, 0f);
            }else if(transform.position.x < -4.3f){
                transform.position = new Vector3(-4.3f, transform.position.y, 0f);
            }

            if(transform.position.y > 3f){
                transform.position = new Vector3(transform.position.x, 3f, 0f);
            }else if(transform.position.y < -2.5f){
                transform.position = new Vector3(transform.position.x, -2.5f, 0f);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f);
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }
        moveDirection = transform.TransformDirection(moveDirection);

        transform.position += moveDirection * 5f * Time.deltaTime;
    }
}

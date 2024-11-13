using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Laser(Clone)" || gameObject.name == "CollisionPoint(Clone)" || gameObject.name == "BonusPoints(Clone)"){
            StartCoroutine(DestroyAfterASecond());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f){
            Destroy(gameObject);
        }else if(transform.position.y > 12f){
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterASecond(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

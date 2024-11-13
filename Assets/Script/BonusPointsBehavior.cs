using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPointsBehavior : MonoBehaviour
{
    private Coroutine coroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf){
            if(coroutine == null){
                coroutine = StartCoroutine(DeactivateAfterASecond());
            }
        }
    }

    IEnumerator DeactivateAfterASecond(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        coroutine = null;
    }
}

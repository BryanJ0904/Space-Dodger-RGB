using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionButtonBehavior : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int width;
    [SerializeField] private int height;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.currentResolution.width == width && Screen.currentResolution.height == height){
            spriteRenderer.sprite = sprites[1];
        }else{
            spriteRenderer.sprite = sprites[0];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionCanvasBehavior : MonoBehaviour
{
    private RectTransform dimension;
    // Start is called before the first frame update
    void Start()
    {
        dimension = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(dimension.sizeDelta);
    }
}

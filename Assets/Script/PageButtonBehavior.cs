using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    private GameObject activePage;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        activePage = pages[index];
        if(!activePage.activeSelf){
            activePage.SetActive(true);
        }
    }

    public void buttonLeft()
    {
        activePage.SetActive(false); 
        if(index - 1 >= 0){
            index = index - 1;
        }
        activePage = pages[index];
        if(!activePage.activeSelf){
            activePage.SetActive(true);
        }
    }

    public void buttonRight()
    {
        activePage.SetActive(false); 
        if(index + 1 < pages.Length){
            index = index + 1;
        }
        activePage = pages[index];
        if(!activePage.activeSelf){
            activePage.SetActive(true);
        }
    }
}

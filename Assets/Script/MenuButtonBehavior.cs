using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButtonBehavior : MonoBehaviour
{

    private TMP_Text container;
    private string originalText;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        GameObject textObj = transform.GetChild(0).gameObject;
        container = textObj.GetComponent<TMP_Text>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnHover()
    {
        originalText = container.text;
        container.text = ">> " + originalText + " <<";
    }

    public void OffHover()
    {
        container.text = originalText; 
    }

    public void Switch(int value)
    {
        GameObject ui = GameObject.Find("UI");
        GameObject optionsPanel = ui.transform.Find("OptionsPanel").gameObject;
        GameObject helpPanel = ui.transform.Find("HelpPanel").gameObject;

        switch(value)
        {
            case 1:
                SceneManager.LoadSceneAsync("Game");
                break;
            case 2:
                if(helpPanel.activeSelf){
                    helpPanel.SetActive(false);
                }

                if(!optionsPanel.activeSelf){
                    audio.Play();
                    optionsPanel.SetActive(true);
                }else{
                    optionsPanel.SetActive(false);
                }
                break;
            case 3:
                if(optionsPanel.activeSelf){
                    optionsPanel.SetActive(false);
                }

                if(!helpPanel.activeSelf){
                    audio.Play();
                    helpPanel.SetActive(true);
                }else{
                    helpPanel.SetActive(false);
                }
                break;
        }
    }
}

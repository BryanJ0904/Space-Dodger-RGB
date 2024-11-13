using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject escapePanel;
    [SerializeField] private TMP_Text textObject;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
                Debug.Log(escapePanel);
            if(escapePanel.activeSelf && SceneManager.GetActiveScene().name == "Game"){
                SceneManager.LoadSceneAsync("Menu");
            }else{
                if(escapePanel.activeSelf){
                    escapePanel.SetActive(false);
                }else{
                    escapePanel.SetActive(true);
                }
            }
        }
    }

    public void RestartButton()
    {
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadSceneAsync("Game");
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ToggleExitPanel()
    {
        Debug.Log(textObject);
        textObject.text = "no";
        
        if(escapePanel.activeSelf){
            escapePanel.SetActive(false);
        }else{
            escapePanel.SetActive(true);
        }
    }
}

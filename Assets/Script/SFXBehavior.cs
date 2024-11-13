using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBehavior : MonoBehaviour
{
    private AudioSource audio;
    public SettingsManager settingsManager;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        GameObject settingsManagerObj = GameObject.Find("GameSettings");
        settingsManager = settingsManagerObj.GetComponent<SettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(settingsManager != null){
            audio.volume = settingsManager.sfxVolume;
        }
    }
}

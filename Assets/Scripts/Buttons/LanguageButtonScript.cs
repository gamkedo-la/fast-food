using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButtonScript : MonoBehaviour
{
    [SerializeField] string language = "";
    public Text currentLanguageTextbox;
    [SerializeField] AudioClip buttonClickAudioClip;

    private void Start()
    {
        
    }
    public void HandleLanguageButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        GameManagerScript.currentLanguage = language;
        currentLanguageTextbox.text = "Current Language: " + GameManagerScript.currentLanguage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButtonScript : ButtonScript
{
    [SerializeField] string language = "";
    public Text currentLanguageTextbox;
    [SerializeField] AudioClip buttonClickAudioClip;

    public override void HandleButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        GameManagerScript.currentLanguage = language;
        currentLanguageTextbox.text = "Current Language: " + GameManagerScript.currentLanguage;
    }
}

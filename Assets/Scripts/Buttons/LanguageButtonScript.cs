using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageButtonScript : ButtonScript
{
    [SerializeField] string language = "";
    [SerializeField] TextMeshProUGUI targetLanguageTextbox;

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLanguage = language;
        Debug.Log("GameManagerScript.currentLanguage: " + GameManagerScript.currentLanguage);
        targetLanguageTextbox.text = "Target Language: " + GameManagerScript.currentLanguage;

        GameManagerScript.currentProfile.targetLanguage = language;
        SaveSystem.SaveListOfProfilesData();

        //Play button audio
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

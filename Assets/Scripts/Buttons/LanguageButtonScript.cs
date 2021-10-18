using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButtonScript : ButtonScript
{
    [SerializeField] string language = "";
    public Text currentLanguageTextbox;

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLanguage = language;
        currentLanguageTextbox.text = "Current Language: " + GameManagerScript.currentLanguage;

        GameManagerScript.currentProfile.targetLanguage = language;
        SaveSystem.SaveListOfProfilesData();

        //Play button audio
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

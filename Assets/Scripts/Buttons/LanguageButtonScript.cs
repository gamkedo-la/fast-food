using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageButtonScript : ButtonScript
{
    [SerializeField] Language language;
    [SerializeField] TextMeshProUGUI targetLanguageTextbox;

    public override void HandleButtonClick()
    {
        GameManagerScript.currentLanguage = language;
        targetLanguageTextbox.text = "Target Language: " + GameManagerScript.currentLanguage.ToString();

        GameManagerScript.currentProfile.targetLanguage = language;
        SaveSystem.SaveListOfProfilesData();

        //Play button audio
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

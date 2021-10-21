using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnButtonScript : ButtonScript
{
    [SerializeField] GameObject objectToToggleOn;
    [SerializeField] GameObject objectToToggleOff;
    private void ToggleOn()
    {
        if (objectToToggleOn != null)
        {
            objectToToggleOn.SetActive(true);
        }
    }

    private void ToggleOff()
    {
        if (objectToToggleOff != null)
        {
            objectToToggleOff.SetActive(false);
        }
    }

    public override void HandleButtonClick()
    {
        if (gameObject.name == "LanguageSelectButton" && GameManagerScript.currentProfile.userName == null)
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            return;
        } 
        else if (gameObject.name == "LanguageScreenNextButton" && GameManagerScript.currentLanguage == "")
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            return;
        }
        else if (gameObject.name == "OKToggleButton")
        {
            Time.timeScale = 1;
        }
        ToggleOn();
        ToggleOff();
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

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
        if (gameObject.name == "SelectLanguageButton" && GameManagerScript.currentProfile == null)
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            return;
        } 
        else if (gameObject.name == "LanguageScreenNextButton" && GameManagerScript.currentLanguage == Language.Undefined)
        {
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Incorrect_Order);
            return;
        }
        else if (gameObject.name == "OKToggleButton")
        {
            Time.timeScale = 1;
            GameObject tomatoIntroduction = GameObject.FindGameObjectWithTag("TomatoIntroduction");
            GameObject chickenDonerIntroduction = GameObject.FindGameObjectWithTag("ChickenDonerIntroduction");
            GameObject onionIntroduction = GameObject.FindGameObjectWithTag("OnionIntroduction");
            if (tomatoIntroduction != null)
            {
                tomatoIntroduction.SetActive(false);
            }
            if (chickenDonerIntroduction != null)
            {
                chickenDonerIntroduction.SetActive(false);
            }
            if (onionIntroduction != null)
            {
                onionIntroduction.SetActive(false);
            }
        }
        ToggleOn();
        ToggleOff();
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

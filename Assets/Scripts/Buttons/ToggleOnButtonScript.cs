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
        ToggleOn();
        ToggleOff();
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

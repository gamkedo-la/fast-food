using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStudentInputFieldScript : MonoBehaviour
{
    public void HandleOnSelect()
    {
        PlayUIButtonSound();
    }

    public void HandleOnValueEdit()
    {
        PlayUIButtonSound();
    }
    private void PlayUIButtonSound()
    {
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}

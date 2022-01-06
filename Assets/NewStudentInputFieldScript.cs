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
        PlayUITypingSound();
    }
    private void PlayUIButtonSound()
    {
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }

    private void PlayUITypingSound()
    {
        AudioController.instance.PlayAudio(GameSoundEnum.Typing_UI_SFX);
    }
}

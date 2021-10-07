using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public AudioController audioController;

    public void HandleQuitButtonClick()
    {
        audioController.PlayAudio(GameSoundEnum.UI_Button);
        Application.Quit();
    }
}

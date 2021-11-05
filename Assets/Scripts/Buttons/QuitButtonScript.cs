using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public void HandleQuitButtonClick()
    {
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
        AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickAudioClip;
    public AudioController audioController;

    public void HandleQuitButtonClick()
    {
        //AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        audioController.PlayAudio(GameSoundEnum.UI_Button);
        Application.Quit();
    }
}
